using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
    public class Enemy : CoreActor
    {
        public Enemy(Defaults defaults)
        {
            Hp = new ReactiveProperty<float>(defaults.InitHpEnemy);
        }
    }
}
