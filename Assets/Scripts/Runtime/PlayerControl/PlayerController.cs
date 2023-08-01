using System.Threading.Tasks;
using Assets.Scripts.Base;
using UnityEngine;

namespace Assets.Scripts.PlayerControl
{
    public class PlayerController : IController
    {
        private readonly IPlayerControlView _view;

        public PlayerController(IPlayerControlView view)
        {
            _view = view;
        }

        public Task Initialize()
        {
            _view.OnUpdatePosition += UpdatePosition;
            _view.OnHandleProjectileLaunch += HandleProjectileLaunch;
            return Task.CompletedTask;
        }

        public Task Dispose()
        {
            _view.OnUpdatePosition -= UpdatePosition;
            _view.OnHandleProjectileLaunch -= HandleProjectileLaunch;
            return Task.CompletedTask;
        }
        
        private void UpdatePosition()
        {
            // If there is no input, do not move
            if (_view.InputDirection == 0)
                return;
        
            // Calculates the translation step
            var translationStep = _view.InputDirection * _view.Speed * Time.deltaTime;
            // Translates the player in the world space
            _view.SourceTransform.Translate(translationStep, 0, 0, Space.World);

            // Cache the current position
            var position = _view.SourceTransform.position;
            
            // Clamps the player position to the limits
            var clampedXPosition = Mathf.Clamp(
                position.x,
                -_view.PositionRangeLimit, 
                _view.PositionRangeLimit);
    
            // Makes sure the player is not out of bounds
            _view.SourceTransform.position = new Vector3(clampedXPosition, position.y, position.z);
        }
        
        private void HandleProjectileLaunch()
        {
            if (!_view.InputFire)
                return;
            
            Object.Instantiate(_view.ProjectilePrefab, _view.SourceTransform.position, Quaternion.identity);
        }
    }
}
