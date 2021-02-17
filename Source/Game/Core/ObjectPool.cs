using System;
using System.Collections.Generic;

namespace Game
{
    public class ObjectPool<T> where T : IPoolable
    {
        private Func<T> _spawnMethod;
        private Stack<T> _objects = new Stack<T>();

        public ObjectPool(Func<T> spawnMethod)
        {
            _spawnMethod = spawnMethod;
        }

        public T Rent()
        {
            var newObject = _objects.Count < 1 ? _spawnMethod() : _objects.Pop();
            newObject.OnPoolRent();
            return newObject;
        }

        public async void Return(T obj)
        {
            await obj.OnPoolReturn();
            _objects.Push(obj);
        }
    }
}
