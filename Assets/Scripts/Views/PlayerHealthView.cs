using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class PlayerHealthView : MonoBehaviour, IHealthView
    {
        [SerializeField] private Text _textField;
        public void RenderHealth(float healthAmount)
        {
            _textField.text = "Health: " + healthAmount.ToString(CultureInfo.InvariantCulture);
        }
    }

    public interface IHealthView
    {
        void RenderHealth(float healthAmount);
    }
}