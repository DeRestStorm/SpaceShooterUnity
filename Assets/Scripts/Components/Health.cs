using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class Health : MonoBehaviour, IHealth
    {
        private float _baseHealth;
        public float Amount { get; private set; }
        public Action<float> OnChange { get; set; }
        public UnityAction OutOfHealth { get; set; } = delegate { };


        [SerializeField] public UnityEvent _onOutOfHealthEvent;

        private void Start()
        {
            if (_onOutOfHealthEvent == null)
                _onOutOfHealthEvent = new UnityEvent();
            _onOutOfHealthEvent.AddListener(OutOfHealth);
        }

        public void SetHealth(float health)
        {
            _baseHealth = health;
            Amount = health;
            OnChange?.Invoke(Amount);
        }


        public void Reset()
        {
            Amount = _baseHealth;
        }

        public void Damage(float damage)
        {
            Amount -= damage;

            if (Amount <= 0)
            {
                Amount = 0;
                _onOutOfHealthEvent.Invoke();
            }

            OnChange?.Invoke(Amount);
        }
    }

    public interface IHealth
    {
        float Amount { get; }
        Action<float> OnChange { get; set; }
        void Damage(float damage);
        void SetHealth(float health);
        UnityAction OutOfHealth { get; set; }
        void Reset();
    }
}