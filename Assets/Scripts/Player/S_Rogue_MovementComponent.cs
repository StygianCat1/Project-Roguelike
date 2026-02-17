using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class S_Rogue_MovementComponent : MonoBehaviour
{
    [SerializeField] private float _moveSmoothTime = 0.1f;
    [SerializeField] private float _movementSpeed = 10.0f;
    
    [SerializeField] private float _jumpHeight = 5.0f;
    [SerializeField] private float _gravityScale = 5.0f;
    
    [SerializeField] private float _backDashPower = 12.0f;
    [SerializeField] private float _backDashDuration = 0.1f;
    [SerializeField] private float _backDashCooldown = 0.5f;
    [SerializeField] private float _dashPower = 24.0f;
    [SerializeField] private float _dashDuration = 0.2f;
    [SerializeField] private float _dashCooldown = 1.0f;
    
    public GameObject _characterRef;
    
    private S_Rogue_Inputs _inputsManager;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private S_Rogue_Combat _combat;
    
    private Vector3 _currentMoveVelocity;
    private Vector3 _moveDampVelocity;

    private float _jumpSecurity = 0.05f;
    private float _jumpVelocity;
    [HideInInspector] public float _directionCharacter = 1;
    
    [HideInInspector]public bool _canJump = true;

    private bool _canDash = true;
    [HideInInspector] public bool isDashing;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _inputsManager = GetComponent<S_Rogue_Inputs>();
        _animator = GetComponent<Animator>();
        _combat = GetComponent<S_Rogue_Combat>();
    }

    // Update is called once per frame
    private void Update()
    {
        GetCharacterDirection();
        CharacterFaceDirection();
        if (isDashing || _combat.isAttacking || _combat.isShooting || _combat.isUsingCapacity)
        {
            return;
        }
        //Debug.Log("pomme de terre");
        Movement();
        Jump();
        Dash();
    }

    private void Movement()
    {
        Vector3 MoveVector = transform.TransformDirection(new Vector3 (_inputsManager.moveX, 0, 0));
        _currentMoveVelocity = Vector3.SmoothDamp(_currentMoveVelocity, MoveVector * _movementSpeed, ref _moveDampVelocity, _moveSmoothTime);
        _animator.SetFloat("MoveX", _inputsManager.moveX);
        transform.Translate(_currentMoveVelocity * Time.deltaTime, Space.World);
    }

    private void CharacterFaceDirection()
    {
        _characterRef.transform.LookAt(new Vector3(_characterRef.transform.position.x + _directionCharacter, _characterRef.transform.position.y, _characterRef.transform.position.z));
    }

    private void Jump()
    {
        _jumpVelocity += Physics.gravity.y * _gravityScale * Time.deltaTime;
        Ray groundCheckRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(groundCheckRay, out RaycastHit groundHit, 1f))
        {
            _jumpVelocity = 0;
            if (!_canJump)
            {
                Invoke(nameof(ResetJump), _jumpSecurity);
            }
        }
        if (_inputsManager.jump && _canJump)
        {
            _animator.SetTrigger("Jump");
            _jumpVelocity = Mathf.Sqrt(_jumpHeight * -2.5f * ( Physics.gravity.y * _gravityScale));
            _canJump = false;
        } 
        transform.Translate(new Vector3 (0, _jumpVelocity, 0) * Time.deltaTime, Space.World);
    }

    private void ResetJump()
    {
        _canJump = true;
    }

    private void Dash()
    {
        Ray groundCheckRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(groundCheckRay, out RaycastHit groundHit, 1.1f))
        {
            if (_inputsManager.dash && _canDash )
            {
                StartCoroutine(DashCoroutine());
                _inputsManager.dash = false;
                return;
            }
            if (_inputsManager.dash && !_canDash)
            {
                _inputsManager.dash = false;
            }
        }
    }

    private void GetCharacterDirection()
    {
        if (_inputsManager.moveX != 0)
        {
            _directionCharacter = _inputsManager.moveX;
        }
    }

    private IEnumerator DashCoroutine()
    {
        _canDash = false;
        isDashing = true;
        if (_inputsManager.moveX == 0)
        {
            _rigidbody.linearVelocity = new Vector3(- _directionCharacter * _backDashPower, 0.1f, 0f);
            _animator.SetTrigger("BackDash");
            yield return new WaitForSeconds(_backDashDuration);
            _rigidbody.linearVelocity = new Vector3(0f, 0f, 0f);
            isDashing = false;
            yield return new WaitForSeconds(_backDashCooldown);
        }
        else
        {
            _rigidbody.linearVelocity = new Vector3(_inputsManager.moveX * _dashPower, 0.1f, 0f);
            _animator.SetTrigger("Dash");
            yield return new WaitForSeconds(_dashDuration);
            _rigidbody.linearVelocity = new Vector3(0f, 0f, 0f);
            isDashing = false;
            yield return new WaitForSeconds(_dashCooldown);
        }
        _canDash = true; 
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(this.transform.position, transform.position + new Vector3(0,- 1f, 0));
    }
}
