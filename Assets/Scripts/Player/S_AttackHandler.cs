using System;
using UnityEngine;

public class S_AttackHandler : MonoBehaviour
{
    public int _basiAttackDamage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.GetComponent<S_HP_Component>() != null)
        {
            other.GetComponent<S_HP_Component>().TakeDamage(_basiAttackDamage);
        }
    }
}
