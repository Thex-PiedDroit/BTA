
using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(WeaponAttacksDescriptor), menuName = "ScriptableObjects/Weapons/" + nameof(WeaponAttacksDescriptor))]
public class WeaponAttacksDescriptor : ScriptableObject
{
	[Serializable]
	public struct AttackDescription
	{
		public string AttackName;
		public List<AttackColliderShape> AttackSteps;
	}

#region Variables (serialized)

	[SerializeField]
	private List<AttackDescription> m_attackDescriptions = null;

	#endregion



}
