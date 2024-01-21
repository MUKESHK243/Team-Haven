using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CloneObjects : MonoBehaviour
{
    [SerializeField] CollectOrbs collectOrbs;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform startPoint;
    [SerializeField] GameObject parentObject;

    GameManager gameManager;
    private void Start()
    {
        gameManager =  FindObjectOfType<GameManager>();
        
    
    }
    private void Update()
    {

        DuplicatePlayer();
    }
    void DuplicatePlayer()
    {
        collectOrbs = gameManager.players[gameManager.currentIndex].GetComponent<CollectOrbs>();
        if (collectOrbs.power >= 1 && Input.GetKeyDown(KeyCode.E))
        {
           gameManager.powerBar.value = 0;
            GameObject clone = Instantiate(playerPrefab, transform);
            clone.transform.position = new Vector3(gameManager.players[0].transform.position.x - 2, gameManager.players[0].transform.position.y, gameManager.players[0].transform.position.z);
            
            gameManager.players.Add(clone);
            collectOrbs.power = 0;
        }
    }


}
