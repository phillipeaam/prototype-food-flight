using System.Threading.Tasks;

namespace Assets.Scripts.Base
{
    public interface IController
    {
        public Task Initialize();
        
        public Task Dispose();
    }
}