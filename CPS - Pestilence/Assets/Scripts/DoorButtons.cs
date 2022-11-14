using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtons : MonoBehaviour
{
	private bool InZone = false;
    private bool Pressed = false;
    public LockedDoor lockedDoor;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
        if (Input.GetKeyDown(KeyCode.E) && InZone && Pressed)
        {
            // Button is already pressed so no work needed
        } 
        else if (Input.GetKeyDown(KeyCode.E) && InZone)
        {
            Pressed = true;
            lockedDoor.addPress();
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
}
