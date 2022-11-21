using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private CharacterController myController;
    public float speed = 1.6f;
    private float defaultSpeed = 1.6f;
    public float runSpeed = 3f;
    public float rotationSpeed = 100f;
    public Animator anim;
    public float currentHealth = 100;
    private float temp;
    
    // Start is called before the first frame update
    void Start()
    {
        temp = currentHealth;
        myController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Vertical");
        float y = Input.GetAxisRaw("Horizontal");
        float r = Input.GetAxisRaw("Run");

        if(r > 0)
        {
            speed = runSpeed;
            anim.SetBool("isRunning", true);
        }
        else
        {
            speed = defaultSpeed; 
            anim.SetBool("isRunning", false);
        }
        Vector3 moveDir = new Vector3(0f,0f,0f);

        if(x > 0)
        {
            //Debug.Log("X");
            moveDir = transform.forward * x * speed;
        }
        else
        {
            moveDir = transform.forward * x * (speed * 0.6f);
            if(Input.GetButtonDown("Jump"))
            {
                transform.Rotate(0, 180f, 0);
                if(r == 0)
                {
                    anim.SetTrigger("slowTurn");
                }
            }
        }
        Vector3 rotate = new Vector3(0,0, y);

        // if(currentHealth < temp)
        // {
        //     anim.SetTrigger("Hit");
        //     temp = currentHealth;
        // }
        myController.Move(moveDir*Time.deltaTime-Vector3.up*0.1f);

        transform.Rotate(0, y * rotationSpeed *Time.deltaTime, 0 );

        if(x != 0 || y != 0)
        {   
            //Debug.Log("a");
            anim.SetBool("isWalking",true);
        }
        else
            anim.SetBool("isWalking",false);
    }
}
