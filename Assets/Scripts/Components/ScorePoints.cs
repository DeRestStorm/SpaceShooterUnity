using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class ScorePoints : MonoBehaviour
    {
        public int Count;
        public Action<int> Take { get; set; } = delegate { };

        [SerializeField] private UnityEvent _takeEvent;

        private void Start()
        {
            if (_takeEvent == null)
                _takeEvent = new UnityEvent();
            _takeEvent.AddListener((() => Take.Invoke(Count)));
        }

        public void TakePoints()
        {
            _takeEvent.Invoke();
        }
    }
}