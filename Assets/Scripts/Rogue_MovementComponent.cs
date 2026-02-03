using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue_MovementComponent : MonoBehaviour
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
    
    
    private Rogue_Inputs _inputsManager;
    private Rigidbody _rigidbody;
    
    private Vector3 _currentMoveVelocity;
    private Vector3 _moveDampVelocity;

    private float _jumpSecurity = 0.05f;
    private float _jumpSecurityTimer;
    private float _jumpVelocity;
    private float _directionCharacter = 1;

    private bool _canDash = true;
    private bool _isDashing = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _inputsManager = GetComponent<Rogue_Inputs>();
        
        _jumpSecurityTimer =_jumpSecurity;
    }

    // Update is called once per frame
    private void Update()
    {
        GetCharacterDirection();
        if (_isDashing)
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
        transform.Translate(_currentMoveVelocity * Time.deltaTime, Space.World);
    }

    private void Jump()
    {
        _jumpVelocity += Physics.gravity.y * _gravityScale * Time.deltaTime;
        Ray groundCheckRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(groundCheckRay, out RaycastHit groundHit, 1.1f))
        {
            _jumpSecurityTimer = Mathf.Clamp(_jumpSecurityTimer - Time.deltaTime, 0, _jumpSecurity);
            _jumpVelocity = 0;
            if (_inputsManager.jump && _jumpSecurityTimer == 0)
            {
                _jumpVelocity = Mathf.Sqrt(_jumpHeight * -2f * ( Physics.gravity.y * _gravityScale));
                _jumpSecurityTimer = _jumpSecurity;
            }
        }
        transform.Translate(new Vector3 (0, _jumpVelocity, 0) * Time.deltaTime, Space.World);
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
        _isDashing = true;
        if (_inputsManager.moveX == 0)
        {
            _rigidbody.linearVelocity = new Vector3(- _directionCharacter * _backDashPower, 0.1f, 0f);
            yield return new WaitForSeconds(_backDashDuration);
            _rigidbody.linearVelocity = new Vector3(0f, 0f, 0f);
            _isDashing = false;
            yield return new WaitForSeconds(_backDashCooldown);
        }
        else
        {
            _rigidbody.linearVelocity = new Vector3(_inputsManager.moveX * _dashPower, 0.1f, 0f);
            yield return new WaitForSeconds(_dashDuration);
            _rigidbody.linearVelocity = new Vector3(0f, 0f, 0f);
            _isDashing = false;
            yield return new WaitForSeconds(_dashCooldown);
        }
        _canDash = true; 
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(this.transform.position, transform.position + new Vector3(0,- 1.1f, 0));
    }
}
