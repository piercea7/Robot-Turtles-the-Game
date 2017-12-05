using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
    public void HotSeatPlayButton(string gameBoard)
    {
        SceneManager.LoadScene(gameBoard);
    }
    public void backButton(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
    }
    public void CreateLobbyButton(string CreateGame)
    {
        SceneManager.LoadScene(CreateGame);
    }
    public void JoinLobbyButton(string JoinGame)
    {
        SceneManager.LoadScene(JoinGame);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
