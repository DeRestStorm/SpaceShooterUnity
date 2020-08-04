using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ScoreView : MonoBehaviour, IScoreView
    {
        [SerializeField] private Text _coreText;

        public void RenderScore(int score)
        {
            _coreText.text = score.ToString();
        }
    }

    public interface IScoreView
    {
        void RenderScore(int score);
    }
}