using Assets.Scripts.PlayerControl;
using Assets.Scripts.Pooler;

namespace Assets.Scripts.Initializer
{
    public interface IInitializerView
    {
        IPlayerControlView PlayerControlView { get; }
        IPoolerView PoolerView { get; }
    }
}