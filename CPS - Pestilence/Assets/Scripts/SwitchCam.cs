using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    public Transform Player;
    public Camera thisCam;
    // Start is called before the first frame update
    void Start()
    {
       thisCam = this.gameObject.GetComponentInChildren<Camera>();
       // thisCam =  transform.GetChild(0).GetComponent<Camera>();
        Debug.Log(thisCam.name);
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
             foreach (var cam in Camera.allCameras) {
                cam.enabled = false;
            }
            thisCam.enabled = true;
        }
    }
}
