
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(MinMaxRangeAttribute))]
public class MinMaxRangeDrawer : PropertyDrawer
{
	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		return base.GetPropertyHeight(property, label) + 16.0f;
	}

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		if (property.type != "MinMaxRange")
		{
			Debug.LogWarning("Use only with MinMaxRange type");
			return;
		}


		MinMaxRangeAttribute range = attribute as MinMaxRangeAttribute;
		SerializedProperty min = property.FindPropertyRelative("m_min");
		SerializedProperty max = property.FindPropertyRelative("m_max");
		float newMin = min.floatValue;
		float newMax = max.floatValue;

		float divisionX = position.width * 0.33f;
		float divisionY = position.height * 0.5f;

		EditorGUI.LabelField(new Rect(position.x, position.y, divisionX, divisionY), label);

		EditorGUI.LabelField(new Rect(position.x, position.y + divisionY, position.width, divisionY), range.Min.ToString("0.##"));
		EditorGUI.LabelField(new Rect(position.x + position.width - 20.0f, position.y + divisionY, position.width, divisionY), range.Max.ToString("0.##"));
		EditorGUI.MinMaxSlider(new Rect(position.x + 16.0f, position.y + divisionY, position.width - 48.0f, divisionY), ref newMin, ref newMax, range.Min, range.Max);

		EditorGUI.LabelField(new Rect(position.x + divisionX, position.y, divisionX, divisionY), "From: ");
		newMin = Mathf.Clamp(EditorGUI.FloatField(new Rect(position.x + divisionX + 40.0f, position.y, divisionX - 40.0f, divisionY), newMin), range.Min, newMax);
		EditorGUI.LabelField(new Rect(position.x + divisionX * 2.0f, position.y, divisionX, divisionY), "To: ");
		newMax = Mathf.Clamp(EditorGUI.FloatField(new Rect(position.x + (divisionX * 2.0f) + 24.0f, position.y, divisionX - 24.0f, divisionY), newMax), newMin, range.Max);

		min.floatValue = newMin;
		max.floatValue = newMax;
	}
}
