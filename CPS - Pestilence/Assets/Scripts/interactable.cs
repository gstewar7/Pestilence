using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Input.GetAxisRaw("Use") > 0)
            {
                Debug.Log("Using");
            }
        }
    }
}
