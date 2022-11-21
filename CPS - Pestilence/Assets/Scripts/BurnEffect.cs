using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnEffect : MonoBehaviour
{
    
    Renderer thisRend;
    public float minimum = 0f;
    public float maximum =  1.0f;
    float progress = 1f;

    // Start is called before the first frame update
    void Start()
    {
        thisRend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        progress -= 0.3f * Time.deltaTime;
        thisRend.material.SetFloat("_Progress", progress);
    }
}
