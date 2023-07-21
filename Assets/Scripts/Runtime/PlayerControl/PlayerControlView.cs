using System;
using UnityEngine;

namespace Assets.Scripts.PlayerControl
{
    public class PlayerControlView : MonoBehaviour, IPlayerControl
    {
        private const string Horizontal = "Horizontal";
        private const string Fire = "Jump";
        
        [SerializeField]
        private GameObject _projectilePrefab;
        public GameObject ProjectilePrefab => _projectilePrefab;
        
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