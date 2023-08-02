using System.Threading.Tasks;
using Assets.Scripts.Base;

namespace Assets.Scripts.Pooler.Utils.HideWhenOutOfBounds
{
    public class HideWhenOutOfBoundsController : IController
    {
        private readonly IHideWhenOutOfBoundsView _view;

        public HideWhenOutOfBoundsController(IHideWhenOutOfBoundsView view)
        {
            _view = view;
        }

        public Task Initialize()
        {
            _view.OnDeactivateGameObject += DeactivateGameObject;
            
            return Task.CompletedTask;
        }

        public Task Dispose()
        {
            _view.OnDeactivateGameObject -= DeactivateGameObject;
            
            return Task.CompletedTask;
        }
        
        private void DeactivateGameObject()
        {
            if (_view.SourceTransform is null || _view.SourceGameObject is null)
            {
                return;
            }
            
            var positionZ = _view.SourceTransform.position.z;
            
            if (positionZ > _view.TopBound || positionZ < _view.BottomBound)
            {
                _view.SourceGameObject.SetActive(false);
            }
        }
    }
}