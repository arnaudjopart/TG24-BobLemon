using System.Collections.Generic;
using UnityEngine;

public class GenericScriptableEvent<T> : ScriptableObject
{
    private List<GenericScriptableEventListener<T>> _list = new List<GenericScriptableEventListener<T>>();
    public void Subscribe(GenericScriptableEventListener<T> _event)
    {
        _list.Add(_event);
    }

    public void Unsubscribe(GenericScriptableEventListener<T> _event)
    {
        _list.Remove(_event);
    }

    public void Raise(T _value)
    {
        for (var i = _list.Count - 1; i >= 0; i--)
        {
            _list[i].OnRaiseEvent(_value);
        }
    }
}

[CreateAssetMenu(menuName = "Scriptable Event/Vector3 Event")]

public class Vector3ScriptableEvent : GenericScriptableEvent<Vector3>
{

}

[CreateAssetMenu(menuName = "Scriptable Event/Float Event")]

public class FloatScriptableEvent : GenericScriptableEvent<float>
{

}

[CreateAssetMenu(menuName = "Scriptable Event/Int Scriptable Event")]
public class IntScriptableEvent : GenericScriptableEvent<int>
{

}
