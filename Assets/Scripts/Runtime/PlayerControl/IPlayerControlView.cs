using System;
using Assets.Scripts.Base;
using UnityEngine;

namespace Assets.Scripts.PlayerControl
{
    public interface IPlayerControlView
    {
        public IStringReference ProjectileTag { get; }
        public Transform SourceTransform { get; }
        public float PositionRangeLimit { get; }
        public float Speed { get; }
        public float InputDirection { get; }
        public bool InputFire { get; }

        public event Action OnUpdatePosition;
        public event Action OnHandleProjectileLaunch;
    }
}