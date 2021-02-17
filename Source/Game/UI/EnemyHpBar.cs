using System;
using System.Collections.Generic;
using FlaxEngine;
using FlaxEngine.GUI;

namespace Game
{
    public class EnemyHpBar : Script
    {
        private Actor _enemyController;
        private ProgressBar _progressBar;
        public UIControl BarControl;
        public Camera Camera;  

        public void Init(ReactiveProperty<float> Hp, Actor enemyController)
        {
            _progressBar = BarControl.Get<ProgressBar>();
            _enemyController = enemyController;
            Hp.Changed += OnHpChanged;
            OnHpChanged(Hp.Value);
            Actor.Parent.Direction = -Camera.Direction;
        }

        private void OnHpChanged(float newValue)
        {
            _progressBar.Value = newValue;
        }
    }
}
