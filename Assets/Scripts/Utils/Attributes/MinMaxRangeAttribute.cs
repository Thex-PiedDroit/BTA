
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
public class MinMaxRange
{
	[SerializeField]
	private float m_min = 0.0f;
	[SerializeField]
	private float m_max = 1.0f;
	public float Min => m_min;
	public float Max => m_max;


	public MinMaxRange()
	{

	}

	public MinMaxRange(float min, float max)
	{
		m_min = min;
		m_max = max;
	}

	public float RandomValue
	{
		get
		{
			return Random.Range(Min, Max);
		}
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
