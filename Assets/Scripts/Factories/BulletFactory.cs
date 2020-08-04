using System.Security.Policy;
using Components;
using Config;
using Presenters;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Factories
{
    public class BulletFactory : MonoBehaviour, IPoolingObjectFactory
    {
        public GameObject[] Bulets;

        public GameObject Create(Transform parent)
        {
            var bullet = Bulets[Random.Range(0, Bulets.Length)];
            var instance = Instantiate(bullet, parent);
            instance.SetActive(false);
            instance.transform.rotation = Quaternion.identity;
            instance.transform.SetParent(parent);
            return instance;
        }
    }
}