using System;
using System.Collections.Generic;
using Factories;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(IPoolingObjectFactory))]
    public class ObjectPool : MonoBehaviour
    {
        public int Size;
        private IPoolingObjectFactory _factory;
        private readonly Queue<GameObject> _queue = new Queue<GameObject>();

        private void Awake()
        {
            _factory = GetComponent<IPoolingObjectFactory>();
            for (var i = 0; i < Size; i++)
            {
                _queue.Enqueue(Create());
            }
        }


        private GameObject Create()
        {
            var instance = _factory.Create(transform);

            instance.GetComponent<IPoolingObject>().OnDestruction += (pollingObject) =>
            {
                pollingObject.SetActive(false);
                pollingObject.transform.parent = transform;
                pollingObject.transform.position = Vector3.zero;
                pollingObject.transform.rotation = Quaternion.identity;
                _queue.Enqueue(pollingObject);
            };
            return instance;
        }

        public GameObject GetObject()
        {
            if (_queue.Count > 0)
                return _queue.Dequeue();
            return Create();
        }
    }
}