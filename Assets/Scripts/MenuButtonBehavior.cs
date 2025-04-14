using UnityEngine;
using UnityEngine.SceneManagement;


// This script is for a button behavior of the menu in Unity.


public class ButtonBehavior : MonoBehaviour
{
    // This method is called when the button is clicked.
    public void LaunchGame()
    {
        Debug.Log("Game launched!");
        // Load the game scene (assuming it's named "GameScene")
        SceneManager.LoadScene("SampleScene");
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