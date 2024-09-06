using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public int playerLayer;

    [SerializeField] private SimpleScriptableEvent _OnPlayerWinEvent;
    [SerializeField] private SimpleScriptableEvent _OnPlayerLoseEvent;


    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            _OnPlayerWinEvent.Raise();
        }
    }

    public void CaughtPlayer ()
    {
        _OnPlayerLoseEvent.Raise();
    }
}
