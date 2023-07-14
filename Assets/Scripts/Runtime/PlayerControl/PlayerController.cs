using System.Threading.Tasks;
using Assets.Scripts.Runtime.Base;
using UnityEngine;

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
            if (_playerControl.InputDirection == 0)
                return;
            
            // Simulates lateral movement
            var translationStep = Vector3.right * (_playerControl.InputDirection * _playerControl.Speed * Time.deltaTime);
            _playerControl.SourceTransform.Translate(translationStep);
        }
    }
}
