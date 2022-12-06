using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLighterObtained : MonoBehaviour
{
    public GameObject keyLighterItemObject;

    public GameObject player;

    private bool lighterObtained;

    public GameObject myManager;


    private bool menuOpened;

    //public Player Player { get => player; set => player = value; }

    // Start is called before the first frame update
    void Start()
    {
        keyLighterItemObject.SetActive(false);

        lighterObtained = player.GetComponent<Player>().hasLighter;

        menuOpened = myManager.GetComponent<GameManager>().menuOpen;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Player>().hasLighter == true)
        {
            if (menuOpened != true)
            {
                lighterObtained = false;
            }
            else
            {
                lighterIsObtained(lighterObtained);
                //keyLighterItemObject.SetActive(true);
            }
        }

        /*if (menuOpened != true)
        {
            lighterObtained = false;
        }
        else
        {
            lighterIsObtained(lighterObtained);
            //keyLighterItemObject.SetActive(true);
        }
        //lighterIsObtained(lighterObtained);*/
    }

    void lighterIsObtained(bool lighter)
    {
        if (lighter == true) {
            keyLighterItemObject.SetActive(true);
        }
    }

}
