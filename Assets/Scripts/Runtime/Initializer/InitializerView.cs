using System;
using System.Threading.Tasks;
using Assets.Scripts.PlayerControl;
using UnityEngine;

namespace Assets.Scripts.Initializer
{
    public class InitializerView : MonoBehaviour, IInitializer
    {
        [SerializeField]
        private PlayerControlView _playerControlView;
        public IPlayerControl PlayerControl => _playerControlView;

        private InitializerController _initializerController;

        private void Awake()
        {
            InitializeControllers().ConfigureAwait(false);
        }

        private void OnDestroy()
        {
            DisposeControllers().ConfigureAwait(false);
        }

        private async Task InitializeControllers()
        {
            _initializerController = new InitializerController(this);

            try
            {
                await _initializerController.Initialize();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
        
        private async Task DisposeControllers()
        {
            if (_initializerController is null)
                return;

            try
            {
                await _initializerController.Dispose();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}