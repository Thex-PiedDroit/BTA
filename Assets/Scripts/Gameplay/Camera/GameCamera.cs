
using Nrjwolf.Tools.AttachAttributes;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
public class GameCamera : MonoBehaviour
{
#region Variables (serialized)

	[GetComponent]
	[SerializeField]
	private Camera m_cameraComponent = null;
	public Camera CameraComponent => m_cameraComponent;

	[SerializeField]
	private CameraBehavior m_behavior = null;

	[SerializeField]
	private bool m_isInitialCameraForCurrentMap = false;

	#endregion

#region Variables (private)

	public static GameCamera Current { get; private set; } = null;

	private Pawn m_target = null;

	#endregion


	private void Awake()
	{
		if (!m_isInitialCameraForCurrentMap)
			return;

		if (Current == null)
			Current = this;
		else
			Debug.LogError($"More than one camera are tagged as initial camera for current map. Please make sure there is only one. Current instance is {Current} and current duplicate is {this}.");
	}

	private void LateUpdate()
	{
		if (m_behavior != null)
			m_behavior.UpdateBehavior(this, m_target);
	}

	public void SetBehavior(CameraBehavior behavior)
	{
		m_behavior = behavior;
	}

	public void SetTarget(Pawn target)
	{
		m_target = target;
	}

	public Vector3 GetMouseRelativePosition(Vector3 fromPosition)
	{
		Vector3 mousePosOnGround = GetMousePositionOnGround(fromPosition);
		return mousePosOnGround - fromPosition;
	}

	private Vector3 GetMousePositionOnGround(Vector3 fromPosition)
	{
		Ray mouseRay = CameraComponent.ScreenPointToRay(Mouse.current.position.ReadValue());
		float multiplier = (transform.position.y - fromPosition.y) / Vector3.Dot(mouseRay.direction, Vector3.down);

		return transform.position + (mouseRay.direction * multiplier);
	}
}
