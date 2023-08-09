using System;
using Assets.Scripts.Base;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.PlayerControl
{
    public interface IPlayerControlView
    {
        public InputAction InputReader { get; }
        public IStringReference ProjectileTag { get; }
        public Transform SourceTransform { get; }
        public float PositionRangeLimit { get; }
        public float Speed { get; }

        public event Action<float> Move;
        
        public void HandleMoveInput(InputAction.CallbackContext context);
    }
}