
using System;
using UnityEngine;


public class Pawn : MonoBehaviour
{
#region Variables (serialized)

	[SerializeField]
	private Vector3 m_bodyCenter = Vector3.up;
	public Vector3 BodyCenter => transform.position + m_bodyCenter;

	[SerializeField]
	private PawnDescriptor m_descriptor = null;

	#endregion

#region Variables (public)

	public Action<int> OnHealthChanged = null;
	public Action OnDeath = null;

	#endregion

#region Variables (private)

	private PawnBehaviourType m_behaviourType = 0;
	public PawnBehaviourType BehaviourType => m_behaviourType;

	private int m_currentHealth = 0;
	private bool m_isDead = false;

	#endregion


	private void Awake()
	{
		m_behaviourType = m_descriptor.BehaviourType;
		m_currentHealth = m_descriptor.MaxHealth;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawIcon(BodyCenter, "scenevis_visible_hover@2x", true, Color.black);
	}

	public void ApplyDamage(int damage)
	{
		if (m_isDead)
			return;

		m_currentHealth = Mathf.Max(0, m_currentHealth - damage);
		OnHealthChanged?.Invoke(-damage);

		if (m_currentHealth == 0)
		{
			m_isDead = true;
			OnDeath?.Invoke();
		}
	}

	public void ApplyHeal(int heal)
	{
		if (m_isDead)
			return;

		m_currentHealth = Mathf.Min(m_currentHealth + heal, m_descriptor.MaxHealth);
		OnHealthChanged?.Invoke(heal);
	}

	public (Vector3 origin, Quaternion rotation) GetAttackOrigin()
	{
		return (transform.position + m_bodyCenter, transform.rotation);
	}
}
