using UnityEngine;

namespace Assets.Scripts.Base.Input
{
    /// <summary>
    /// Base class for ScriptableObjects that need a public description field.
    /// </summary>
    public class DescriptionBaseSO : ScriptableObject
    {
        [SerializeField] [TextArea]
        private string _description;

        public string Description
        {
            get => _description;
            set => _description = value;
        }
    }
}