using System;
using Assets.Scripts.Base;
using UnityEngine;

namespace Assets.Scripts.PlayerControl
{
    public class PlayerControlView : MonoBehaviour, IPlayerControlView
    {
        private const string Horizontal = "Horizontal";
        private const string Fire = "Jump";
        
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

        public float InputDirection { get; private set; }
        public bool InputFire { get; private set; }
        
        public event Action OnUpdatePosition;
        public event Action OnHandleProjectileLaunch;

        private void Update()
        {
            RegisterInput();
            OnUpdatePosition?.Invoke();
            OnHandleProjectileLaunch?.Invoke();
        }

        private void RegisterInput()
        {
            InputDirection = Input.GetAxis(Horizontal);
            InputFire = Input.GetButtonDown(Fire);
        }
    }
}