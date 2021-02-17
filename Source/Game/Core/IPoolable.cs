using System.Threading.Tasks;

namespace Game
{
    public interface IPoolable
    {
        void OnPoolRent();
        Task OnPoolReturn();
    }
}
