
using UnityEditor.Animations;
using UnityEngine;


public class PlayerCombatComponent : MonoBehaviour
{
#region Variables (serialized)

	[SerializeField]
	private Animator m_pawnAnimator = null;

	[SerializeField]
	private Transform m_handRight = null;

	#endregion

#region Variables (private)

	private IA_PlayerCombat m_inputActions = null;

	private Weapon m_weaponRightHand = null;

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
	}

	private void FindWeaponsInHands()
	{
		if (m_handRight)
		{
			m_weaponRightHand = m_handRight.GetComponentInChildren<Weapon>();
			if (m_weaponRightHand)
				AssignWeaponAnimatorController(m_weaponRightHand.WeaponAnimatorController);
		}
	}

	public void AssignWeaponAnimatorController(AnimatorController animatorController)
	{
		m_pawnAnimator.runtimeAnimatorController = animatorController;
	}

	private void RightHandStart()
	{
		m_pawnAnimator.SetTrigger("RightHand_Trigger");
		m_pawnAnimator.SetBool("RightHand", true);
	}

	private void RightHandStop()
	{
		m_pawnAnimator.SetBool("RightHand", false);
	}
}
