using UnityEngine;
using UnityEngine.UI;

public class S_UIHealthBar : MonoBehaviour
{

    [SerializeField] public float health = 100f;
    [SerializeField] public float maxhealth = 100f;
    public Image healthBarImage;


    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0f, maxhealth);
        healthBarImage.fillAmount = health / maxhealth;

        
    }
    public void DamageButton(int damageAmount)
    {
            health -= damageAmount;
    }
    
    public void HealButton(int healAmount)
    {
        health += healAmount;
    }
}
