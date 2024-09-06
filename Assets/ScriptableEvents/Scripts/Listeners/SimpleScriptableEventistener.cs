using UnityEngine;
using UnityEngine.Events;

public class SimpleScriptableEventistener : MonoBehaviour
{
    public UnityEvent m_event;
    public SimpleScriptableEvent m_listener;

    private void OnEnable()
    {
        m_listener.Subscribe(this);
    }
    private void OnDisable()
    {
        m_listener.UnSubscribe(this);
    }

    internal void OnRaiseEvent()
    {
        m_event.Invoke();
    }
}