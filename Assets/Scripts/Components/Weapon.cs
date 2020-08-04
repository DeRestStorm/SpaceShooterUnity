using System;
using System.Collections;
using UnityEngine;

namespace Components
{
    public class Weapon : MonoBehaviour
    {
        public float FireRate = .5f;
        public ObjectPool Pool;

        public AudioSource AudioSource;

        private void Start()
        {
            StartCoroutine(nameof(Fire));
        }

        private IEnumerator Fire()
        {
            yield return new WaitForSeconds(FireRate);

            while (true)
            {
                var bullet = Pool.GetObject();
                bullet.GetComponent<EventByTime>().Run();
                bullet.transform.position = transform.position;
                bullet.SetActive(true);


                AudioSource.Play();
                yield return new WaitForSeconds(FireRate);
            }
        }
    }
}