using UnityEngine;

[CreateAssetMenu]
public class IntVariable : ScriptableObject
{
#if UNITY_EDITOR
	[TextArea(3,10)]
	public string DeveloperDescription = "";
#endif

	[SerializeField]
	private int _value;
	public int Value { get => _value; set => _value = value; }

	public static implicit operator int(IntVariable variable) => variable.Value;
}
