using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pellets : MonoBehaviour
{
    public int points = 5;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Eat();
        }
    }
    protected virtual void Eat()
    {
        FindObjectOfType<Gamemanager>().PelletEaten(this);
    }

}
