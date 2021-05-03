
using System;
using UnityEngine;

[Serializable]
public class AttackColliderShape
{
	public enum Shape
	{
		Box,
	}

#region Variables (serialized)

	[SerializeField]
	private Shape m_shape = Shape.Box;

	[SerializeField]
	private BoxColliderShape m_boxShape = null;

	#endregion


#if UNITY_EDITOR
	public void DrawGizmo(Vector3 attackOrigin, Quaternion rotation, string colliderName)
	{
		switch (m_shape)
		{
			case Shape.Box:
				m_boxShape.DrawGizmo(attackOrigin, rotation, colliderName);
				break;

			default:
				throw new NotImplementedException($"No gizmo function has been defined for collider shape {m_shape}.");
		}
	}
#endif

	public Collider[] GetCollision(Vector3 attackOrigin, Quaternion rotation)
	{
		switch (m_shape)
		{
			case Shape.Box:
				return m_boxShape.GetCollision(attackOrigin, rotation, LayerMask.GetMask("Pawn"));

			default:
				throw new NotImplementedException($"No collision function has been defined for collider shape {m_shape}.");
		}
	}
}
