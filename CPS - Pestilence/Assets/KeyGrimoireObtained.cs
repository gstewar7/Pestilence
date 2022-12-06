using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGrimoireObtained : MonoBehaviour
{
    public GameObject keyGrimoireItemObject;

    public Transform player;

    public GameObject myManager;

    private bool grimoireObtained;


    private bool menuOpened;

    //public Player Player { get => player; set => player = value; }

    // Start is called before the first frame update
    void Start()
    {
        keyGrimoireItemObject.SetActive(false);

        grimoireObtained = player.GetComponent<Player>().hasBook;

        menuOpened = myManager.GetComponent<GameManager>().menuOpen;
    }

    // Update is called once per frame
    void Update()
    {
        if(menuOpened != true)
        {
            grimoireObtained = false;
        }
        else
        {
            grimoireIsObtained(grimoireObtained);
        }
    }

    void grimoireIsObtained(bool grimoire)
    {
        if (grimoire == true)
        {
            keyGrimoireItemObject.SetActive(true);
        }
    }
}
