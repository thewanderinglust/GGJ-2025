using UnityEngine;

public class TitleController : MonoBehaviour
{
    public void OnStart()
    {

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

    public void OnQuitContext()
    {
        Debug.Log("Yeah I hear you");
        OnQuit();
    }
}
