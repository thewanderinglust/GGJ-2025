using UnityEngine;
using Espresso.AppManagement;

public class GameManagerGGJ : GameManager
{
    public override void StartGame()
    {
        m_mainMenu.gameObject.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
