

public class PlayerCombatComponent : PawnCombatComponent
{
#region Variables (serialized)



	#endregion

#region Variables (private)

	private IA_PlayerCombat m_inputActions = null;

	#endregion


	private void Awake()
	{
		InitializeInputs();

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
}
