using UnityEngine.Events;

namespace Assets.Scripts.Base
{
    public interface IInputReader
    {
        public event UnityAction<float> MoveEvent;
        public event UnityAction ActionEvent;
    }
}