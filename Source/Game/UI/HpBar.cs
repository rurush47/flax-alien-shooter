using FlaxEngine;
using FlaxEngine.GUI;

namespace Game
{
    public class HpBar : Script
    {
        private ProgressBar _progressBar;
        public UIControl BarControl;

        public void Init(ReactiveProperty<float> Hp)
        {
            _progressBar = BarControl.Get<ProgressBar>();
            Hp.Changed += OnHpChanged;
            OnHpChanged(Hp.Value);
        }

        private void OnHpChanged(float newValue)
        {
            _progressBar.Value = newValue;
        }

        public override void OnEnable()
        {
            // Here you can add code that needs to be called when script is enabled (eg. register for events)
        }

        public override void OnDisable()
        {
            // Here you can add code that needs to be called when script is disabled (eg. unregister from events)
        }

        public override void OnUpdate()
        {
            // Here you can add code that needs to be called every frame
        }
    }
}
