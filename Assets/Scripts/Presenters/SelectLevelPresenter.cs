using Config;
using Helpers;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Views;

namespace Presenters
{
    [RequireComponent(typeof(ISelectLevelView))]
    public class SelectLevelPresenter : MonoBehaviour
    {
        private ISelectLevelView _view;
        public LevelData LevelData;

        private void Start()
        {
            _view = GetComponent<ISelectLevelView>();
            GetComponent<Button>().onClick.AddListener(StartLevel);
            var level = SaveHelper.LoadLevel(LevelData.Number);
            _view.SetState(level.State);
        }


        private void StartLevel()
        {
            var levelConfig = FindObjectOfType<LevelConfig>();
            if (levelConfig == null)
            {
                levelConfig = new GameObject("LevelConfig", typeof(LevelConfig)).GetComponent<LevelConfig>();
            }

            levelConfig.SetLevelData(LevelData);
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }
    }
}