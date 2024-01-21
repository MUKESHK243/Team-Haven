using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public HingeJoint door;

    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<HingeJoint>();

    }

    void Update()
    {
    }
    public void OpeningDoor()
    {
        if (door != null)
        {
            door.useSpring = false;
            door.useLimits = false;
            Invoke("MakeKinetic", 1);

        }
    }

    void MakeKinetic()
    {
        door.GetComponent<Rigidbody>().isKinematic = true;

    }
}
