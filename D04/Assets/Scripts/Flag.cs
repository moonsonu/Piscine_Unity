using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public Sonic sonic;
    //private Sonic sonic;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //sonic = GetComponent<Sonic>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sonic.isFinish)
            animator.SetBool("flag", true);
        if (!sonic.isFinish)
            animator.SetBool("flag", false);
    }
}
