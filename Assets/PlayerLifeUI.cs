using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLifeUI : MonoBehaviour
{
    private TMP_Text m_text;
    void Start()
    {
        m_text = GetComponent<TMP_Text>();
    }

    public void UpdatePlayerHealth(int _value)
    {
        m_text.SetText("Player Life:" + _value);
    }
}
