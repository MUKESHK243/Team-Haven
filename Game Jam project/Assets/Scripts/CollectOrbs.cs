using UnityEngine;

public class CollectOrbs : MonoBehaviour
{
    public float orbsValue = .5f;
    public float power;
    GameManager gameManager;
    OpenDoor openDoor;
    BasicMovement movement;
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        openDoor = FindObjectOfType<OpenDoor>();
        gameManager = FindObjectOfType<GameManager>();
        movement = GetComponent<BasicMovement>();
        meshRenderer = GetComponent<MeshRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        OpeningDoor();
    }
    private void OnTriggerEnter(Collider other)
    {
        power = gameManager.powerBar.value += orbsValue;
        Destroy(other.gameObject, 0.1f);
        Debug.Log(power);
    }

    void OpeningDoor()
    {
        if (Vector3.Distance(transform.position, openDoor.transform.position) <= 8 && gameObject.tag =="Clone")
        {
            if (Vector3.Distance(transform.position, openDoor.transform.position) <= 8 && movement.isShift && Input.GetKey(KeyCode.E))
            {
                gameManager.interactButton.SetActive(false);
                meshRenderer.material = gameManager.diffuse;
                U10PS_DissolveOverTime diffuse = GetComponent<U10PS_DissolveOverTime>();
                diffuse.enabled = true;
                StartCoroutine(gameManager.ChangeCamera());
                openDoor.OpeningDoor();
            }
            gameManager.interactButton.SetActive(true);
        }
        else { gameManager.interactButton.SetActive(false); }
        

    }

}
