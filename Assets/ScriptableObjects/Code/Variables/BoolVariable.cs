using UnityEngine;

[CreateAssetMenu]
public class BoolVariable : ScriptableObject
{
#if UNITY_EDITOR
	[TextArea(3,10)]
	public string DeveloperDescription = "";
#endif

	[SerializeField]
	private bool _value;
	public bool Value { get => _value; set => _value = value; }

	public static implicit operator bool(BoolVariable variable) => variable.Value;
}
