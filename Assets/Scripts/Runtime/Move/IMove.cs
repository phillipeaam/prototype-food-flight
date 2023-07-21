using System;
using UnityEngine;

namespace Assets.Scripts.Move
{
    public interface IMove
    {
        public Transform SourceTransform { get; }
        public float Speed { get; }
        public Vector3 Direction { get; }
        
        public event Action OnMove;
    }
}