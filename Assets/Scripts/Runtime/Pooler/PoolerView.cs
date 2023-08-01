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

        private List<IPoolModel> _iPools;
        public List<IPoolModel> IPools => _iPools ??= _pools.ConvertAll(p => (IPoolModel) p);
        
        public Dictionary<IStringReference, Queue<GameObject>> PoolDictionary { get; } = new();
    }
}
