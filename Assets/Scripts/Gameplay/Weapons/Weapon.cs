
using System;
using UnityEngine;
using UnityEngine.Assertions;


public class Weapon : MonoBehaviour
{
#region Variables (serialized)

	[SerializeField]
	private WeaponAttacksDescriptor m_attacksDescriptor = null;

	[SerializeField]
	private RuntimeAnimatorController m_weaponAnimatorController = null;
	public RuntimeAnimatorController WeaponAnimatorController => m_weaponAnimatorController;

	#endregion

#region Variables (private)



	#endregion


	public void TriggerAttack(AttackType attackType, ref int attackID, Pawn instigator)
	{
		TriggerAttackOfType(attackType, attackID, instigator);
		attackID = m_attacksDescriptor.GetNextAttackID(attackType, attackID);
	}

	private void TriggerAttackOfType(AttackType attackType, int attackID, Pawn instigator)
	{
		AttackDescriptor attack = m_attacksDescriptor.GetAttack(attackType, attackID);
		bool canDamage = attack.CanDamage;
		bool canSelfHit = attack.CanSelfHit;
		bool canFriendlyFire = attack.CanFriendlyFire;
		bool canHeal = attack.CanHeal;
		bool canSelfHeal = attack.CanSelfHeal;
		bool canHealEnemies = attack.CanHealEnemies;

		(Vector3 attackOrigin, Quaternion attackRotation) = instigator.GetAttackOrigin();
		Collider[] hit = attack.ColliderShape.GetCollision(attackOrigin, attackRotation);

		for (int i = 0, n = hit.Length; i < n; ++i)
		{
			Pawn target = hit[i].GetComponent<Pawn>();
			Assert.IsNotNull(target, $"An object ({hit[i].gameObject}) has its layer set to \"Pawn\" but does not have a {nameof(Pawn)} component attached.");

			if (canDamage && CanDamageTarget(instigator, target, canSelfHit, canFriendlyFire))
				target.ApplyDamage(attack.GetRandomDamage());

			if (canHeal && CanHealTarget(instigator, target, canSelfHeal, canHealEnemies))
				target.ApplyHeal(attack.GetRandomHeal());
		}
	}

	private bool CanDamageTarget(Pawn instigator, Pawn target, bool canSelfHit, bool canFriendlyFire)
	{
		if (target == instigator)
			return canSelfHit;

		return canFriendlyFire || PawnUtils.CanDamage(instigator, target);
	}

	private bool CanHealTarget(Pawn instigator, Pawn target, bool canSelfHeal, bool canHealEnemies)
	{
		if (target == instigator)
			return canSelfHeal;

		return canHealEnemies || PawnUtils.CanHeal(instigator, target);
	}
}
