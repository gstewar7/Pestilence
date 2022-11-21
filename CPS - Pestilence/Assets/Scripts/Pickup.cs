using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform Player;
    //Script playerScript;
    void Start()
    {
        Player.GetComponent<Player>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                //playerScript.hasLighter = true;
                Player.GetComponent<Player>().hasLighter = true;
                Object.Destroy(this.gameObject);
            }
        }
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
