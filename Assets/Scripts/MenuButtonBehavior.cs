using UnityEngine;
using UnityEngine.SceneManagement;

// This script is for a button behavior of the menu in Unity.

public class ButtonBehavior : MonoBehaviour
{
    [Header("Scene Settings")]
    public string sceneToLoad; // Set this from the Unity Inspector

    // This method is called when the button is clicked.
    public void LaunchGame()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            Debug.Log("Game launched! Loading scene: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("No scene specified to load.");
        }
    }

    // This method is called when the button is hovered over.
    public void LaunchSettings()
    {
        Debug.Log("Settings launched!");
        // Optional: Load a settings scene or show a panel
    }

    // This method is called when the button is no longer hovered over.
    public void ExitGame()
    {
        Debug.Log("Game exited!");
        Application.Quit();
    }
}
