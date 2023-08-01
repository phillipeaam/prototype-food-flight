using UnityEngine;

namespace Assets.Scripts.Base
{
    [CreateAssetMenu(fileName = "StringReference", menuName = "BaseTypes/StringReference")]
    public class StringReference : ScriptableObject, IStringReference
    {
        [SerializeField]
        private string _value;
        public string Value => _value;
    }
}