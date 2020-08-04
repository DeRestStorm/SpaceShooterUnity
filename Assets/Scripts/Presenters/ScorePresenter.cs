using Components;
using Helpers;
using UnityEngine;
using Views;

namespace Presenters
{
    public class ScorePresenter : MonoBehaviour
    {
        private int _score;
        private IScoreView _view;
        [SerializeField] public Health _playerHealth;

        private void Start()
        {
            _view = GetComponent<IScoreView>();
            _score = SaveHelper.LoadScore();
            _view.RenderScore(_score);
            _playerHealth.OutOfHealth += Save;
        }

        public void AddScore(int score)
        {
            _score += score;
            _view.RenderScore(_score);
        }

        private void Save()
        {
            SaveHelper.SaveScore(_score);
        }
    }
}