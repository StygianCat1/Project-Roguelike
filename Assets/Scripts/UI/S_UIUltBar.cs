using System;
using UnityEngine;
using UnityEngine.UI;

public class S_UIUltBar : MonoBehaviour
{
    [SerializeField] private float ultBar = 0f;
    [SerializeField] private float maxUltBar = 100f;
    public Image ultBarImage;
    
    private Animator _animator;
    private S_Rogue_Combat _combat;

    private bool UltReady;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _combat = GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<S_Rogue_Combat>();
    }

    // Update is called once per frame
    void Update()
    {
        UltReady = _combat.canUseCapacity;
        ultBar = _combat._capacityTimer;
        maxUltBar = _combat._capacityCooldown; 
        ultBarImage.fillAmount = Math.Clamp(ultBar / maxUltBar, 0f, 1f);
        _animator.SetBool("UltReady", UltReady);
    }
}
