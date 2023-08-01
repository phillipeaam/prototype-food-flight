using Assets.Scripts.Base;
using Assets.Scripts.PlayerControl;
using Assets.Scripts.Pooler;
using UnityEngine;

namespace Assets.Scripts.Initializer
{
    public class InitializerView : SelfControlledBehaviour<InitializerController>, IInitializerView
    {
        [SerializeField]
        private PlayerControlView _playerControlView;
        public IPlayerControlView PlayerControlView => _playerControlView;
        
        [SerializeField]
        private PoolerView _poolerView;
        public IPoolerView PoolerView => _poolerView;

        protected override void Configure()
        {
            Controller = new InitializerController(this);
        }
    }
}