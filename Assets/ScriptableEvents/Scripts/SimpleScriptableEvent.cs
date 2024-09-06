using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Custom/Event")]
public class SimpleScriptableEvent : ScriptableObject
{
    private List<SimpleScriptableEventistener> _list = new List<SimpleScriptableEventistener>();
   public void Subscribe(SimpleScriptableEventistener _event)
    {
        _list.Add(_event);
    }

    public void UnSubscribe(SimpleScriptableEventistener _event)
    {
        _list.Remove(_event);
    }

    public void Raise()
    {
        for(var i= _list.Count-1; i>=0; i--)
        {
            _list[i].OnRaiseEvent();
        }
    }
}
