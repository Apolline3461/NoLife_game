using UnityEngine;
using UnityEngine.SceneManagement;


// This script is for a button behavior of the menu in Unity.


public class ButtonBehavior : MonoBehaviour
{
    // This method is called when the button is clicked.
    public void LaunchGame()
    {
        Debug.Log("Game launched!");
        SceneManager.LoadScene("playerDemoMovement");
    }

    // This method is called when the button is hovered over.
    public void LaunchSettings()
    {
        Debug.Log("Settings launched!");
    }

    // This method is called when the button is no longer hovered over.
    public void ExitGame()
    {
        Debug.Log("Game exited!");
        Application.Quit();
    }
}