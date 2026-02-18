using System;
using UnityEngine;

public class S_Anim_HammerFlicking : MonoBehaviour
{
   
    Animator anim;
    public bool Test;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
            if (Test)
            {
                anim.SetTrigger("UltReady");
            }
    }
}
