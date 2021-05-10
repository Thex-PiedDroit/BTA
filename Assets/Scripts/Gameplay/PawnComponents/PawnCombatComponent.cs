
using UnityEngine;


public class PawnCombatComponent : MonoBehaviour
{
#region Variables (serialized)

	[SerializeField]
	private Pawn m_master = null;

	[SerializeField]
	private Animator m_pawnAnimatorRightHand = null;
	[SerializeField]
	private Animator m_pawnAnimatorLeftHand = null;

	[SerializeField]
	private Transform m_handRight = null;
	[SerializeField]
	private Transform m_handLeft = null;

	#endregion

#region Variables (private)

	private Weapon m_weaponRight = null;
	private Weapon m_weaponLeft = null;

	private AttackType m_currentAttackType = 0;
	private int m_currentAttackID = 0;

	#endregion


	private void Start()
	{
		FindWeaponsInHands();
	}

	private void FindWeaponsInHands()
	{
		if (m_handRight)
		{
			m_weaponRight = m_handRight.GetComponentInChildren<Weapon>();
			if (m_weaponRight)
			{
				m_pawnAnimatorRightHand.runtimeAnimatorController = m_weaponRight.WeaponAnimatorController;
				m_pawnAnimatorRightHand.SetBool("RightHand", true);
			}
		}

		if (m_handLeft)
		{
			m_weaponLeft = m_handLeft.GetComponentInChildren<Weapon>();
			if (m_weaponLeft)
			{
				m_pawnAnimatorLeftHand.runtimeAnimatorController = m_weaponLeft.WeaponAnimatorController;
				m_pawnAnimatorLeftHand.SetBool("RightHand", false);
			}
		}
	}

	public void TriggerCurrentAttackCollider()
	{
		if (m_weaponRight)
			m_weaponRight.TriggerAttack(m_currentAttackType, ref m_currentAttackID, m_master);

		if (m_weaponLeft)
			m_weaponLeft.TriggerAttack(m_currentAttackType, ref m_currentAttackID, m_master);
	}

	protected void RightHandStart()
	{
		if (m_weaponRight == null)
			return;

		m_pawnAnimatorRightHand.SetTrigger("RegHit_Trigger");
		m_pawnAnimatorRightHand.SetBool("RegHit", true);

		m_currentAttackType = AttackType.Regular;
	}

	protected void RightHandStop()
	{
		if (m_weaponRight != null)
			m_pawnAnimatorRightHand.SetBool("RegHit", false);
	}

	protected void LeftHandStart()
	{
		if (m_weaponLeft == null)
			return;

		m_pawnAnimatorLeftHand.SetTrigger("RegHit_Trigger");
		m_pawnAnimatorLeftHand.SetBool("RegHit", true);

		m_currentAttackType = AttackType.Regular;
	}

	protected void LeftHandStop()
	{
		if (m_weaponLeft != null)
			m_pawnAnimatorLeftHand.SetBool("RegHit", false);
	}
}
