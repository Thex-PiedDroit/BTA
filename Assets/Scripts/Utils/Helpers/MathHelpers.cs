
using UnityEngine;


public class MathHelpers : MonoBehaviour
{
	public static Vector2 GetRandomPointOnUnitCircle()
	{
		float randomAngle = Random.Range(0.0f, 2.0f * Mathf.PI);
		return new Vector2(Mathf.Sin(randomAngle), Mathf.Cos(randomAngle));
	}
}
