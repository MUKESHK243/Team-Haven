using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public BasicMovement movement;
    public GameObject victory;

    private void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Win")
        {
            movement.enabled = false;
            victory.SetActive(true);
        }
        
    }
}
