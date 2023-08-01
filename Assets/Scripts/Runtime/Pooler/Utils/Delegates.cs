using Assets.Scripts.Base;
using UnityEngine;

namespace Assets.Scripts.Pooler.Utils
{
    public abstract class Delegates
    {
        public delegate GameObject RetrieveInstanceFromPoolDelegate(IStringReference tag, Vector3 position, Quaternion rotation);
    }
}