using System.Collections.Generic;
using System.Linq;
using Components;
using UnityEngine;
using UnityEngine.Events;

public class DamageByContact : MonoBehaviour, IAttack
{
    [SerializeField] public List<string> IgnoreTags = new List<string>();
    private float _attack = 1;
    public UnityAction OnDestruction { get; } = delegate { };

    [SerializeField] public UnityEvent _onDestructionEvent;

    void Start()
    {
        IgnoreTags.Add("Boundary");
        if (_onDestructionEvent == null)
            _onDestructionEvent = new UnityEvent();
        _onDestructionEvent.AddListener(OnDestruction);
    }

    void OnTriggerEnter(Collider other)
    {
        if (IgnoreTags.Any(other.CompareTag))
            return;

        var otherHealth = other.GetComponent<IHealth>();
        if (otherHealth != null)
        {
            otherHealth.Damage(_attack);
            _onDestructionEvent.Invoke();
        }
    }

    public void SetAttack(float attack)
    {
        _attack = attack;
    }
}

public interface IAttack
{
    void SetAttack(float attack);
}