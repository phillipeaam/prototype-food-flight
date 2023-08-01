using System.Threading.Tasks;
using Assets.Scripts.Base;
using UnityEngine;
using static Assets.Scripts.Pooler.Utils.Delegates;

namespace Assets.Scripts.PlayerControl
{
    public class PlayerController : IController
    {
        private const string WarningMessage = "The pool with tag \"{0}\" doesn't exist.";
        
        private readonly IPlayerControlView _view;
        
        public event RetrieveInstanceFromPoolDelegate OnRequestInstanceFromPool;

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

            var tag = _view.ProjectileTag;
            var position = _view.SourceTransform.position;
            var rotation = Quaternion.identity;
            
            OnRequestInstanceFromPool?.Invoke(tag, position, rotation);
        }
    }
}
