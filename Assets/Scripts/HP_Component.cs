using UnityEngine;

public class HP_Component : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
    }

    public void Heal(int heal)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + heal, 0, _maxHealth);
    }
}
