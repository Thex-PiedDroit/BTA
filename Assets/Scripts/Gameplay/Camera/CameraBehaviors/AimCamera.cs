
using UnityEngine;


[CreateAssetMenu(fileName = "CamBhv_" + nameof(AimCamera), menuName = "ScriptableObjects/Camera/Behaviors/" + nameof(AimCamera))]
public class AimCamera : CameraBehavior
{
#region Variables (serialized)



	#endregion


	public override void UpdateBehavior(GameCamera camera, Pawn target)
	{
		if (target != null)
			AimAtTarget(camera, target);
	}

	private void AimAtTarget(GameCamera camera, Pawn target)
	{
		camera.transform.LookAt(target.transform, Vector3.up);
	}
}
