using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public CutsceneSO[] cutSceneList;
    public GameObject player;
    public Camera sceneCamera;
    public Image overlayImage;

    private void Start()
    {
        overlayImage.DOFade(0, 2f).OnComplete(StartSequence);
        
    }


    private void StartSequence()
    {
        StartCoroutine(nameof(Sequence));
    }
    
    IEnumerator Sequence()
    {
        foreach (var cutscene in cutSceneList)
        {
            sceneCamera.transform.DOMove(cutscene.CameraPosition,1f);
            
            yield return new WaitForSeconds(cutscene.lastTime);
        }
    }
}
