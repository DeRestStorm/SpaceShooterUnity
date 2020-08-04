using ScriptableObjects;
using UnityEngine;

namespace Config
{
    public class LevelConfig : MonoBehaviour
    {
        public LevelData LevelData { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void SetLevelData(LevelData data)
        {
            LevelData = data;
        }
    }
}