using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float currentHealth = 100;
    private Animator anim;
    private float temp;
    public bool hasLighter = false; 
    public bool hasBook = false;
    public GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
        temp = currentHealth;
        anim = GetComponent<Animator>();
        loseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth < temp)
        {
            anim.SetTrigger("Hit");
            temp = currentHealth;
        }
        if(currentHealth <= 0)
        {
            Time.timeScale = 0;
            loseScreen.SetActive(true);
        }
        
    }
}
