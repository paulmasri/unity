using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(FloatVariable))]
public class FloatVariableDrawer : PropertyDrawer
{
	private static float widthValue = 50f;
	private static float spacing = 2f;

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginProperty(position, label, property);

		position = EditorGUI.PrefixLabel(position,
			GUIUtility.GetControlID(FocusType.Passive),
			label);

		int prevIndent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		Rect rectSelector = new Rect(position.x,
			position.y,
			position.width - widthValue,
			EditorGUIUtility.singleLineHeight);

		Rect rectValue = new Rect(rectSelector.x + rectSelector.width + spacing,
			position.y,
			widthValue - spacing,
			EditorGUIUtility.singleLineHeight);

		var variable = (FloatVariable)property.objectReferenceValue;
		
		if (variable == null)
		{
			EditorGUI.PropertyField(position, property, GUIContent.none);
		}
		else
		{
			var rightAlignStyle = new GUIStyle(GUI.skin.label);
			rightAlignStyle.alignment = TextAnchor.MiddleRight;
			EditorGUI.PropertyField(rectSelector, property, GUIContent.none);
			EditorGUI.LabelField(rectValue, variable.Value.ToString(), rightAlignStyle);
		}

		EditorGUI.indentLevel = prevIndent;

		EditorGUI.EndProperty();
	}
}
