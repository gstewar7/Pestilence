using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public bool menuOpen = false;
    // Start is called before the first frame update
    void Start()
    {
       menu.SetActive(false);  
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!menuOpen)
            {
                Time.timeScale = 0;
                menu.SetActive(true);
                menuOpen = true;
            }
            else{
                Time.timeScale = 1;
                menu.SetActive(false);
                menuOpen = false;
            }
        }
        
    }
}
