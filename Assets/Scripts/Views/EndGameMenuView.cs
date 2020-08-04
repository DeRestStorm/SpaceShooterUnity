using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class EndGameMenuView : MonoBehaviour, IEndGameMenuView
    {
        [SerializeField] private Button _restartButton;
        public Button RestartButton => _restartButton;
        [SerializeField] private Button _toMainMenuButton;
        public Button ToMainMenuButton => _toMainMenuButton;
        [SerializeField] private AudioSource _backgroundMusic;


        public void Show()
        {
            gameObject.SetActive(true);
        }
    }

    public interface IEndGameMenuView
    {
        void Show();
        Button RestartButton { get; }
        Button ToMainMenuButton { get; }
    }
}