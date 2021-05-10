
using System.Collections.Generic;
using UnityEngine;


public enum AttackType
{
	Regular,
	Heavy,
}

[CreateAssetMenu(fileName = "WAD_" + nameof(WeaponAttacksDescriptor), menuName = "ScriptableObjects/Weapons/" + nameof(WeaponAttacksDescriptor))]
public class WeaponAttacksDescriptor : ScriptableObject
{
#region Variables (serialized)

	[SerializeField]
	private List<AttackDescriptor> m_regularAttackSteps = null;
	[SerializeField]
	private List<AttackDescriptor> m_heavyAttackSteps = null;

	#endregion


	public int GetNextAttackID(AttackType newAttackType, int currentAttackID)
	{
		int maxID = newAttackType == AttackType.Regular ?
					m_regularAttackSteps.Count :
					m_heavyAttackSteps.Count;

		return ++currentAttackID % maxID;
	}

	public AttackDescriptor GetAttack(AttackType attackType, int attackID)
	{
		switch (attackType)
		{
			case AttackType.Regular:
				return m_regularAttackSteps[attackID];
			case AttackType.Heavy:
				return m_heavyAttackSteps[attackID];

			default:
				Debug.LogError($"Type of attack {attackType} not recognized.");
				return null;
		}
	}
}
