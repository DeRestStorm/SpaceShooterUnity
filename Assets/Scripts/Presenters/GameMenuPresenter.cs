using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views;

namespace Presenters
{
    [RequireComponent(typeof(IGameMenuView))]
    public class GameMenuPresenter : MonoBehaviour
    {
        private IGameMenuView _view;

        private void Start()
        {
            _view = GetComponent<IGameMenuView>();
            _view.RestartButton.onClick.AddListener(() => { SceneManager.LoadScene(1); });
            _view.ToMainMenuButton.onClick.AddListener(() => { SceneManager.LoadScene(0); });
        }
    }
}