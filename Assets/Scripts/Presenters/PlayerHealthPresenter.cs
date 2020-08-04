using Components;
using UnityEngine;
using Views;

namespace Presenters
{
    [RequireComponent(typeof(IHealthView))]
    public class PlayerHealthPresenter : MonoBehaviour
    {
        [SerializeField] private IHealthView _healthView;

        [SerializeField] private Health _health;

        private void Start()
        {
            _healthView = GetComponent<IHealthView>();
            _healthView.RenderHealth(_health.Amount);
            _health.OnChange += healthAmount => { _healthView.RenderHealth(healthAmount); };
        }
    }
}