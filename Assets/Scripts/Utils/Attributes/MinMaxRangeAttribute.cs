
using UnityEngine;

public class MinMaxRangeAttribute : PropertyAttribute
{
	public float Min = 0.0f;
	public float Max = 0.0f;

	public MinMaxRangeAttribute(float min, float max)
	{
		Min = min;
		Max = max;
	}
}

[System.Serializable]
public struct MinMaxRange
{
	public float Min;
	public float Max;

	/// <summary>
	/// The delta between Max and Min.
	/// </summary>
	public float Spread => Max - Min;


	public MinMaxRange(float min, float max)
	{
		Min = min;
		Max = max;
	}

	public MinMaxRange(MinMaxRange other)
	{
		Min = other.Min;
		Max = other.Max;
	}

	/// <summary>
	/// Returns a random value within the Min and Max values of this range.
	/// </summary>
	public float GetRandom()
	{
		return Random.Range(Min, Max);
	}

	static public bool operator >(MinMaxRange range, float value)
	{
		return range.Max > value;
	}
	static public bool operator <(MinMaxRange range, float value)
	{
		return range.Min < value;
	}
	static public bool operator >=(MinMaxRange range, float value)
	{
		return range.Max >= value;
	}
	static public bool operator <=(MinMaxRange range, float value)
	{
		return range.Min <= value;
	}
}
