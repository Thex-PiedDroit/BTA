
using UnityEngine;


public class AttackColliderActivator : MonoBehaviour
{
#region Variables (serialized)

	[SerializeField]
	private PawnCombatComponent m_combatComponent = null;

	#endregion


	public void UI_TriggerNextAttack()
	{
		m_combatComponent.TriggerCurrentAttackCollider();
	}
}
