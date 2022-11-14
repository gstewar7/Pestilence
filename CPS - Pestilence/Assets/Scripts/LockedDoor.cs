using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private bool InZone = false;
    private bool InOpened = false;
    private bool Unlocked = false;
    private int Locks = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Locks >= 4 && Unlocked == false)
        {
            Unlocked = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && InZone && Unlocked)
        {
            InOpened = !InOpened;
            if (InOpened) GetComponent<Animation>().Play("OpenInteriorDoor");
            else GetComponent<Animation>().Play("CloseInteriorDoor");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InZone = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InZone = false;
        }
    }
    public void addPress()
    {
        Locks += 1;
    }
}
