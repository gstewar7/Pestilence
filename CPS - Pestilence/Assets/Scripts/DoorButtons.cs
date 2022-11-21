using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtons : MonoBehaviour
{
	private bool InZone = false;
    private bool Pressed = false;
    public LockedDoor lockedDoor;
    public GameObject doorSigil;    
    public Renderer thisRend;
    public float minimum = 0f;
    public float maximum =  1.0f;
    float progress = 1f;
    public Transform Player;

	// Start is called before the first frame update
	void Start()
	{
        GameObject child = transform.GetChild(0).gameObject;
        thisRend = child.GetComponent<Renderer>();
        //thisRend = GetComponentInChildren<Renderer>();
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
            doorSigil.SetActive(true);
            Burn();
            Debug.Log("Pressed");
            //StartCoroutine(Wait());
            StartCoroutine(Burn());
            StartCoroutine(Wait());
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

    IEnumerator Wait()
    {
        
        Debug.Log("Wait called");
        yield return new WaitForSeconds(2);
        Object.Destroy(this.gameObject);
    }
    IEnumerator Burn()
    {
        Debug.Log("Burn called");
        
        while(progress > 0f)
        {
            progress -= 0.3f * Time.deltaTime;
            thisRend.material.SetFloat("_Progress", progress);
            yield return null;
        }
    }

}

