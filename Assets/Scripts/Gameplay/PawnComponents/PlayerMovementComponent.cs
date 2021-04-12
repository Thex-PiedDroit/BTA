
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementComponent : MonoBehaviour
{
#region Variables (serialized)

	[SerializeField]
	private Rigidbody m_rigidbody = null;

	[Category("Movement")]
	[SerializeField]
	private float m_speed = 5.0f;
	[SerializeField]
	private float m_jumpForce = 10.0f;
	[SerializeField]
	private float m_longJumpForceAscending = 10.0f;
	[SerializeField]
	private float m_longJumpForceDescending = 20.0f;

	[Category("Ground Check")]
	[SerializeField]
	private float m_groundCheckSphereRadius = 0.5f;
	[SerializeField]
	private float m_groundCheckDistanceTolerance = 0.05f;

	#endregion

#region Variables (private)

	private const string SET_LAYER_NAME = "Set";


	private IA_PlayerMovement m_inputActions = null;
	private Vector3 m_movementDirection = Vector3.zero;

	private Collider[] m_groundCheckColliderCache = new Collider[5];
	private Vector3 m_groundCheckSphereRelativePos = Vector3.zero;
	private int m_groundCheckLayerMask = 0;
	private bool m_isJumping = false;

	private bool m_isGrounded = false;

	#endregion


	private void Awake()
	{
		InitializeInputs();

		InitializeGroundCheck();
	}

	private void OnEnable()
	{
		m_inputActions.Enable();
	}

	private void OnDisable()
	{
		m_inputActions.Disable();
	}

	private void InitializeInputs()
	{
		m_inputActions = new IA_PlayerMovement();
		m_inputActions.Enable();

		m_inputActions.Movement.Movement.started += UpdateMovementDirection;
		m_inputActions.Movement.Movement.performed += UpdateMovementDirection;
		m_inputActions.Movement.Movement.canceled += UpdateMovementDirection;

		m_inputActions.Movement.Jump.started += _ => Jump();
		m_inputActions.Movement.Jump.canceled += _ => StopJump();
	}

	private void InitializeGroundCheck()
	{
		m_groundCheckSphereRelativePos = Vector3.up * (m_groundCheckSphereRadius - m_groundCheckDistanceTolerance);

		m_groundCheckLayerMask = LayerMask.GetMask(SET_LAYER_NAME);
	}

	private void UpdateMovementDirection(InputAction.CallbackContext inputContext)
	{
		m_movementDirection = inputContext.ReadValue<Vector2>().xzy();
	}

	private void Update()
	{
		LookAtMouse();

		if (!m_isJumping && !m_isGrounded)
			CheckIfGrounded();
		if (m_isGrounded)
			StopJump();

		if (m_movementDirection != null)
			Move();
	}

	private void FixedUpdate()
	{
		if (m_isJumping)
			LongJump();
	}

	private void CheckIfGrounded()
	{
		m_isGrounded = Physics.OverlapSphereNonAlloc(transform.position + m_groundCheckSphereRelativePos, m_groundCheckSphereRadius, m_groundCheckColliderCache, m_groundCheckLayerMask) > 0;
	}

	private void LookAtMouse()
	{
		Vector3 relativeMousePosition = GameCamera.Current.GetMouseRelativePosition(transform.position);
		transform.LookAt(transform.position + relativeMousePosition, Vector3.up);
	}

	private void Move()
	{
		Vector3 move = m_movementDirection * (m_speed * Time.deltaTime);
		transform.position = (transform.position + move);
	}

	private void Jump()
	{
		if (!m_isGrounded)
			return;

		m_rigidbody.velocity = m_rigidbody.velocity.x_z();
		m_rigidbody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
		m_isJumping = true;
		m_isGrounded = false;
	}

	private void LongJump()
	{
		float jumpForce = m_rigidbody.velocity.y > 0.0f ? m_longJumpForceAscending : m_longJumpForceDescending;
		m_rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Force);
	}

	private void StopJump()
	{
		m_isJumping = false;
	}
}
