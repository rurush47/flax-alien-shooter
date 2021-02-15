using System;

namespace Game
{
    public class ReactiveProperty<T>
    {
        public event Action<T> Changed;
        public T Value {
            get => _value;
            set => SetValue(value);
        }
        private T _value;

        public ReactiveProperty(T value)
        {
            Value = value;
        } 

        private void SetValue(T newValue)
        {
            _value = newValue;
            Changed?.Invoke(_value);
        }
    }
}
