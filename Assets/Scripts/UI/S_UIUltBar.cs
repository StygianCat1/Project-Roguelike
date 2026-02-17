using System;
using UnityEngine;
using UnityEngine.UI;

public class S_UIUltBar : MonoBehaviour


{

    [SerializeField] public float ultBar = 0f;
    [SerializeField] public float maxUltBar = 100f;
    public Image ultBarImage;
    
    [SerializeField] private Animator _animator;

    public bool Test;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        {
            ultBar = Mathf.Clamp(ultBar, 0f, maxUltBar);
            ultBarImage.fillAmount = ultBar / maxUltBar;
        }
        if (Test)
        {
            _animator.SetTrigger("UltReady");
        }
    }
    
    public void DownUltButton(int damageAmount)
    {
        ultBar -= damageAmount;
    }
    
    public void UpUltButton(int healAmount)
    {
        ultBar += healAmount;
    }
}
