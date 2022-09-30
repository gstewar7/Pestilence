using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
 {
    public Transform Player;
     public float enemyCooldown = 1;
     public float damage = 20;
 
     public bool playerInRange = false;
     public bool canAttack = true;
     public Animator anim;
    
    void Start()
    {
        
        anim = GetComponent<Animator>();
        playerInRange = false;
    }
     private void Update()
     {
         if (playerInRange && canAttack)
         {
             Player.GetComponent<Player>().currentHealth -= damage;
             anim.Play("Attack");
             StartCoroutine(AttackCooldown());
         }
     }
 
     void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("Player"))
          {
             playerInRange = true;
         }
     }
     void OnTriggerExit(Collider other)
     {
         if (other.gameObject.CompareTag("Player"))
          {
             playerInRange = false;
         }
     }
     IEnumerator AttackCooldown()
     {
         canAttack = false;
         yield return new WaitForSeconds(enemyCooldown);
         canAttack = true;
     }
 }