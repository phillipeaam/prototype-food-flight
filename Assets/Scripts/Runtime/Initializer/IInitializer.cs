using Assets.Scripts.PlayerControl;

namespace Assets.Scripts.Initializer
{
    public interface IInitializer
    {
        IPlayerControl PlayerControl { get; }
    }
}