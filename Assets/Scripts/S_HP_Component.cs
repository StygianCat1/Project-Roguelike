using UnityEngine;

public class S_HP_Component : MonoBehaviour
{
    public int _currentHealth;
    [SerializeField] private GameObject GameOverCanvas;
    
    private S_CountingScore _countingScore;
    
    private Animator _animator;
    
    [HideInInspector] public int _maxHealth = 100;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _currentHealth = _maxHealth;
        _countingScore = GameObject.FindGameObjectWithTag("GUI").GetComponent<S_CountingScore>();
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (gameObject.tag != "Player")
        {
            _countingScore.PointsPunchEnemies();
        }
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
        if (gameObject.tag == "MainCharacter")
        {
            Instantiate(GameOverCanvas);
            return;
        }
        _animator.SetBool("DeathAnim", true);
        gameObject.GetComponent<S_EnemyAi>().isDead = true;
        Invoke(nameof(GiveRewardAtDeath), 2f);
    }

    private void GiveRewardAtDeath()
    {
        _countingScore.PointsKillEnemies();
        gameObject.GetComponent<S_DropRateOnEnemy>().DropMoney();
        Invoke(nameof(DestroyGameObject), 0.1f);
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
