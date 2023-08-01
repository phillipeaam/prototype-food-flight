using System.Collections.Generic;
using Assets.Scripts.Base;
using Assets.Scripts.Pooler.Pool;
using UnityEngine;

namespace Assets.Scripts.Pooler
{
    public interface IPoolerView
    {
        public List<PoolModel> Pools { get; }
        public Dictionary<IStringReference, Queue<GameObject>> PoolDictionary { get; }
    }
}