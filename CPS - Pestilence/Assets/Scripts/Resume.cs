using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public GameObject menu;
    

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    public void TaskOnClick()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
}
