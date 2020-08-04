using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventByTime : MonoBehaviour
{
    public float Time;
    public UnityEvent Event;

    public void Run()
    {
        Invoke(nameof(Invoke), Time);
    }

    private void Invoke()
    {
        Event.Invoke();
    }
}