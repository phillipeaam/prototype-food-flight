using System;
using Assets.Scripts.Base;
using UnityEngine;

namespace Runtime.TargetSkin
{
    public class TargetSkinView : SelfControlledBehaviour<TargetSkinController>, ITargetSkinView
    {
        [SerializeField]
        private GameObject[] _skinGameObjects;
        public GameObject[] SkinGameObjects => _skinGameObjects;
        
        public event Action OnEnabled;
        public event Action OnDisabled;

        protected override void Configure()
        {
            Controller = new TargetSkinController(this);
        }

        private void OnEnable()
        {
            OnEnabled?.Invoke();
        }
        
        private void OnDisable()
        {
            OnDisabled?.Invoke();
        }
    }
}