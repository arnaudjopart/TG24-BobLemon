using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerLife : MonoBehaviour
{
    public int m_lifes;

    public IntScriptableEvent m_event;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            m_lifes--;
            m_event.Raise(m_lifes);
        }
    }
}
