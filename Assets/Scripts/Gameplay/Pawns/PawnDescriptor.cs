
using UnityEngine;


public enum PawnBehaviourType
{
	Ally,
	Enemy,
	Neutral,
}

[CreateAssetMenu(fileName = "PD_" + nameof(PawnDescriptor), menuName = "ScriptableObjects/Pawns/" + nameof(PawnDescriptor))]
public class PawnDescriptor : ScriptableObject
{
#region Variables (serialized)

	[SerializeField]
	private PawnBehaviourType m_behaviourType = 0;
	public PawnBehaviourType BehaviourType => m_behaviourType;

	[SerializeField]
	private int m_maxHealth = 10;
	public int MaxHealth => m_maxHealth;

	#endregion
}
