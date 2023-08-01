using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Base;
using Assets.Scripts.PlayerControl;
using Assets.Scripts.Pooler;

namespace Assets.Scripts.Initializer
{
    public class InitializerController : IController
    {
        private readonly PlayerController _playerController;
        private readonly PoolerController _poolerController;
        
        private readonly List<IController> _controllers;
        
        public InitializerController(IInitializerView view)
        {
            _playerController = new PlayerController(view.PlayerControlView);
            _poolerController = new PoolerController(view.PoolerView);

            _controllers = new()
            {
                _playerController,
                _poolerController
            };
        }

        public async Task Initialize()
        {
            _playerController.OnRequestInstanceFromPool += _poolerController.SpawnFromPool;
            
            var tasks = _controllers
                .Select(x => x.Initialize())
                .ToArray();
            
            await Task.WhenAll(tasks);
        }

        public async Task Dispose()
        {
            _playerController.OnRequestInstanceFromPool -= _poolerController.SpawnFromPool;
            
            var tasks = _controllers
                .Select(x => x.Dispose())
                .ToArray();
            
            await Task.WhenAll(tasks);
        }
    }
}