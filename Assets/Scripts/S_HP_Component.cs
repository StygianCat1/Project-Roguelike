using UnityEngine;

public class S_HP_Component : MonoBehaviour
{
    public int _currentHealth;    
    
    [SerializeField] private int _maxHealth = 100;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
        if (_currentHealth <= 0)
        {
            Death();
        }
    }

    public void Heal(int heal)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + heal, 0, _maxHealth);
    }

    private void Death()
    {
        if (gameObject.tag == "Player")
        {
            /// add UI + death screen + stop time, etc...
            return;
        }
        Destroy(gameObject);
    }
}
