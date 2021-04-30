
using UnityEngine;


public class SomethingSomething : MonoBehaviour
{
#region Variables (serialized)

	[SerializeField]
	private GameObject m_stuffObject = null;

	[SerializeField]
	private Transform m_stuffTransform = null;

	[SerializeField]
	private Collider m_stuffCollider = null;

	#endregion

#region Variables (private)



	#endregion


	private void OnEnable()
	{
		Debug.Log(m_stuffObject);
		Debug.Log(m_stuffTransform);

		m_stuffCollider.enabled = false;
	}
}
