using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(EnemyVision))]
public class EnemyVisionEditor : Editor {

    void OnSceneGUI()
    {
        EnemyVision vision = (EnemyVision)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(vision.transform.position, Vector3.up, Vector3.forward, 360, vision.viewRadius);
        Vector3 viewAngleA = vision.DirFromAngle(-vision.viewAngle / 2, false);
        Vector3 viewAngleB = vision.DirFromAngle(vision.viewAngle / 2, false);

        Handles.DrawLine(vision.transform.position, vision.transform.position + viewAngleA * vision.viewRadius);
        Handles.DrawLine(vision.transform.position, vision.transform.position + viewAngleB * vision.viewRadius);

        Handles.color = Color.green;
        foreach (Transform visibleTarget in vision.visibleTargets)
        {
            Handles.DrawLine(vision.transform.position, visibleTarget.position);
        }
    }
}
