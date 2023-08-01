using System;
using UnityEngine;

namespace Assets.Scripts.PlayerControl
{
    public interface IPlayerControlView
    {
        public GameObject ProjectilePrefab { get; }
        public Transform SourceTransform { get; }
        public float PositionRangeLimit { get; }
        public float Speed { get; }
        public float InputDirection { get; }
        public bool InputFire { get; }

        public event Action OnUpdatePosition;
        public event Action OnHandleProjectileLaunch;
    }
}