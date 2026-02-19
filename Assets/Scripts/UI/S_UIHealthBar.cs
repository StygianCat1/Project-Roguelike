using UnityEngine;
using UnityEngine.UI;

public class S_UIHealthBar : MonoBehaviour
{
    
    [SerializeField] public float health = 100f;
    [SerializeField] public float maxhealth = 100f;
    public Image healthBarImage;
    private S_HP_Component _playerHealth;

    private void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<S_HP_Component>();
        maxhealth = _playerHealth._maxHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        health = _playerHealth._currentHealth;
        healthBarImage.fillAmount = health / maxhealth;
    }
}
