using UnityEngine;
using UnityEditor;


public abstract class BaseReferenceDrawer : PropertyDrawer
{

    private readonly string[] popupOptions =
         {"Use Normal Type", "Use SO Variable"};

    private GUIStyle popupStyle;

    protected string myTooltip = "Needs cutomized Tooltip";

    protected virtual void SetTooltip()
    {
        myTooltip = "Needs cutomized Tooltip";
    }
    protected virtual void SetTooltip(string tooltip)
    {
        myTooltip = tooltip;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SetTooltip();
        if (popupStyle == null)
        {
            popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
            popupStyle.imagePosition = ImagePosition.ImageOnly;
        }

        label = EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, label);

        EditorGUI.BeginChangeCheck();

        //Get Properties
        SerializedProperty useNormalType = property.FindPropertyRelative("useNormalType");
        SerializedProperty normalTypeVal = property.FindPropertyRelative("normalTypeVariable");
        SerializedProperty SOVar = property.FindPropertyRelative("_SOVariable");


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


