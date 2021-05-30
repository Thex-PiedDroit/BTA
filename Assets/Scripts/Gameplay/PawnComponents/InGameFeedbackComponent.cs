
using UnityEngine;


public class InGameFeedbackComponent : MonoBehaviour
{
#region Variables (serialized)

	[SerializeField]
	private Pawn m_master = null;

	[SerializeField]
	private Rigidbody m_rigidbody = null;

	[SerializeField]
	private FloatingDamageFeedback m_floatingDamageFeedbackPrefab = null;

	[SerializeField]
	private float m_deathRagdollThrowForce = 10.0f;

	#endregion

#region Variables (private)

	private const string UI_FEEDBACKS_CONTAINER_TAG = "UIFeedbacksContainer";
	private static Transform s_uiFeedbacksContainer = null;

	#endregion


	private void Start()
	{
		if (s_uiFeedbacksContainer == null)
			FindFeedbacksContainer();

		m_master.OnHealthChanged += SpawnFloatingDamageFeedback;
		m_master.OnDeath += ThrowRagdoll;
	}

	private void OnDestroy()
	{
		m_master.OnHealthChanged -= SpawnFloatingDamageFeedback;
		m_master.OnDeath -= ThrowRagdoll;
	}

	private void SpawnFloatingDamageFeedback(int damageValue)
	{
		Vector3 screenPosition = GameCamera.Current.CameraComponent.WorldToScreenPoint(m_master.BodyCenter);
		FloatingDamageFeedback feedback = Instantiate(m_floatingDamageFeedbackPrefab, screenPosition, Quaternion.identity, s_uiFeedbacksContainer);

		feedback.SetDamageValue(damageValue);
	}

	private void ThrowRagdoll()
	{
		m_rigidbody.constraints = RigidbodyConstraints.None;

		float x = Random.Range(-0.5f, 0.5f);
		float z = Random.Range(-0.5f, 0.5f);
		Vector3 throwDirection = new Vector3(x, 1.0f, z).normalized;

		m_rigidbody.velocity += (throwDirection * m_deathRagdollThrowForce);

		float fRotateSpeed = Random.Range(1.0f, 5.0f);
		m_rigidbody.angularVelocity += (Random.insideUnitSphere * fRotateSpeed);
	}

	private static void FindFeedbacksContainer()
	{
		GameObject container = GameObject.FindGameObjectWithTag(UI_FEEDBACKS_CONTAINER_TAG);

		if (container)
			s_uiFeedbacksContainer = container.transform;
		else
			Debug.LogError($"No Feedback Container found with tag {UI_FEEDBACKS_CONTAINER_TAG}.");
	}
}
