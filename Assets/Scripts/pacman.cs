using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(movement))]
public class Pacma : MonoBehaviour
{
    
    public LayerMask ghostLayer;

    private bool gameIsOver = false;
    public Canvas gameOverCanvas; 
    public TextMeshProUGUI gameOverText; 

    private movement move;

    private void Awake()
    {
        move = GetComponent<movement>();
    }

    private void Start()
    {
        // Deaktivera game over i starten
        if (gameOverCanvas != null)
        {
            gameOverCanvas.gameObject.SetActive(false);
        }

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the game is not already over and the collided object is on the Ghost layer
        if (!gameIsOver && ((1 << collision.gameObject.layer) & ghostLayer) != 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        // Gör att man får inte mera game over screens
        gameIsOver = true;

        // Printar game over i console
        Debug.Log("Game Over!");

        

        // Aktivera game over screen
        if (gameOverCanvas != null)
        {
            gameOverCanvas.gameObject.SetActive(true);
        }

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
        }

        // Freeza spelen 
        Time.timeScale = 0f;
    }

    // Blir kallad då game over button trycks
    public void RestartGame()
    {
        // Reseta time scale
        Time.timeScale = 1f;

        // Reloada scenen
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (!gameIsOver)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                move.SetDirection(Vector2.up);
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                move.SetDirection(Vector2.down);
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                move.SetDirection(Vector2.left);
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                move.SetDirection(Vector2.right);
            }

            float angle = Mathf.Atan2(move.direction.y, move.direction.x);
            transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
        }
    }
}
