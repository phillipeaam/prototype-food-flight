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
        private readonly List<IController> _controllers;
        
        public InitializerController(IInitializerView view)
        {
            _controllers = new()
            {
                new PlayerController(view.PlayerControlView),
                new PoolerController(view.PoolerView)
            };
        }

        public async Task Initialize()
        {
            var tasks = _controllers
                .Select(x => x.Initialize())
                .ToArray();
            
            await Task.WhenAll(tasks);
        }

        public async Task Dispose()
        {
            var tasks = _controllers
                .Select(x => x.Dispose())
                .ToArray();
            
            await Task.WhenAll(tasks);
        }
    }
}