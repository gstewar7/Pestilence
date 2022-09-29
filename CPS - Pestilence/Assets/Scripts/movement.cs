using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private CharacterController myController;
    public float speed = 1.6f;
    private float defaultSpeed = 1.6f;
    public float runSpeed = 3f;
    public float rotationSpeed = 0.4f;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
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
        }
        else
            speed = defaultSpeed; 

        Vector3 moveDir = new Vector3(0f,0f,0f);

        if(x > 0)
        {
            moveDir = transform.forward * x * speed;
        }
        else
        {
            moveDir = transform.forward * x * (speed * 0.6f);
            if(Input.GetButtonDown("Jump"))
                transform.Rotate(0, 180f, 0);
            
        }
        Vector3 rotate = new Vector3(0,0, y);

        myController.Move(moveDir*Time.deltaTime-Vector3.up*0.1f);

        transform.Rotate(0, y * rotationSpeed, 0 );

        if(x != 0 || y != 0)
        {   
            Debug.Log("a");
            anim.Play("Walk");
        }
        else
            anim.Play("Idle");
    }
}
