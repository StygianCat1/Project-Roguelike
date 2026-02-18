using UnityEngine;

public class S_KaoriAttackHandler : MonoBehaviour
{
    [SerializeField] S_Rogue_MovementComponent s_Rogue_MovementComponent;
    public int _kaoriAttackDamage;
    private bool _isAttacking;
    [SerializeField] Collider attackCollider;

    private void Start()
    {
        s_Rogue_MovementComponent = gameObject.GetComponentInParent<S_Rogue_MovementComponent>();
        Invoke(nameof(StartColliding), 0.5f);
        Destroy(gameObject, 1f);
        
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
