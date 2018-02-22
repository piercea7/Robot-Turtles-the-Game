/*Author: Michael Majercak
 * Date: Febuary 22, 2018
 * Description: This script is designed to load and transition through different scenes.
 *              Depending on which button is clicked, it will load the scene it is set 
 *              transition to.
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
    public static int numPlayers;
    public void HotSeatPlayButton(string hotSeat)
    {
        SceneManager.LoadScene(hotSeat);
    }
    public void hotSeatNumPlayers(int numP)
    {
        numPlayers = numP;
        SceneManager.LoadScene("gameBoard");
        numPlayers = numP;
    }
    public void backButton(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
    }
    public void CreateLobbyButton(string CreateGame)
    {
        SceneManager.LoadScene(CreateGame);
    }
    public void HelpButton(string HelpScreen)
    {
        SceneManager.LoadScene(HelpScreen);
    }
    public void JoinLobbyButton(string JoinGame)
    {
        SceneManager.LoadScene(JoinGame);
    }
    public void GameOptionsButton(string GameOptions)
    {
        SceneManager.LoadScene(GameOptions);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
