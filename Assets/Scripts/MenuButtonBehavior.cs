using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class ButtonBehavior : MonoBehaviour
{
    [Header("Scene Settings")]
    public string sceneToLoad; // Set this in the Inspector

    [Header("Sound Effects")]
    public AudioClip clickSound;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    // Called when the button is clicked.
    public void LaunchGame()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            PlaySound(clickSound);
            Debug.Log("Game launched! Loading scene: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("No scene specified to load.");
        }
    }

    // Called when the button is hovered over (if using EventTrigger or PointerEnter).
    public void LaunchSettings()
    {
        PlaySound(clickSound);
        Debug.Log("Settings launched!");
    }

    // Called when the button is no longer hovered over.
    public void ExitGame()
    {
        PlaySound(clickSound);
        Debug.Log("Game exited!");
        Application.Quit();
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null) {
            audioSource.PlayOneShot(clip);
        } else {
            Debug.Log("No sounds is selected !");
        }
    }
}
