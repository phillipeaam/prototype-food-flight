using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.Base
{
    public interface IController
    {
        public Task Initialize();
        
        public Task Dispose();
    }
}