
using System;
using UnityEngine;


[Serializable]
public class AttackDescriptor : ISerializationCallbackReceiver
{
#region Variables (serialized)

	[SerializeField]
	private AttackColliderShape m_colliderShape = null;
	public AttackColliderShape ColliderShape => m_colliderShape;


	[Header("Damage")]

	[SerializeField]
	private bool m_canDamage = true;
	public bool CanDamage => m_canDamage;

	[SerializeField]
	[ConditionalField(nameof(m_canDamage))]
	private bool m_canSelfHit = false;
	public bool CanSelfHit => m_canSelfHit;

	[SerializeField]
	[ConditionalField(nameof(m_canDamage))]
	private bool m_canFriendlyFire = false;
	public bool CanFriendlyFire => m_canFriendlyFire;

	[SerializeField]
	[ConditionalField(nameof(m_canDamage))]
	private MinMaxRangeInt m_damage = new MinMaxRangeInt();


	[Header("Damage")]

	[SerializeField]
	private bool m_canHeal = false;
	public bool CanHeal => m_canHeal;

	[SerializeField]
	[ConditionalField(nameof(m_canHeal))]
	private bool m_canSelfHeal = false;
	public bool CanSelfHeal => m_canSelfHeal;

	[SerializeField]
	[ConditionalField(nameof(m_canHeal))]
	private bool m_canHealEnemies = false;
	public bool CanHealEnemies => m_canHealEnemies;

	[SerializeField]
	[ConditionalField(nameof(m_canHeal))]
	private MinMaxRangeInt m_heal = new MinMaxRangeInt();

	#endregion

	#region Variables (private)



	#endregion


	public int GetRandomDamage() => m_damage.GetRandom();

	public int GetRandomHeal() => m_heal.GetRandom();

	void ISerializationCallbackReceiver.OnAfterDeserialize()
	{

	}

	void ISerializationCallbackReceiver.OnBeforeSerialize()
	{
		m_damage.Min = Mathf.Max(0, m_damage.Min);
	}
}
