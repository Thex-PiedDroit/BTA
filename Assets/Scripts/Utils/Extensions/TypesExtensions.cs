
using System;
using UnityEngine;


public static class BaseTypesExtensions
{
	static public int Sqrd(this int value)
	{
		return value * value;
	}

	static public float Sqrd(this float value)
	{
		return value * value;
	}
}

public static class StringExtensions
{
	public static T ToEnum<T>(this string str, T defaultValue) where T : Enum
	{
		if (string.IsNullOrEmpty(str))
			return defaultValue;

		Enum[] allValues = (Enum[])(Enum.GetValues(typeof(Enum)));

		for (int i = 0, n = allValues.Length; i < n; ++i)
		{
			Enum enumValue = allValues[i];

			if (FormatEnumToString(enumValue).Equals(GetLowerCase(str)))
				return (T)enumValue;
		}

		Debug.LogWarning("Could not find matching enum for \"" + str + " in enum \"" + typeof(T).ToString() + "\"!");
		return defaultValue;
	}

	private static string FormatEnumToString(Enum enumName)
	{
		return enumName.ToString().ToLower().Replace("_", "");
	}

	private static string GetLowerCase(string str)
	{
		return str.Trim().ToLower();
	}
}
