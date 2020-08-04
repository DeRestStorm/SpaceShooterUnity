using System.Security.Policy;
using Components;
using Config;
using Presenters;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Factories
{
    public class AsteroidFactory : MonoBehaviour, IPoolingObjectFactory
    {
        public GameObject[] Asteroids;
        public EnemyData EnemyData;
        public ScorePresenter ScorePresenter;

        private void Awake()
        {
            var levelConfig = FindObjectOfType<LevelConfig>();
            if (levelConfig != null)
                EnemyData = levelConfig.LevelData.EnemyData;
        }

        public GameObject Create(Transform parent)
        {
            var asteroid = Asteroids[Random.Range(0, Asteroids.Length)];
            var instance = Instantiate(asteroid, parent);
            instance.SetActive(false);
            instance.GetComponent<IHealth>().SetHealth(EnemyData.Health);
            instance.GetComponent<Mover>().Speed = EnemyData.Speed;
            instance.GetComponent<IAttack>().SetAttack(EnemyData.Damage);
            var scorePoints = instance.GetComponent<ScorePoints>();
            scorePoints.Count = EnemyData.ScorePoints;
            scorePoints.Take += ScorePresenter.AddScore;
            instance.transform.rotation = Quaternion.identity;
            instance.transform.SetParent(parent);
            return instance;
        }
    }

    public interface IPoolingObjectFactory
    {
        GameObject Create(Transform parent);
    }
}