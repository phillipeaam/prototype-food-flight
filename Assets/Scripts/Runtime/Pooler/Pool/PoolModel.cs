using System;
using Assets.Scripts.Base;
using UnityEngine;

namespace Assets.Scripts.Pooler.Pool
{
    [Serializable]
    public class PoolModel : IPoolModel
    {
        [SerializeField]
        private StringReference _tag;
        public IStringReference Tag => _tag;
        
        [SerializeField]
        private GameObject _prefab;
        public GameObject Prefab => _prefab;
        
        [SerializeField]
        private int _size;
        public int Size => _size;
    }
}