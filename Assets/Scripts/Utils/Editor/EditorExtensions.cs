
using System;
using System.Collections;
using System.Reflection;
using UnityEditor;


public static class EditorExtensions
{
	public static T GetTargetObjectOfProperty<T>(SerializedProperty property) => (T)GetTargetObjectOfProperty(property);

	public static object GetTargetObjectOfProperty(SerializedProperty property)
	{
		if (property == null)
			return null;

		string path = property.propertyPath.Replace(".Array.data[", "[");
		object targetObject = property.serializedObject.targetObject;

		string[] elements = path.Split('.');

		foreach (string element in elements)
		{
			if (element.Contains("["))
			{
				string elementName = element.Substring(0, element.IndexOf("["));
				int index = Convert.ToInt32(element.Substring(element.IndexOf("[")).Replace("[", "").Replace("]", ""));

				targetObject = GetObjectValue(targetObject, elementName, index);
			}
			else
			{
				targetObject = GetObjectValue(targetObject, element);
			}
		}
		return targetObject;
	}

	private static object GetObjectValue(object source, string name)
	{
		const BindingFlags FIELD_INFO_FLAGS = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
		const BindingFlags PROPERTY_INFO_FLAGS = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase;

		if (source == null)
			return null;

		Type type = source.GetType();

		while (type != null)
		{
			FieldInfo field = type.GetField(name, FIELD_INFO_FLAGS);
			if (field != null)
				return field.GetValue(source);

			PropertyInfo property = type.GetProperty(name, PROPERTY_INFO_FLAGS);
			if (property != null)
				return property.GetValue(source, null);

			type = type.BaseType;
		}

		return null;
	}

	private static object GetObjectValue(object source, string name, int index)
	{
		if (!(GetObjectValue(source, name) is IEnumerable enumerable))
			return null;

		IEnumerator enumerator = enumerable.GetEnumerator();

		for (int i = 0; i <= index; i++)
		{
			if (!enumerator.MoveNext())
				return null;
		}
		return enumerator.Current;
	}
}
