using UnityEngine;

public class MainController : BaseUIController
{
    public void OnStart()
    {
        m_gameManager.StartNewGame();
    }

    public void OnQuit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
            Application.OpenURL(webplayerQuitURL);
        #else
            Application.Quit();
        #endif
    }

    public void OnCredits()
    {

    }

    public override void OnQuitContext()
    {
        Debug.Log("Yeah I hear you");
        OnQuit();
    }
}
