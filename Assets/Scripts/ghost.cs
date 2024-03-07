using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public movement Movementt {  get; private set; }
    

    public Transform target;
    public int points = 100;

    private void Awake()
    {
        this.Movementt = GetComponent<movement>();
       
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.Movementt.ResetState();

    }
    
}
