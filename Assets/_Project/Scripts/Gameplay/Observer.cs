
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Observer : MonoBehaviour, ITargetDetector
{
    public Transform player;
    public GameEnding gameEnding;

    bool m_IsPlayerInRange;
    private bool _playerIsDetected;

    public Transform Target => _playerIsDetected? player : null;

    public bool HasDetectedTarget()
    {
        return _playerIsDetected;
    }

    public void UpdateDetection(float deltaTime)
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit)) _playerIsDetected = raycastHit.collider.transform == player;
        }
        else
        {
            _playerIsDetected = false;
        }

    }

    void OnTriggerEnter (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    public void ReachTarget()
    {
        gameEnding.CaughtPlayer();
    }
}
