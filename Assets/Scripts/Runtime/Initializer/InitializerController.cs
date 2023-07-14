using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Runtime.Base;
using Assets.Scripts.Runtime.PlayerControl;

namespace Assets.Scripts.Runtime.Initializer
{
    public class InitializerController : IController
    {
        private readonly List<IController> _controllers;
        
        public InitializerController(IInitializer initializer)
        {
            _controllers = new()
            {
                new PlayerController(initializer.PlayerControl)
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