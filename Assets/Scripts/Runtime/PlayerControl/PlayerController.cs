using System.Numerics;
using System.Threading.Tasks;
using Assets.Scripts.Runtime.Base;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Assets.Scripts.Runtime.PlayerControl
{
    public class PlayerController : IController
    {
        private readonly IPlayerControl _playerControl;

        public PlayerController(IPlayerControl playerControl)
        {
            _playerControl = playerControl;
        }

        public Task Initialize()
        {
            _playerControl.OnUpdatePosition += UpdatePosition;
            return Task.CompletedTask;
        }

        public Task Dispose()
        {
            _playerControl.OnUpdatePosition -= UpdatePosition;
            return Task.CompletedTask;
        }
        
        private void UpdatePosition()
        {
            // If there is no input, do not move
            if (_playerControl.InputDirection == 0)
                return;
        
            // Calculates the translation step
            var translationStep = _playerControl.InputDirection * _playerControl.Speed * Time.deltaTime;
            // Translates the player in the world space
            _playerControl.SourceTransform.Translate(translationStep, 0, 0, Space.World);

            // Cache the current position
            var position = _playerControl.SourceTransform.position;
            
            // Clamps the player position to the limits
            var clampedXPosition = Mathf.Clamp(
                position.x,
                -_playerControl.PositionRangeLimit, 
                _playerControl.PositionRangeLimit);
    
            // Makes sure the player is not out of bounds
            _playerControl.SourceTransform.position = new Vector3(clampedXPosition, position.y, position.z);
        }
    }
}
