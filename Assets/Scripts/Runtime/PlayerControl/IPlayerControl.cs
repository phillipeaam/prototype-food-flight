using System;
using UnityEngine;

namespace Assets.Scripts.Runtime.PlayerControl
{
    public interface IPlayerControl
    {
        public Transform SourceTransform { get;  }
        public float PositionRangeLimit { get; }
        public float Speed { get; }
        public float InputDirection { get; }
        
        public event Action OnUpdatePosition;
    }
}