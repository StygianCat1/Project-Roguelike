using System;
using TMPro;
using UnityEngine;

public class S_BulletsCount : MonoBehaviour
{
    public TMP_Text bulletText;
    private S_Rogue_Combat _rogueCombat;

    private void Start()
    {
        _rogueCombat = GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<S_Rogue_Combat>();
    }

    // Update is called once per frame
    private void Update()
    {
        bulletText.text = " X " + _rogueCombat.gunAmmunitions.ToString();  
    }
    
}
