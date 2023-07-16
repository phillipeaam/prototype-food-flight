using System;
using UnityEngine;

namespace Assets.Scripts.PlayerControl
{
    public class PlayerControlView : MonoBehaviour, IPlayerControl
    {
        private const string Horizontal = "Horizontal";
        
        [SerializeField]
        private Transform _sourceTransform;
        public Transform SourceTransform => _sourceTransform;
        
        [SerializeField]
        private float _positionRangeLimit;
        public float PositionRangeLimit => _positionRangeLimit;
        
        [SerializeField]
        private float _speed;
        public float Speed => _speed;

        public float InputDirection { get; private set; }
        
        public event Action OnUpdatePosition;
        
        private void Update()
        {
            RegisterInput();
            OnUpdatePosition?.Invoke();
        }

        private void RegisterInput()
        {
            InputDirection = Input.GetAxis(Horizontal);
        }
    }
}