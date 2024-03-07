// GhostMovement.cs
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float speed = 3f;
    private Transform player; 

    void Start()
    {
        GameObject pacmanObject = GameObject.FindGameObjectWithTag("Pacman");

        if (pacmanObject != null)
        {
            player = pacmanObject.transform;
        }
        else
        {
            Debug.LogError("Player not found. Make sure to set the correct tag for the player.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // R�knar direktionen till playern
            Vector3 direction = player.position - transform.position;

            // Normalize s� att speed �r samma
            direction.Normalize();

            // G� till playern
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
