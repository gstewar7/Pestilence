using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float currentHealth = 100;
    private Animator anim;
    private float temp;
    // Start is called before the first frame update
    void Start()
    {
        
        temp = currentHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth < temp)
        {
            anim.SetTrigger("Hit");
            temp = currentHealth;
        }
    }
}
