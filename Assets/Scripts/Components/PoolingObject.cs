using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class PoolingObject : MonoBehaviour, IPoolingObject
    {
        public Action<GameObject> OnDestruction { get; set; }

        public void ReturnToPool()
        {
            OnDestruction?.Invoke(gameObject);
        }
    }

    public interface IPoolingObject
    {
        Action<GameObject> OnDestruction { get; set; }
        void ReturnToPool();
    }
}