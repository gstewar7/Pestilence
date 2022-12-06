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
    public Transform myPlayer;
    private bool hasLighter;

    
    public GameObject message; 
	// Start is called before the first frame update
	void Start()
	{
        GameObject child = transform.GetChild(0).gameObject;
        thisRend = child.GetComponent<Renderer>();
        hasLighter = myPlayer.GetComponent<Player>().hasLighter;
        //thisRend = GetComponentInChildren<Renderer>();
        message.SetActive(false);
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
            
            hasLighter = myPlayer.GetComponent<Player>().hasLighter;
            if(hasLighter)
            {
                Player.sigilCount -= 1;
                Debug.Log("Sigil Burned");
                Pressed = true;
                lockedDoor.addPress();
                doorSigil.SetActive(true);
                Burn();
                Debug.Log("Pressed");
                //StartCoroutine(Wait());
                StartCoroutine(Burn());
                StartCoroutine(Wait());
            }
            else{
                StartCoroutine(NeedLighter());
            }
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
    IEnumerator NeedLighter()
    {
        message.SetActive(true);
       // StartCoroutine(Wait());
        yield return new WaitForSeconds(2f);
        Debug.Log("Finished");
        message.SetActive(false);
    }
}

