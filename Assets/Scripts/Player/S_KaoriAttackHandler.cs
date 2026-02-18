using UnityEngine;

public class S_KaoriAttackHandler : MonoBehaviour
{
    public int _kaoriAttackDamage;
    private bool _isAttacking;
    [SerializeField] Collider attackCollider;

    private void Start()
    {
        Invoke(nameof(StartColliding), 0.6f);
        Destroy(gameObject, 0.85f);
        
    }

    private void StartColliding()
    {
        attackCollider.enabled = true;
        _isAttacking = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_isAttacking)
        {
            return;
        }
        
        if (other.tag == "BreakableGlass")
        {
            Destroy(other.gameObject);
        }
            
        if (other.tag != "Player" && other.GetComponent<S_HP_Component>() != null)
        {
            Debug.Log("aled");
            other.GetComponent<S_HP_Component>().TakeDamage(_kaoriAttackDamage);
        }
    }
}
