using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tesint : MonoBehaviour
{
    bool ispressed;
    float rotSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ispressed)
        {
            transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        }
    }
    public void enter()
    {
        ispressed = true; 
    }
    public void exit()
    {
        ispressed = false;
    }
}
