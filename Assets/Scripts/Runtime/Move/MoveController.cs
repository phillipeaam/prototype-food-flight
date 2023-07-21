using System.Threading.Tasks;
using Assets.Scripts.Base;
using UnityEngine;

namespace Assets.Scripts.Move
{
    public class MoveController : IController
    {
        private readonly IMove _view;

        public MoveController(IMove view)
        {
            _view = view;
        }

        public Task Initialize()
        {
            _view.OnMove += MoveToDirection;
            return Task.CompletedTask;
        }

        public Task Dispose()
        {
            _view.OnMove -= MoveToDirection;
            return Task.CompletedTask;
        }
        
        private void MoveToDirection()
        {
            _view.SourceTransform.Translate(_view.Speed * Time.deltaTime * _view.Direction);
        }
    }
}