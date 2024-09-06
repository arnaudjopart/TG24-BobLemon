using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceSystem : MonoBehaviour
{
    private bool m_isAlreadyPlaying;

    public void PlaySound()
    {
        if(m_isAlreadyPlaying == false)
        {
            m_isAlreadyPlaying = true;
            GetComponent<AudioSource>().Play();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
