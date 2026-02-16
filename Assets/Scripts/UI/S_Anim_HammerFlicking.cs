using System;
using UnityEngine;

public class S_Anim_HammerFlicking : MonoBehaviour
{
   
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("UltReady");
            }
    }
}
