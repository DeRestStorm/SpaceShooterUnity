using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views;

namespace Presenters
{
    public class EndGameMenuPresenter : MonoBehaviour
    {
        private IEndGameMenuView _view;
        
        public void Show()
        {
            _view = GetComponentInChildren<IEndGameMenuView>(true);
            _view.RestartButton.onClick.AddListener(() => { SceneManager.LoadScene(1); });
            _view.ToMainMenuButton.onClick.AddListener(() => { SceneManager.LoadScene(0); });
            _view.Show();
        }
    }
}