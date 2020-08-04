using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Components;
using Config;
using Enums;
using Helpers;
using Models;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class LevelController : MonoBehaviour
    {
        public ObjectPool EnemyPool;
        private Vector2 SpawnArea;
        private readonly float _spawnWait = .5f;
        private bool _endGame;
        public UnityEvent WinEnvet;
        public UnityEvent LoseEnvet;
        private int _timeToWin = 30;
        private Coroutine _winTimer;


        private void Start()
        {
            var cameraHelper = new CameraHelper(Camera.main);
            SpawnArea = new Vector2(cameraHelper.GetWidth() / 2, 16);
            StartCoroutine(nameof(SpawnWaves));


            var levelConfig = FindObjectOfType<LevelConfig>();
            if (levelConfig != null)
                _timeToWin = levelConfig.LevelData.TimeToWin;

            _winTimer = StartCoroutine(nameof(WinTimer));
        }

        IEnumerator WinTimer()
        {
            yield return new WaitForSeconds(_timeToWin);
            Win();
        }

        IEnumerator SpawnWaves()
        {
            while (!_endGame)
            {
                yield return new WaitForSeconds(_spawnWait);
                var asteroid = EnemyPool.GetObject();
                asteroid.GetComponent<IHealth>().Reset();
                asteroid.transform.position = new Vector3(Random.Range(-SpawnArea.x, SpawnArea.x), 0, SpawnArea.y);
                asteroid.SetActive(true);
            }
        }

        public void Win()
        {
            _endGame = true;
            FindObjectsOfType<MonoBehaviour>().OfType<IPoolingObject>().ToList()
                .ForEach(x => x.ReturnToPool());

            WinEnvet?.Invoke();
            var levelConfig = FindObjectOfType<LevelConfig>();
            if (levelConfig == null) return;

            SaveHelper.SaveLevel(new Level(levelConfig.LevelData.Number, LevelState.Passed));

            if (levelConfig.LevelData.NextLevel <= 0) return;

            var nextLevel = SaveHelper.LoadLevel(levelConfig.LevelData.NextLevel);
            if (nextLevel.State != LevelState.Сlosed) return;
            nextLevel.State = LevelState.Opened;
            
            SaveHelper.SaveLevel(nextLevel);
        }

        public void Lose()
        {
            _endGame = false;
            StopCoroutine(_winTimer);
            LoseEnvet?.Invoke();
        }
    }
}