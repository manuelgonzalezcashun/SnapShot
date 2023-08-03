using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ProportionalAnchorCalc))]
public class ProportionalAnchorCalcEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ProportionalAnchorCalc script = (ProportionalAnchorCalc)target;

        DrawDefaultInspector();

        GUILayout.Space(5);

        GUILayout.BeginHorizontal();
        {
            EditorGUI.BeginDisabledGroup(!script.anchorRect || !script.currentRect);
            {
                if (GUILayout.Button("Set These Anchors"))
                {
                    Undo.RecordObject(script.currentRect, "Rect anchors set");
                    script.setAnchors();
                }
            }
            EditorGUI.EndDisabledGroup();

            if (GUILayout.Button("Reset Target Rects to Default"))
            {
                Undo.RecordObject(script, "Target rects reset to default");
                script.resetTargetRects();
            }
        }
        GUILayout.EndHorizontal();
    }
}
