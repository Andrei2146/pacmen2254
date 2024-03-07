using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private void Start()
    {
        // Attach the button click event dynamically
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(RestartGame);
        }
    }

    private void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
