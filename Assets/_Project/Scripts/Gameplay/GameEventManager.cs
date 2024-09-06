using System;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static Action<Vector3> OnPlayerDetection;

    public static void InvokeOnPlayerDetection(Vector3 _playerPosition)
    {
        OnPlayerDetection?.Invoke(_playerPosition);
    }
}
