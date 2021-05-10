
using UnityEngine;


public static class PawnUtils
{
	public static bool CanDamage(Pawn pawn, Pawn target)
	{
		return pawn.BehaviourType != target.BehaviourType;
	}

	public static bool CanHeal(Pawn pawn, Pawn target)
	{
		return target.BehaviourType == PawnBehaviourType.Neutral ||
			   target.BehaviourType == pawn.BehaviourType;
	}
}
