using System;
using UnityEngine;

namespace Assets.Scripts.Pooler.Utils.HideWhenOutOfBounds
{
    public interface IHideWhenOutOfBoundsView
    {
        public Transform SourceTransform { get; }
        public GameObject SourceGameObject { get; }
        public float TopBound { get; }
        public float BottomBound { get; }
        
        public event Action OnDeactivateGameObject;
    }
}