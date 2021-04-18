
using UnityEngine;


public class PlayerCombatComponent : MonoBehaviour
{
#region Variables (serialized)

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

	private IA_PlayerCombat m_inputActions = null;

	private Weapon m_weaponRight = null;
	private Weapon m_weaponLeft = null;

	#endregion


	private void Awake()
	{
		InitializeInputs();

	}

	private void Start()
	{
		FindWeaponsInHands();
	}

	private void InitializeInputs()
	{
		m_inputActions = new IA_PlayerCombat();
		m_inputActions.Enable();

		m_inputActions.Combat.RightHand.started += (_) => RightHandStart();
		m_inputActions.Combat.RightHand.canceled += (_) => RightHandStop();
		m_inputActions.Combat.LeftHand.started += (_) => LeftHandStart();
		m_inputActions.Combat.LeftHand.canceled += (_) => LeftHandStop();
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
				m_pawnAnimatorRightHand.SetTrigger("RightHandActivated");
			}
		}

		if (m_handLeft)
		{
			m_weaponLeft = m_handLeft.GetComponentInChildren<Weapon>();
			if (m_weaponLeft)
			{
				m_pawnAnimatorLeftHand.runtimeAnimatorController = m_weaponLeft.WeaponAnimatorController;
				m_pawnAnimatorLeftHand.SetBool("RightHand", false);
				m_pawnAnimatorLeftHand.SetTrigger("LeftHandActivated");
			}
		}
	}

	private void RightHandStart()
	{
		if (m_weaponRight == null)
			return;

		m_pawnAnimatorRightHand.SetTrigger("RegHit_Trigger");
		m_pawnAnimatorRightHand.SetBool("RegHit", true);
	}

	private void RightHandStop()
	{
		if (m_weaponRight != null)
			m_pawnAnimatorRightHand.SetBool("RegHit", false);
	}

	private void LeftHandStart()
	{
		if (m_weaponLeft == null)
			return;

		m_pawnAnimatorLeftHand.SetTrigger("RegHit_Trigger");
		m_pawnAnimatorLeftHand.SetBool("RegHit", true);
	}

	private void LeftHandStop()
	{
		if (m_weaponLeft != null)
			m_pawnAnimatorLeftHand.SetBool("RegHit", false);
	}
}
