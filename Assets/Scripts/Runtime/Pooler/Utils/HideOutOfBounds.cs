using UnityEngine;

namespace Assets.Scripts.Pooler.Utils
{
    public class HideOutOfBounds : MonoBehaviour
    {
        [SerializeField]
        private float _topBound;
        [SerializeField]
        private float _bottomBound;

        private void LateUpdate()
        {
            DeactivateGameObject();
        }

        private void DeactivateGameObject()
        {
            var positionZ = transform.position.z;
            
            if (positionZ > _topBound || positionZ < _bottomBound)
            {
                gameObject.SetActive(false);
            }
        }
    }   
}
