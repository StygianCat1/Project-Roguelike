using System;
using UnityEngine;
using UnityEngine.AI;
using Random = Unity.Mathematics.Random;

public class S_EnemyAi : MonoBehaviour
{
    private  NavMeshAgent _agent; 
    private Transform _player;
    private S_HP_Component _health;
    
    [SerializeField] private GameObject _characterPrefab;
    
    [SerializeField] private Vector3 _walkPoint;
    [SerializeField] private float _walkPointRange = 1f;
    
    [SerializeField] private float _timeBetweenAttacks;
    
    private bool _walkPointSet;
    private bool _alreadyAttacked;
    
    [SerializeField] private float _sightRange = 10f, _attackRange = 1f;
    [SerializeField] private bool _playerInSight, _playerInAttackRange;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("MainCharacter").transform;
        _agent = GetComponent<NavMeshAgent>();
        _health = GetComponent<S_HP_Component>();
    }

    private void Update()
    {

        bool checkSight = Physics.CheckSphere(transform.position, _sightRange, LayerMask.GetMask("Player"));
        if (checkSight)
        {
            if (transform.position.y <= _player.position.y + 3f && transform.position.y >= _player.position.y - 3f) _playerInSight = checkSight;
        }
        _playerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, LayerMask.GetMask("Player"));

        if (!_playerInSight && !_playerInAttackRange) Patroling();
        if (_playerInSight && !_playerInAttackRange) ChasePlayer();
        if (_playerInSight && _playerInAttackRange) AttackPlayer();
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
        
    }

    private void SearchWalkPoint()
    {
        float randomX = UnityEngine.Random.Range(-_walkPointRange, _walkPointRange);
        
        _walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z);
        
        if (Physics.Raycast(_walkPoint, -transform.up, 2f))
        {
            _walkPointSet = true;
        }
        _characterPrefab.transform.LookAt(new Vector3(_walkPoint.x, transform.position.y, transform.position.z));
    }
    
    private void ChasePlayer()
    {
        Debug.Log("Chasing player");
        _agent.SetDestination(_player.position);
    }
    
    private void AttackPlayer()
    {
        Debug.Log("Attacking player");
        _agent.SetDestination(transform.position);
        
        transform.LookAt(new Vector3(_player.position.x, transform.position.y, transform.position.z));

        if (!_alreadyAttacked)
        {
            //AttackCodeHere
            
            
            
            //
            _alreadyAttacked = true;
            Invoke(nameof(ResetAttack), _timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        _alreadyAttacked = false;
    }
}
