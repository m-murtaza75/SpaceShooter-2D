/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: Main Menu of the game. First thing that player will see on launching the game. 
*/


using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
		// Below commented code is used for quitting game when playing in unity editor
		// Must be kept commented when building project or errors occur
		
        //if(UnityEditor.EditorApplication.isPlaying == true)
        //{
        //    UnityEditor.EditorApplication.isPlaying = false;
        //}
        //else
        //{
        //    Application.Quit();
        //}
		
		// Used to quit game in mobile device (tested for android device)
        Application.Quit();

    }
}
