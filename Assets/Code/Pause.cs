using UnityEngine;

public class PauseGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Toggle time scale between 0 and 1
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
            }
            else
            {
                Time.timeScale = 0f;
            }
        }
    }
}
