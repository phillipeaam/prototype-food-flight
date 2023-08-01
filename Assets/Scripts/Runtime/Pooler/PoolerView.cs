using System.Collections.Generic;
using Assets.Scripts.Base;
using Assets.Scripts.Pooler.Pool;
using UnityEngine;

namespace Assets.Scripts.Pooler
{
    public class PoolerView : SelfControlledBehaviour<PoolerController>, IPoolerView
    {
        [SerializeField]
        private List<PoolModel> _pools;
        public List<PoolModel> Pools => _pools;
        
        public Dictionary<IStringReference, Queue<GameObject>> PoolDictionary { get; } = new();
    }
}
