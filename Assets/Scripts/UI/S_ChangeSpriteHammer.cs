using System;
using UnityEngine;

public class S_ChangeSpriteHammer : MonoBehaviour
{
    public Sprite sp1, sp2;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            GetComponent<SpriteRenderer>().sprite = sp1;
        
        if(Input.GetKeyDown(KeyCode.Q))
            GetComponent<SpriteRenderer>().sprite = sp2;
    }
}
