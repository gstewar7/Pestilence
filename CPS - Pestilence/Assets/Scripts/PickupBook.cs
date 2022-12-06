using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBook : MonoBehaviour
{
    public Transform Player;
    public GameObject message; 
    private bool inZone;
    [SerializeField]
    private bool hasBook;
    //Script playerScript;
    void Start()
    {
        //Player.GetComponent<Player>();
        hasBook = Player.GetComponent<Player>().hasBook;
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
        hasBook = true;
        Player.GetComponent<Player>().hasBook = true;
        message.SetActive(true);
       // StartCoroutine(Wait());
        yield return new WaitForSeconds(2f);
        Debug.Log("Finished");
        message.SetActive(false);
        Object.Destroy(this.gameObject);
    }
}
