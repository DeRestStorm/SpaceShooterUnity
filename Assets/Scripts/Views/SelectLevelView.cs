using System;
using Enums;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class SelectLevelView : MonoBehaviour, ISelectLevelView
    {
        [SerializeField] private Image _image;
        [SerializeField] private ButtonColorScheme _colorScheme;
        [SerializeField] private Button _button;
        private ColorBlock _buttonColors;

        private void Start()
        {
            _buttonColors = _button.colors;
            _buttonColors.disabledColor = _colorScheme.Сlosed;
            _buttonColors.normalColor = _colorScheme.Opened;
            _buttonColors.highlightedColor = _colorScheme.Opened;
            _buttonColors.pressedColor = _colorScheme.Opened;
            _buttonColors.selectedColor = _colorScheme.Opened;
            _button.colors = _buttonColors;
        }

        public void SetState(LevelState state)
        {
            switch (state)
            {
                case LevelState.Сlosed:
                    _button.interactable = false;
                    // _button.colors = _buttonColors;
                    break;
                case LevelState.Passed:
                    _buttonColors.normalColor = _colorScheme.Passed;
                    
                    _buttonColors.pressedColor = _colorScheme.Passed;
                    _buttonColors.selectedColor = _colorScheme.Passed;
                    _button.colors = _buttonColors;
                    break;
            }
        }
    }

    public interface ISelectLevelView
    {
        void SetState(LevelState state);
    }
}