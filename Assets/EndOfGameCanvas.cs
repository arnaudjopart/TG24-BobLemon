
using UnityEngine;


public class EndOfGameCanvas : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;

    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public CanvasGroup exitBackgroundImageCanvasGroup;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;

    float m_Timer;


    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }


    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
    {
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;
    }

    public void ShowLoseScreen()
    {
        m_IsPlayerCaught = true;
    }

    public void ShowWinScreen()
    {
        m_IsPlayerAtExit = true;
    }
}
