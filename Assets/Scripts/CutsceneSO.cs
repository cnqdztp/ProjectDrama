using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "SO/Cutscene")]
public class CutsceneSO : ScriptableObject
{
    public float lastTime;
    public Vector3 CameraPosition;
    public GameObject FadeOutObject;
    public bool isFadeIn = false;
}
