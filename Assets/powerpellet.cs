using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerpellet : pellets
{
    public float duration = 3f;
    // Start is called before the first frame update
    protected override void Eat()
    {
        FindObjectOfType<Gamemanager>().PowerPelletEaten(this);
    }
}
