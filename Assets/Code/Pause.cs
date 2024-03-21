using UnityEngine;
using TMPro;

public class PauseGame : MonoBehaviour
{
    public TextMeshProUGUI pauseText; // Reference to the TextMeshPro component


    void Awake() {
        DontDestroyOnLoad(gameObject);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))      // call TogglePause when P is pressed
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (Time.timeScale == 0f)   // if paused set time to 1
        {
            Time.timeScale = 1f;
            if (pauseText != null)
            {
                pauseText.text = ""; // Clear the text when the game is resumed
            }
        }
        else
        {
            Time.timeScale = 0f;        // if not paused set time to 0
            if (pauseText != null)
            {
                pauseText.text = "* Paused *"; // Set the text to "Paused" when the game is paused
            }
        }
    }
}
