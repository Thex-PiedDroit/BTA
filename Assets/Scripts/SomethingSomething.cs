
using UnityEngine;


public class SomethingSomething : MonoBehaviour
{
#region Variables (serialized)

	[SerializeField]
	private GameObject m_stuffObject = null;

	[SerializeField]
	private Collider m_stuffCollider1 = null;

	[SerializeField]
	private Transform m_stuffTransform = null;

	[SerializeField]
	private Collider m_stuffCollider2 = null;

	#endregion

#region Variables (private)



	#endregion


	private void OnEnable()
	{
		Debug.Log(m_stuffObject);
		m_stuffCollider1.enabled = false;
		Debug.Log(m_stuffTransform);

		m_stuffCollider2.enabled = true;
	}
}
