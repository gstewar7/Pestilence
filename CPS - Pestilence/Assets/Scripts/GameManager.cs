using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject keyLighterItemObject;

    public GameObject keyGrimoireItemObject;

    public GameObject player;

    private bool hasLighter;

    private bool hasGrimoire;

    public GameObject menu;
    public bool menuOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        hasLighter = player.GetComponent<Player>().hasLighter;

        hasGrimoire = player.GetComponent<Player>().hasBook;
       menu.SetActive(false);  
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Player>().currentHealth > 0.0 && Input.GetKeyDown(KeyCode.Escape))
        {
            if(!menuOpen)
            {
                hasLighter = player.GetComponent<Player>().hasLighter;
                hasGrimoire = player.GetComponent<Player>().hasBook;
                Time.timeScale = 0;
                menu.SetActive(true);
                menuOpen = true;
                lighterIsObtained(hasLighter);
                grimoireIsObtained(hasGrimoire);
            }
            else{
                Time.timeScale = 1;
                menu.SetActive(false);
                menuOpen = false;
            }
        }
        
    }

    void grimoireIsObtained(bool grimoire)
    {
        if (hasGrimoire)
        {
            if (keyGrimoireItemObject.activeSelf == false)
            {
                keyGrimoireItemObject.SetActive(true);
            }
        }
        else
        {
            keyGrimoireItemObject.SetActive(false);
        }
    }

    void lighterIsObtained(bool lighter)
    {
        if (hasLighter)
        {
            if(keyLighterItemObject.activeSelf == false)
            {
                keyLighterItemObject.SetActive(true);
            }
            
        }
        else
        {
            keyLighterItemObject.SetActive(false);
        }
    }
}
