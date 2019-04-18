using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(GameEventReference))]
public class GameEventReferenceDrawer : PropertyDrawer {

    private readonly string[] popupOptions =
     {"Use SO Event", "Use GameEvent of MonoBehaviour"};

    private GUIStyle popupStyle;

    protected string myTooltip = "Choose how you what GameEvent should be listend to.";

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (popupStyle == null)
        {
            popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
            popupStyle.imagePosition = ImagePosition.ImageOnly;
        }

        label = EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, label);

        EditorGUI.BeginChangeCheck();

        //Get Properties
        SerializedProperty useNormalType = property.FindPropertyRelative("useSOGameEvent");
        SerializedProperty normalTypeVal = property.FindPropertyRelative("soGameEvent");
        SerializedProperty SOVar = property.FindPropertyRelative("gameEventFromMono");


        //Setting up the Rect for the drop-down Configuration
        Rect buttonRect = new Rect(position);
        buttonRect.yMin += popupStyle.margin.top;
        buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
        position.xMin = buttonRect.xMax;

        // Store old indent level and set it to 0, the PrefixLabel takes care of it
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        //The drop-down Menu depending on what useNormalType is it will display either the normal Type or the SO Variable
        int result = EditorGUI.Popup(buttonRect, useNormalType.boolValue ? 0 : 1, popupOptions, popupStyle);

        useNormalType.boolValue = result == 0;

        //Set propertyField depending on boolValue
        EditorGUI.PropertyField(position,
            useNormalType.boolValue ? normalTypeVal : SOVar,
            GUIContent.none);
        EditorGUI.LabelField(position, new GUIContent("", myTooltip));

        if (EditorGUI.EndChangeCheck())
            property.serializedObject.ApplyModifiedProperties();

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }


}

