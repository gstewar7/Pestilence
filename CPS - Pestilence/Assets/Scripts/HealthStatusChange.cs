using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStatusChange : MonoBehaviour
{

    Animator healthAnim;

    private float healthCount;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        healthAnim = GetComponent<Animator>();
        healthAnim.updateMode = AnimatorUpdateMode.UnscaledTime;
        healthCount = player.GetComponent<Player>().currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthCount = player.GetComponent<Player>().currentHealth;

        if(healthCount >= 0 && healthCount <= 25.0)
        {
            healthAnim.SetTrigger("DangerStatus");
        }
        if(healthCount <= 59.0 && healthCount >= 26.0)
        {
            healthAnim.SetTrigger("CautionStatus");
        }
        else
        {
            healthAnim.SetTrigger("HealthyStatus");
        }
    }
}
