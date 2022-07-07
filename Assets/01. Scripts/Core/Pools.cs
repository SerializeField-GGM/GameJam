using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Pools<T> where T : PoolableMono
    {
        private Stack<T> pool = new Stack<T>();
        private T prefab = null;
        private Transform parent;

        public Pools(T prefab, Transform parent)
        {
            this.prefab = prefab;
            this.parent = parent;
        }

        public T Pop()
        {
            T temp = null;

            if(pool.Count > 0)
            {
                temp = pool.Pop();
                temp.gameObject.SetActive(true);
            }
            else
            {
                temp = GameObject.Instantiate(prefab, parent);
                temp.name = temp.name.Replace("(Clone)", null);
            }

            temp.Reset();
            return temp;
        }

        public void Push(T obj)
        {
            obj.gameObject.SetActive(false);
            pool.Push(obj);
        }
    }
}
