using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_Rogue_Combat : MonoBehaviour
{
    private S_HP_Component _characterHealthRef;
    private S_Rogue_Inputs _inputsManager;
    private S_Rogue_MovementComponent _movementComponent;
    private S_Rogue_Bonus _rogueBonus;

    [SerializeField] private List<Collider> _attackHitBoxes;

    [SerializeField] private float _capacityCooldown;
    private float _capacityTimer;

    [SerializeField] private float _gunRange;
    public int gunAmmunitions;
    
    [SerializeField] private int _basicAttackDamage;
    [SerializeField] private int _gunAttackDamage;
    [SerializeField] private int _capacityAttackDamage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _characterHealthRef = GetComponent<S_HP_Component>();
        _inputsManager = GetComponent<S_Rogue_Inputs>();
        _movementComponent = GetComponent<S_Rogue_MovementComponent>();
        _rogueBonus = GetComponent<S_Rogue_Bonus>();
    }

    // Update is called once per frame
    void Update()
    {
        UseAttack();
        UseGun();
        UseCapacity();
    }

    private void UseAttack()
    {
        if (_inputsManager.attack)
        {
            
        }
    }

    private void UseGun()
    {
        if (_inputsManager.shoot && gunAmmunitions > 0)
        {
            _inputsManager.shoot = false;
            Ray EnemyCheckRay = new Ray(transform.position, new Vector3(transform.position.x + (1 * _movementComponent._directionCharacter) * _gunRange, transform.position.y, transform.position.z));
            if (Physics.Raycast(EnemyCheckRay, out RaycastHit enemyHit))
            {
                if (enemyHit.collider.gameObject.tag == "Enemy")
                {
                    enemyHit.collider.GameObject().GetComponent<S_HP_Component>().TakeDamage(_gunAttackDamage);
                    return;
                }
            }
            if (100 - _rogueBonus.luckyshotRate <= Random.Range(0,100)){gunAmmunitions--;}
            return;
        }
        _inputsManager.shoot = false;
    }

    private void UseCapacity()
    {
        if (_inputsManager.useCapacity && _capacityTimer <= 0)
        {

            _inputsManager.useCapacity = false;
            return;
        }
        _inputsManager.useCapacity = false;
    }
}


