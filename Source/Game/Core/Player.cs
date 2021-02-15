using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
    public class Player : CoreActor
    { 
        public Player(Defaults defaults)
        {
            Hp = new ReactiveProperty<float>(defaults.InitHpPlayer);
            Shield = defaults.InitShielPlayer;
        }
    }
}
