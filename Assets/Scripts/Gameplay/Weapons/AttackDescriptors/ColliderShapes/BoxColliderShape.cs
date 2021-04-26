
using UnityEditor;
using UnityEngine;


[System.Serializable]
public class BoxColliderShape : ColliderShape
{
#region Variables (serialized)

	[SerializeField]
	private Vector3 m_offset = Vector3.forward;

	[SerializeField]
	private Vector3 m_halfDimensions = Vector3.one;

	#endregion

#if UNITY_EDITOR
	public override void DrawGizmo(Vector3 attackOrigin, Quaternion orientation, string colliderName)
	{
		Handles.Label(attackOrigin, colliderName);

		Gizmos.matrix = Matrix4x4.TRS(Vector3.zero, orientation, Vector3.one);
		Gizmos.DrawWireCube(attackOrigin + m_offset, m_halfDimensions * 2.0f);
	}
#endif

	public override Collider[] GetCollision(Vector3 attackOrigin, Quaternion orientation, int layerMask)
	{
		return Physics.OverlapBox(attackOrigin + m_offset, m_halfDimensions, orientation, layerMask);
	}
}
