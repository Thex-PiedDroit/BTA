
using UnityEngine;

public abstract class CameraBehavior : ScriptableObject
{
#region Variables (serialized)



	#endregion


	public abstract void UpdateBehavior(GameCamera camera, Pawn target);
}
