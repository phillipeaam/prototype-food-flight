using System;
using Assets.Scripts.Base;
using UnityEngine;

namespace Assets.Scripts.Pooler.Utils.HideWhenOutOfBounds
{
    public class HideWhenOutOfBoundsView : SelfControlledBehaviour<HideWhenOutOfBoundsController>, IHideWhenOutOfBoundsView
    {
        [SerializeField] private Transform _sourceTransform;
        public Transform SourceTransform => _sourceTransform;
        
        [SerializeField] private GameObject _sourceGameObject;
        public GameObject SourceGameObject => _sourceGameObject;
        
        [SerializeField]
        private float _topBound;
        public float TopBound => _topBound;
        
        [SerializeField]
        private float _bottomBound;
        public float BottomBound => _bottomBound;

        public event Action OnDeactivateGameObject;
        
        protected override void Configure()
        {
            Controller = new HideWhenOutOfBoundsController(this);
        }
        
        private void LateUpdate()
        {
            OnDeactivateGameObject?.Invoke();
        }
    }   
}
