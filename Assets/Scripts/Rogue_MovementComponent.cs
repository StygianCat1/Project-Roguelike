using UnityEngine;

public class Rogue_MovementComponent : MonoBehaviour
{
    [SerializeField] private float _moveSmoothTime = 0.1f;
    [SerializeField] private float _movementSpeed = 10.0f;
    [SerializeField] private float _jumpHeight = 5.0f;
    [SerializeField] private float _gravityScale = 5.0f;
    
    
    private Rogue_Inputs _inputsManager;
    
    private Vector3 _currentMoveVelocity;
    private Vector3 _moveDampVelocity;
    private Vector3 _currentForceVelocity;
    
    private float _jumpVelocity;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _inputsManager = GetComponent<Rogue_Inputs>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
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

            _jumpVelocity = 0;
            if (_inputsManager.jump)
            {
                _jumpVelocity = Mathf.Sqrt(_jumpHeight * -2f * ( Physics.gravity.y * _gravityScale));
            }
        }
        transform.Translate(new Vector3 (0, _jumpVelocity, 0) * Time.deltaTime, Space.World);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(this.transform.position, transform.position + new Vector3(0,- 1.1f, 0));
    }
}
