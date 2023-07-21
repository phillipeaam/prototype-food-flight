using Assets.Scripts.Base;
using Assets.Scripts.PlayerControl;
using UnityEngine;

namespace Assets.Scripts.Initializer
{
    public class InitializerView : SelfControlledView<InitializerController>, IInitializer
    {
        [SerializeField]
        private PlayerControlView _playerControlView;
        public IPlayerControl PlayerControl => _playerControlView;

        protected override void Configure()
        {
            Controller = new InitializerController(this);
        }
    }
}