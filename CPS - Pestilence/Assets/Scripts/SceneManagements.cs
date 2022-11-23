using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagements : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Camera c in Camera.allCameras)
        {
            if(!c.CompareTag("MainCamera"))
                c.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
