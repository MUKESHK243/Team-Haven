using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectOrbs : MonoBehaviour
{
    public float orbsValue = .5f;
    public float power;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       power = gameManager.powerBar.value += orbsValue;
        Destroy(other.gameObject,0.1f);
        Debug.Log(power);
    }
}
