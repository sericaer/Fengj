using System;
using System.Collections.Generic;

namespace WeakEvents
{
    public class Publisher<T>
    {
        public IEnumerable<Listener<T>> listeners => _listeners;

        private List<Listener<T>> _listeners = new List<Listener<T>>();

        public void AddListener(Action<T> action)
        {
            _listeners.Add(new Listener<T>(action));
        }

        public void Raise(T data)
        {
            var index = 0;
            while (index < _listeners.Count)
            {
                var curr = _listeners[index];
                if (curr.isAlive)
                {
                    curr.Raise(data);
                    index++;
                }
                else
                {
                    _listeners.RemoveAt(index);
                }
            }
        }

        public void Clear()
        {
            _listeners.Clear();
        }
    }
}
