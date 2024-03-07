using UnityEngine;

public class Fruit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pacman"))
        {
            // Assuming "Pacman" is the tag of your Pacman GameObject
            Destroy(gameObject);
        }
    }
}
