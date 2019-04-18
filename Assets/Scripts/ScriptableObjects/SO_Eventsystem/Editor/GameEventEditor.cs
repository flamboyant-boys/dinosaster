using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor {
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUI.enabled = Application.isPlaying;

        GameEvent gameEv = target as GameEvent;
        if (GUILayout.Button("Raise"))
            gameEv.Raise();
    }

}
