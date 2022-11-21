using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteUi : MonoBehaviour
{
    public GameObject noteMessage;
    public GameObject note; 
    [SerializeField]
    private bool InZone = false;
    [SerializeField]
    private bool readingNote = false;
    [SerializeField]
    private bool readingMessage = false;
    // Start is called before the first frame update
    void Start()
    {
        noteMessage.SetActive(false);
        note.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    { 
        if(Input.GetKeyDown(KeyCode.E) && InZone)
        {
            if(!readingMessage && !readingNote)
            {
                readingMessage = true;
                noteMessage.SetActive(true);
                Time.timeScale = 0;
            }
            else if(readingMessage && !readingNote)
            {
                readingMessage = false;
                readingNote = true;
                noteMessage.SetActive(false);
                note.SetActive(true);
            }
            else if(!readingMessage && readingNote)
            {
                readingNote = false;
                note.SetActive(false);
                Time.timeScale = 1;
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
}
