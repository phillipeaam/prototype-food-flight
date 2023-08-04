using System.Threading.Tasks;
using Assets.Scripts.Base;
using UnityEngine;

namespace Runtime.TargetSkin
{
    public class TargetSkinController : IController
    {
        private const int NoSkinIndex = -1;
        
        private readonly ITargetSkinView _view;
        
        private int _currentSkinIndex = NoSkinIndex;
        
        public TargetSkinController(ITargetSkinView view)
        {
            _view = view;
        }

        public Task Initialize()
        {
            _view.OnEnabled += ActivateRandomSkin;
            _view.OnDisabled += DeactivateCurrentSkin;
            
            return Task.CompletedTask;
        }

        public Task Dispose()
        {
            _view.OnEnabled -= ActivateRandomSkin;
            _view.OnDisabled -= DeactivateCurrentSkin;
            
            return Task.CompletedTask;
        }
        
        private void ActivateRandomSkin()
        {
            // If we already have a skin active, deactivate it, something odd happened
            if (_currentSkinIndex != NoSkinIndex)
            {
                // Deactivate all skins to avoid having multiple skins active at the same time
                DeactivateAllSkins();
            }

            var skinIndex = GetRandomSkinIndex();

            if (TryGetCurrentSkinGameObject(skinIndex, out var skinGameObject))
            {
                skinGameObject.SetActive(true);
                _currentSkinIndex = skinIndex;
            }
        }

        private int GetRandomSkinIndex()
        {
            return Random.Range(0, _view.SkinGameObjects.Length);
        }

        private bool TryGetCurrentSkinGameObject(int skinIndex, out GameObject skinGameObject)
        {
            if (skinIndex == NoSkinIndex || skinIndex >= _view.SkinGameObjects.Length)
            {
                skinGameObject = null;
            }
            else
            {
                skinGameObject = _view.SkinGameObjects[skinIndex];
            }

            return skinGameObject != null;
        }

        private void DeactivateAllSkins()
        {
            foreach (var skinGameObject in _view.SkinGameObjects)
            {
                skinGameObject.SetActive(false);
            }
        }
        
        private void DeactivateCurrentSkin()
        {
            if (TryGetCurrentSkinGameObject(_currentSkinIndex, out var skinGameObject))
            {
                skinGameObject.SetActive(false);
                _currentSkinIndex = NoSkinIndex;
            }
        }
    }
}