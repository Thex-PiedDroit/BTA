
using UnityEngine;


[CreateAssetMenu(fileName = "CamBhv_" + nameof(PlayerCameraBehavior), menuName = "ScriptableObjects/Camera/Behaviors/" + nameof(PlayerCameraBehavior))]
public class PlayerCameraBehavior : CameraBehavior
{
#region Variables (serialized)

	[SerializeField]
	private Vector3 m_offsetFromTarget = Vector3.zero;

	[SerializeField]
	private Vector3 m_defaultRotation = Vector3.zero;

	[SerializeField]
	private float m_maxMouseDistanceForLookup = 10.0f;
	[SerializeField]
	[Range(0.0f, 1.0f)]
	private float m_lookupDistanceFromMouse = 0.33f;

	[SerializeField]
	[MinMaxRange(0.0f, 1.0f)]
	private MinMaxRange m_smoothFollowFactor = new MinMaxRange(0.1f, 0.5f);

	#endregion

#region Variables (private)

	private Vector3 m_followVelocity = Vector3.zero;

	#endregion


	public override void UpdateBehavior(GameCamera camera, Pawn target)
	{
		if (target != null)
			FollowTarget(camera, target);
	}

	private void FollowTarget(GameCamera camera, Pawn target)
	{
		Vector3 targetPosition = target.transform.position;
		Vector3 relativeMousePosition = camera.GetMouseRelativePosition(targetPosition);

		float distanceBetweenMouseAndTarget = relativeMousePosition.magnitude;

		float lookupDistance = m_lookupDistanceFromMouse * Mathf.Min(distanceBetweenMouseAndTarget, m_maxMouseDistanceForLookup);
		Vector3 lookupPosition = targetPosition + (relativeMousePosition.normalized * lookupDistance);

		float lookupDropOffProgress = Mathf.Min(distanceBetweenMouseAndTarget, m_maxMouseDistanceForLookup) / m_maxMouseDistanceForLookup;
		float lerpValue = Mathf.Max(0.0f, Mathf.Cos(Mathf.Pow(lookupDropOffProgress, 5.0f) * (Mathf.PI * 0.5f)));
		float smoothFactorValue = Mathf.Lerp(m_smoothFollowFactor.Max, m_smoothFollowFactor.Min, lerpValue);

		camera.transform.rotation = Quaternion.Euler(m_defaultRotation);
		camera.transform.position = Vector3.SmoothDamp(camera.transform.position, lookupPosition + m_offsetFromTarget, ref m_followVelocity, smoothFactorValue);
	}
}
