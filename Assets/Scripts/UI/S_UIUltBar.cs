using System;
using UnityEngine;
using UnityEngine.UI;

public class S_UIUltBar : MonoBehaviour


{

    [SerializeField] public float ultBar = 0f;
    [SerializeField] public float maxUltBar = 100f;
    public Image ultBarImage;
    
    [SerializeField] private Animator _animator;

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        {
            ultBar = Mathf.Clamp(ultBar, 0f, maxUltBar);
            ultBarImage.fillAmount = ultBar / maxUltBar;
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
