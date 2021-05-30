
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TMP_Text))]
public class FloatingDamageFeedback : MonoBehaviour
{
#region Variables (public)

	[SerializeField]
	private TMP_Text m_text = null;

	[SerializeField]
	private Rigidbody2D m_rigidBody = null;

	[SerializeField]
	private float m_lifeTime = 1.0f;

	#endregion

#region Variables (private)

	private const float ALPHA_CURVE_EXPONENT = 3.0f;
	private const float INITIAL_VELOCITY = 80.0f;

	private float m_timeLived = 0.0f;

	#endregion


	private void Start()
	{
		Vector2 initialDirection = MathHelpers.GetRandomPointOnUnitCircle();
		initialDirection.y = Mathf.Abs(initialDirection.y);

		m_rigidBody.velocity += (initialDirection * (INITIAL_VELOCITY * ALPHA_CURVE_EXPONENT));
	}

	private void Update()
	{
		if (m_timeLived < m_lifeTime)
			UpdateLifeTime();
		else
			Destroy(gameObject);
	}

	private void UpdateLifeTime()
	{
		float lifeProgress = m_timeLived / m_lifeTime;
		float alpha = Mathf.Max(0.0f, 1.0f - Mathf.Pow(lifeProgress, ALPHA_CURVE_EXPONENT));

		m_text.color = m_text.color.SetAlpha(alpha);

		m_rigidBody.velocity += Physics2D.gravity;

		m_timeLived += Time.deltaTime;
	}

	public void SetDamageValue(int value)
	{
		if (value > 0)
		{
			m_text.color = Color.green;
			m_text.text = $"+{value}";
		}
		else
		{
			m_text.color = value == 0 ? Color.white : Color.red;
			m_text.text = value.ToString();
		}
	}
}
