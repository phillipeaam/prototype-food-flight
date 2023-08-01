using System;
using Assets.Scripts.Base;
using UnityEngine;

namespace Assets.Scripts.Move
{
    public class MoveView : SelfControlledBehaviour<MoveController>, IMoveView
    {
        [SerializeField]
        private Transform _sourceTransform;
        public Transform SourceTransform => _sourceTransform;
        
        [SerializeField]
        private float _speed;
        public float Speed => _speed;
        
        [SerializeField]
        private Vector3 _direction;
        public Vector3 Direction => _direction;
        
        public event Action OnMove;

        protected override void Configure()
        {
            Controller = new MoveController(this);
        }

        private void Update()
        {
            OnMove?.Invoke();
        }
    }
}