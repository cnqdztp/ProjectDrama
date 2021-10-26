using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TextFadeout : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Fadeout());
    }

    IEnumerator Fadeout()
    {
        yield return new WaitForSeconds(3f);
        this.GetComponent<TextMeshPro>().DOFade(0f, 1f);
    }
}
