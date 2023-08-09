using System;
using Assets.Scripts.Base;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.PlayerControl
{
    public class PlayerControlView : SelfControlledBehaviour<PlayerController>, IPlayerControlView
    {
        [SerializeField]
        private InputReader _inputReader;
        public IInputReader InputReader => _inputReader as IInputReader;
        
        [SerializeField]
        private StringReference _projectileTag;
        public IStringReference ProjectileTag => _projectileTag;
        
        [SerializeField]
        private Transform _sourceTransform;
        public Transform SourceTransform => _sourceTransform;
        
        [SerializeField]
        private float _positionRangeLimit;
        public float PositionRangeLimit => _positionRangeLimit;
        
        [SerializeField]
        private float _speed;
        public float Speed => _speed;
        
        public event Action<float> Move;

        protected override void Configure()
        {
            Controller = new PlayerController(this);
        }

        public void HandleMoveInput(InputAction.CallbackContext context)
        {
            var moveAmount = context.ReadValue<float>();
            Move?.Invoke(moveAmount);
        }
    }
}