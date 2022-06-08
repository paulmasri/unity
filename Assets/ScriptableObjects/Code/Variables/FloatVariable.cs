using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
#if UNITY_EDITOR
	[TextArea(3,10)]
	public string DeveloperDescription = "";
#endif

	[SerializeField]
	private float _value;
	public float Value { get => _value; set => _value = value; }

	public static implicit operator float(FloatVariable variable) => variable.Value;
}
