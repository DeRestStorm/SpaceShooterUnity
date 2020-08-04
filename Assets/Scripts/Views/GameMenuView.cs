using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class GameMenuView : MonoBehaviour, IGameMenuView
    {
        [SerializeField] public Button _restartButton;
        public Button RestartButton => _restartButton;
        [SerializeField] public Button _toMainMenuButton;
        public Button ToMainMenuButton => _toMainMenuButton;
    }

    public interface IGameMenuView
    {
        Button RestartButton { get; }
        Button ToMainMenuButton { get; }
    }
}