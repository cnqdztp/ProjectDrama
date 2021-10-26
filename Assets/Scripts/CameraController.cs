using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _camera;
    public Vector3 targetPosition = Vector3.zero;
    
    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    public void MoveCameraZ()
    {
        if(_camera == null) return;
        transform.DOMove(targetPosition, 1f);
    }

    public void SetTargetPosition(Vector3 target)
    {
        targetPosition = target;
    }

    public void SetAndMove(Vector3 target)
    {
        SetTargetPosition(target);
        MoveCameraZ();
    }
}
