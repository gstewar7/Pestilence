using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pentagram : MonoBehaviour
{
	private bool InZone = false;
    public Renderer thisRend;
    public float minimum = 0f;
    public float maximum =  1.0f;
    float progress = 1f;
    public Transform Player;
    public bool hasBook;
    public GameObject message; 
    public GameObject endScreen;
	// Start is called before the first frame update
	void Start()
	{
        GameObject child = transform.GetChild(0).gameObject;
        thisRend = child.GetComponent<Renderer>();
        hasBook = Player.GetComponent<Player>().hasBook;
        //thisRend = GetComponentInChildren<Renderer>();
        message.SetActive(false);
        endScreen.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
        
        if (Input.GetKeyDown(KeyCode.E) && InZone)
        {
            
            hasBook = Player.GetComponent<Player>().hasBook;
            if(hasBook)
            {
                Burn();
                //Debug.Log("Pressed");
                //StartCoroutine(Wait());
                StartCoroutine(Burn());
                StartCoroutine(Wait());
                //endScreen.SetActive(true);
                SceneManager.LoadScene("PestilenceEnding");

            }
            else{
                StartCoroutine(NeedBook());
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
    IEnumerator NeedBook()
    {
        message.SetActive(true);
       // StartCoroutine(Wait());
        yield return new WaitForSeconds(2f);
        Debug.Log("Finished");
        message.SetActive(false);
    }
}

