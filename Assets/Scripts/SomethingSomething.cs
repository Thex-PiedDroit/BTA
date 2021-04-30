
using UnityEngine;


public class SomethingSomething : MonoBehaviour
{
#region Variables (serialized)

	[SerializeField]
	private GameObject m_stuffObject = null;

	#endregion

#region Variables (private)



	#endregion


	private void OnEnable()
	{
		Debug.Log(m_stuffObject);
	}
}
