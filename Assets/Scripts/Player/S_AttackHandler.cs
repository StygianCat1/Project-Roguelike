using System;
using UnityEngine;

public class S_AttackHandler : MonoBehaviour
{
    [SerializeField] S_Rogue_MovementComponent s_Rogue_MovementComponent;
    public int _basicAttackDamage;
    private float _characterDir;

    private void Start()
    {
        s_Rogue_MovementComponent = gameObject.GetComponentInParent<S_Rogue_MovementComponent>();
    }

    private void Update()
    {
        _characterDir = s_Rogue_MovementComponent._directionCharacter;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.GetComponent<S_HP_Component>() != null)
        {
            other.GetComponent<S_HP_Component>().TakeDamage(_basicAttackDamage);
            other.GetComponent<S_EnemyAi>().Knockback(new Vector3(_characterDir, 0, 0));
        }
    }
}
