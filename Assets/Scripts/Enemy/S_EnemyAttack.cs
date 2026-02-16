using UnityEngine;

public class S_EnemyAttack : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCharacter" && other.GetComponent<S_HP_Component>() != null)
        {
            other.GetComponent<S_HP_Component>().TakeDamage(damage);
        }
    }
}
