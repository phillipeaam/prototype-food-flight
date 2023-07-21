using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Base
{
    public class SelfControlledView<T> : MonoBehaviour where T : IController
    {
        protected T Controller { get; set; }

        private void Awake()
        {
            Configure();
            InitializeControllers().ConfigureAwait(false);
        }
        
        protected virtual void Configure()
        {
        }
        
        private async Task InitializeControllers()
        {
            if (Controller is null)
                return;
            
            try
            {
                await Controller.Initialize();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private void OnDestroy()
        {
            DisposeControllers().ConfigureAwait(false);
        }

        private async Task DisposeControllers()
        {
            if (Controller is null)
                return;

            try
            {
                await Controller.Dispose();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}