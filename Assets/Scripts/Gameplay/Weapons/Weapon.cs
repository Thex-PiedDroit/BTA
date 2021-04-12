
using UnityEditor.Animations;
using UnityEngine;


public class Weapon : MonoBehaviour
{
#region Variables (serialized)

	[SerializeField]
	private AnimatorController m_weaponAnimatorController = null;
	public AnimatorController WeaponAnimatorController => m_weaponAnimatorController;

	#endregion

#region Variables (private)



	#endregion



}
