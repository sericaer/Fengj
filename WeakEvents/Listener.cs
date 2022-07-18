using System;
using System.Reflection;

namespace WeakEvents
{
    public class Listener<T>
    {
        public bool isAlive => weakReference.IsAlive;


        private WeakReference weakReference;
        private MethodInfo method;

        public Listener(Action<T> action)
        {
            weakReference = new WeakReference(action.Target);
            method = action.Method;
        }

        public void Raise(params object[] datas)
        {
            method.Invoke(weakReference.Target, datas);
        }
    }
}