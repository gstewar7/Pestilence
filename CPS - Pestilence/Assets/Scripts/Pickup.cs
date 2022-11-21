using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform Player;
    public GameObject message; 
    private bool inZone;
    [SerializeField]
    private bool hasLighter;
    //Script playerScript;
    void Start()
    {
        //Player.GetComponent<Player>();
        hasLighter = Player.GetComponent<Player>().hasLighter;
        message.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inZone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inZone = false;
        }
    }
    // private void OnTriggerStay(Collider other)
    // {
    //     if(other.CompareTag("Player"))
    //     {
    //         if(Input.GetKeyDown(KeyCode.E) && !hasLighter)
    //         {
    //             StartCoroutine(Wait());
    //         }
    //     }
    // }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(inZone)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                StartCoroutine(Wait());
            }
        }
    }
    IEnumerator Wait()
    {
        hasLighter = true;
        message.SetActive(true);
       // StartCoroutine(Wait());
        yield return new WaitForSeconds(2f);
        Debug.Log("Finished");
        message.SetActive(false);
        Object.Destroy(this.gameObject);
    }
}
