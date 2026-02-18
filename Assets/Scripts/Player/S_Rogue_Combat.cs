using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_Rogue_Combat : MonoBehaviour
{
    private S_Rogue_Inputs _inputsManager;
    private S_Rogue_MovementComponent _movementComponent;
    [SerializeField] private S_AttackHandler _attackHandler;
    private S_Rogue_Bonus _rogueBonus;
    private Animator _animator;

    public float _capacityCooldown;
    private float _capacityTimer;

    [SerializeField] private float _gunRange;
    public int gunAmmunitions;
    
    public Collider _attackCollider;
    
    [SerializeField] private int _basicAttackDamage;
    [SerializeField] private int _gunAttackDamage;
    [SerializeField] private GameObject _kaoriForCapacity;
    [SerializeField] private int _capacityAttackDamage;
    
    public bool isAttacking;
    public bool isShooting;
    public bool isUsingCapacity;
    public bool canUseCapacity;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _attackHandler._basicAttackDamage = _basicAttackDamage; 
        _inputsManager = GetComponent<S_Rogue_Inputs>();
        _movementComponent = GetComponent<S_Rogue_MovementComponent>();
        _rogueBonus = GetComponent<S_Rogue_Bonus>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!canUseCapacity)
        {
            CapacityTimerHandler();
        }
        if (isAttacking || isShooting || isUsingCapacity || _movementComponent.isDashing || !_movementComponent._canJump)
        {
            return;
        }
        UseAttack();
        UseGun();
        UseCapacity();
    }

    private void UseAttack()
    {
        if (_inputsManager.attack)
        {
            isAttacking = true;
            _animator.SetTrigger("Attack");
            Invoke(nameof(UseAttackCollision), 1f);
            _inputsManager.attack = false;
        }
        _inputsManager.attack = false;
    }

    private void UseAttackCollision()
    {
        _attackCollider.enabled = true;
        Invoke(nameof(StopAttackCollision), 0.1f);
        Debug.Log("atta");
    }

    private void StopAttackCollision()
    {
        _attackCollider.enabled = false;
        isAttacking = false;
    }

    private void UseGun()
    {
        if (_inputsManager.shoot && gunAmmunitions > 0)
        {
            isShooting = true;
            _animator.SetTrigger("Gun");
            Invoke(nameof(UseGunShoot), 0.5f);
            _inputsManager.shoot = false;
        }
    }

    private void UseGunShoot()
    {
        Ray EnemyCheckRay = new Ray(transform.position, new Vector3(transform.position.x + (1 * _movementComponent._directionCharacter) * _gunRange, transform.position.y, transform.position.z));
        if (Physics.Raycast(EnemyCheckRay, out RaycastHit enemyHit))
        {
            if (enemyHit.collider.gameObject.tag == "Enemy")
            {
                Debug.Log("touched");
                enemyHit.collider.GameObject().GetComponent<S_HP_Component>().TakeDamage(_gunAttackDamage);
            }
            
        }
        isShooting = false;
        if (_rogueBonus.luckyshotRate >= Random.Range(1,101))
        {
            Debug.Log("luckyshot");
            return;
        }
        gunAmmunitions -= 1;
    }

    private void UseCapacity()
    {
        if (_inputsManager.useCapacity && canUseCapacity)
        {
            canUseCapacity = false;
            GameObject kaoriGameObject = Instantiate(_kaoriForCapacity, transform.position + new Vector3(_movementComponent._directionCharacter,0,0), _movementComponent._characterRef.transform.rotation);
            kaoriGameObject.GetComponent<S_KaoriAttackHandler>()._kaoriAttackDamage = _capacityAttackDamage;
            _inputsManager.useCapacity = false;
            _capacityTimer = _capacityCooldown;
            return;
        }
        _inputsManager.useCapacity = false;
    }

    private void CapacityTimerHandler()
    {
        _capacityTimer -= Time.deltaTime;
        if (_capacityTimer <= 0)
        {
            canUseCapacity = true;
        }
    }
}


