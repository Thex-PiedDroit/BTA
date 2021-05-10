
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
		AttackColliderShape attack = m_attacksDescriptor.GetAttack(attackType, attackID);

		(Vector3 attackOrigin, Quaternion attackRotation) = instigator.GetAttackOrigin();
		Collider[] hit = attack.GetCollision(attackOrigin, attackRotation);

		for (int i = 0, n = hit.Length; i < n; ++i)
		{
			Pawn pawn = hit[i].GetComponent<Pawn>();
			Assert.IsNotNull(pawn, $"An object ({hit[i].gameObject}) has the Pawn layer but does not have a {nameof(Pawn)} component attached.");

			// TODO: Hit the pawn
		}
	}
}
