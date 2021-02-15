using FlaxEngine;

namespace Game
{
    public class EnemyController : Script
    {
        public JsonAsset Defaults;
        public Enemy Enemy;

        public override void OnStart()
        {
            Enemy = new Enemy((Defaults)Defaults.CreateInstance());
        }
    }
}
