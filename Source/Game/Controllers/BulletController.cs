using System.Threading.Tasks;
using FlaxEngine;

namespace Game
{
    public class BulletController : Script, IPoolable
    {
        public void OnPoolRent()
        {
            Actor.IsActive = true;   
        }

        public async Task OnPoolReturn()
        {
            Actor.IsActive = false;
        }
    }
}
