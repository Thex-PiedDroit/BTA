
using System;
using UnityEngine;


[Serializable]
public abstract class ColliderShape
{
#if UNITY_EDITOR
	public abstract void DrawGizmo(Vector3 attackOrigin, Quaternion orientation, string colliderName);
#endif

	public abstract Collider[] GetCollision(Vector3 attackOrigin, Quaternion orientation, int layerMask);
}
