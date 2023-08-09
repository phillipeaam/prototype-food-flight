using Assets.Scripts.Base;
using UnityEngine;

namespace Assets.Scripts.PlayerControl
{
    public interface IPlayerControlView
    {
        public IInputReader InputReader { get; }
        public IStringReference ProjectileTag { get; }
        public Transform SourceTransform { get; }
        public float PositionRangeLimit { get; }
        public float Speed { get; }
    }
}