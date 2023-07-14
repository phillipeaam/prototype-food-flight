using Assets.Scripts.Runtime.PlayerControl;

namespace Assets.Scripts.Runtime.Initializer
{
    public interface IInitializer
    {
        IPlayerControl PlayerControl { get; }
    }
}