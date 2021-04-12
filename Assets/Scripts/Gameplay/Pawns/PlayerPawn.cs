
using UnityEngine;


public class PlayerPawn : Pawn
{
#region Variables (serialized)



	#endregion

#region Variables (private)



	#endregion


	private void Start()
	{
		GameCamera.Current.SetTarget(this);
	}
}
