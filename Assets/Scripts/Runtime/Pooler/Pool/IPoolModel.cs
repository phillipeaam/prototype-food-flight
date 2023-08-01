using Assets.Scripts.Base;
using UnityEngine;

namespace Assets.Scripts.Pooler.Pool
{
    public interface IPoolModel
    {
        public IStringReference Tag { get; }
        public GameObject Prefab { get; }
        public int Size { get; }
    }
}