
using UnityEngine;


public class Pawn : MonoBehaviour
{
#region Variables (serialized)

	[SerializeField]
	private Vector3 m_bodyCenter = Vector3.up;
	public Vector3 BodyCenter => m_bodyCenter;

	#endregion

#region Variables (private)



	#endregion


	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawIcon(transform.position + m_bodyCenter, "scenevis_visible_hover@2x", true, Color.black);
	}

	public (Vector3 origin, Quaternion rotation) GetAttackOrigin()
	{
		return (transform.position + m_bodyCenter, transform.rotation);
	}
}
