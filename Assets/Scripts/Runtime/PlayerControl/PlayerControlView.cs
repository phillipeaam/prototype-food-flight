using Assets.Scripts.Base;
using UnityEngine;

namespace Assets.Scripts.PlayerControl
{
    public class PlayerControlView : SelfControlledBehaviour<PlayerController>, IPlayerControlView
    {
        [SerializeField]
        private InputReader _inputReader;
        public IInputReader InputReader => _inputReader;
        
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

        protected override void Configure()
        {
            Controller = new PlayerController(this);
        }
    }
}