using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;
using Random = Unity.Mathematics.Random;

public class S_EnemyAi : MonoBehaviour
{
    [SerializeField] private GameObject _characterPrefab;

    [SerializeField] private Vector3 _walkPoint;
    [SerializeField] private float _walkPointRange = 1f;

    [SerializeField] private float _timeBetweenAttacks;

    [SerializeField] private float _sightRange = 10f, _attackRange = 0.5f;

    [SerializeField] private int _enemyAttackDamage = 10;
    [SerializeField] private S_EnemyAttack _enemyAttack;
    [SerializeField] private Collider _attackCollider;
     
    
    [SerializeField] private Collider _jumpCollider;

    private NavMeshAgent _agent;
    private Transform _player;
    private Rigidbody _rb;
    private Animator _animator;
    
    private bool _walkPointSet;
    private bool _alreadyAttacked;
    private bool _playerInSight, _playerInAttackRange;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("MainCharacter").transform;
        _rb = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

    }

    private void Start()
    {
        _enemyAttack.damage = _enemyAttackDamage;
    }

    private void Update()
    {
        bool checkSight = Physics.CheckSphere(transform.position, _sightRange, LayerMask.GetMask("Player"));
        if (checkSight)
        {
            if (transform.position.y <= _player.position.y + 3f || transform.position.y >= _player.position.y - 3f)
                _playerInSight = checkSight;
        }

        _playerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, LayerMask.GetMask("Player"));
        
        if (!_playerInSight && !_playerInAttackRange)
        {
            _animator.SetBool("Walking", true);
            Patroling();
        }

        if (_playerInSight && !_playerInAttackRange)
        {
            _animator.SetBool("Walking", true);
            ChasePlayer();
        }

        if (_playerInSight && _playerInAttackRange)
        {
            _animator.SetBool("Walking", false);
            AttackPlayer();
        }
    }

    private void Patroling()
    {
        if (!_walkPointSet) SearchWalkPoint();
        else _agent.SetDestination(_walkPoint);

        Vector3 distanceToWalkPoint = transform.position - _walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            _walkPointSet = false;
        }
        //_characterPrefab.transform.LookAt(new Vector3(transform.position.x, _walkPoint.y, transform.position.z));
    }

    private void SearchWalkPoint()
    {
        float randomX = UnityEngine.Random.Range(-_walkPointRange, _walkPointRange);

        _walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z);

        if (Physics.Raycast(_walkPoint, -transform.up, 2f))
        {
            _walkPointSet = true;
        }

        transform.LookAt(new Vector3(_walkPoint.x, transform.position.y, transform.position.z));
    }

    private void ChasePlayer()
    {
        _agent.SetDestination(_player.position);
    }

    private void AttackPlayer()
    {
        _agent.SetDestination(transform.position);

        transform.LookAt(new Vector3(_player.position.x, transform.position.y, transform.position.z));

        if (!_alreadyAttacked)
        {
            _animator.SetTrigger("Attack");
            _alreadyAttacked = true;
            Invoke(nameof(BeginCollisionAttacking), 0.5f);
            Invoke(nameof(ResetAttack), _timeBetweenAttacks);
        }
    }

    private void BeginCollisionAttacking()
    {
        Debug.Log("Begin Collision Attacking");
        _attackCollider.enabled = true;
        Invoke(nameof(StopCollisionAttacking), 0.1f);
    }

    private void StopCollisionAttacking()
    {
        _attackCollider.enabled = false;
    }

    private void ResetAttack()
    {
        _alreadyAttacked = false;
    }

    public void Knockback(Vector3 knockbackDirection)
    {
        _rb.AddForce(knockbackDirection * 50f, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<S_EnemyAi>() != null || other.tag == "MainCharacter")
        {
            return;
        }
        if (other.tag == "Obstacles")
        {
            Debug.Log("canJump");
            transform.Translate(new Vector3 (-1, 10, 0) * Time.deltaTime, Space.World);
        }
    }
}
