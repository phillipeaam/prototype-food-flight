using System;
using UnityEngine;

namespace Runtime.TargetSkin
{
    public interface ITargetSkinView
    {
        public GameObject[] SkinGameObjects { get; }
        
        public event Action OnEnabled;
        public event Action OnDisabled;
    }
}