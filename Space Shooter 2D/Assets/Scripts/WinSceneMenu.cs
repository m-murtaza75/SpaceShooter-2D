/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: Script which response to the option selected by the player when he completes the game
*/


using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("Level1");
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
