
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;


[CustomEditor(typeof(WeaponAttacksDescriptor))]
public class ScriptedEventEditor : Editor
{
#region Variables (private)

	private const string LIST_HEADER_NAME = "Attacks";
	private const string LIST_PROPERTY_NAME = "m_attackDescriptions";
	private const string ATTACK_STEPS_NAME = "AttackSteps";


	private ReorderableList m_attacksList = null;
	private readonly List<ReorderableList> m_attackDescriptions = new List<ReorderableList>();

	#endregion


	private void OnEnable()
	{
		/*m_attackDescriptions.Clear();
		SerializedProperty attackDescriptions = serializedObject.FindProperty(LIST_PROPERTY_NAME);

		m_attacksList = new ReorderableList(serializedObject, attackDescriptions, true, true, true, true)
		{
			drawHeaderCallback = (Rect rect) => DrawListHeader(rect, LIST_HEADER_NAME),
			drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => DrawAttacksList(rect, index),
			elementHeight = 22.0f,
		};

		for (int i = 0, n = attackDescriptions.arraySize; i < n; ++i)
		{
			int attackIndex = i;
			SerializedProperty arrayElement = attackDescriptions.GetArrayElementAtIndex(i);

			m_attackDescriptions.Add(new ReorderableList(serializedObject, arrayElement.FindPropertyRelative("AttackSteps"), true, true, true, true)
			{
				drawHeaderCallback = (Rect rect) => DrawListHeader(rect, arrayElement.FindPropertyRelative("AttackName").stringValue),
				drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => DrawListElement(rect, index, attackIndex),
				elementHeight = 22.0f,
			}); ;
		}*/
	}

	override public void OnInspectorGUI()
	{
		DrawDefaultInspector();

		if (Selection.activeTransform && Selection.activeGameObject.GetComponent<Pawn>())
			DrawAttacksGizmo(Selection.activeTransform);

		//UpdateListDisplay();
	}

	private void DrawAttacksGizmo(Transform origin)
	{
		SerializedProperty attackDescriptions = serializedObject.FindProperty(LIST_PROPERTY_NAME);

		SerializedProperty firstAttack = attackDescriptions.GetArrayElementAtIndex(0).FindPropertyRelative(ATTACK_STEPS_NAME);
		SerializedProperty firstAttackCollider = firstAttack.GetArrayElementAtIndex(0);

		AttackColliderShape colliderShape = ((object)firstAttackCollider.serializedObject) as AttackColliderShape;
		colliderShape.DrawGizmo(origin.position, origin.rotation, "Test");
	}

	private void DrawAttacksList(Rect rect, int index)
	{
		SerializedProperty element = m_attacksList.serializedProperty.GetArrayElementAtIndex(index);
		string elementName = "Attacks"; //GetElementName(element, subAttackIndex);

		rect = GetElementRect(rect);

		EditorGUI.PropertyField(rect, element, new GUIContent(elementName));
	}

	private void UpdateListDisplay()
	{
		serializedObject.Update();

		m_attacksList.DoLayoutList();

		for (int i = 0, n = m_attackDescriptions.Count; i < n; ++i)
		{
			m_attackDescriptions[i].DoLayoutList();
		}

		serializedObject.ApplyModifiedProperties();
		EditorUtility.SetDirty(target);
	}

	private void DrawListHeader(Rect rect, string headerName)
	{
		GUI.Label(rect, headerName);
	}

	private void DrawListElement(Rect rect, int subAttackIndex, int attackIndex)
	{
		SerializedProperty element = m_attackDescriptions[attackIndex].serializedProperty.GetArrayElementAtIndex(subAttackIndex);
		string elementName = "Test"; //GetElementName(element, subAttackIndex);

		rect = GetElementRect(rect);

		EditorGUI.PropertyField(rect, element, new GUIContent(elementName));
	}

	/*private string GetElementName(SerializedProperty element, int index)
	{
		string name = string.Format("{0:00}. ", index + 1);

		if (element != null && element.objectReferenceValue != null)
			name += GetElementNameWithoutPrefix(element);

		return name;
	}

	private string GetElementNameWithoutPrefix(SerializedProperty element)
	{
		string rawName = element.objectReferenceValue.name;
		return rawName.Replace(target.name + "_", "");
	}*/

	private Rect GetElementRect(Rect rect)
	{
		Rect newRect = rect;
		newRect.height = 16.0f;
		newRect.y = rect.y + ((rect.height - newRect.height) * 0.5f);

		return newRect;
	}
}
