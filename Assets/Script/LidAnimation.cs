using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidAnimation : MonoBehaviour
{
    public static bool animate;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animate = false;
        animator = GetComponent<Animator>();

    }
    void Awake()
    {
        animate = false;
    }

    void Update()
    {
        if (animate)
        {
           
            animator.Play("openlid");
            animate = false;
        }
        
        
        
    }
}
