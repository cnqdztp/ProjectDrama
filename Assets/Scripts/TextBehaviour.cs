using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Febucci.UI;
using TMPro;
using UnityEngine;

public class TextBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject textObject;
    private static bool debugMode =false;
    public bool isDebugHelper = false;
    public float timeForTextRemain = 3f;
    public float fadeOutDistance = 1f,fadeOutDuration = 1f;
    public bool untilPlayerLeavesTextRemain = false;
    [TextArea] public string textToShow;

    private void Awake()
    {
        debugMode = isDebugHelper;
        textObject = transform.GetChild(0).gameObject;
        if (!debugMode)
        {
            textObject.SetActive(false);
        }
    }

    public void ShowText()
    {
        textObject.SetActive(true);
        textObject.GetComponent<TextAnimatorPlayer>().ShowText(textToShow);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowText();
            if (!untilPlayerLeavesTextRemain)
            {
                StartCoroutine(Move());
            }
        }
    }

    IEnumerator Move()
    {
        if (!untilPlayerLeavesTextRemain)
        {
            yield return new WaitForSeconds(timeForTextRemain);
        }
        FadeOutText();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && untilPlayerLeavesTextRemain)
        {
            StartCoroutine(Move());

        }
    }

    private void FadeOutText()
    {
        StopAllCoroutines();
        textObject.GetComponent<TextMeshPro>().DOFade(0, fadeOutDuration);
        textObject.transform.DOMove(transform.position + new Vector3(fadeOutDistance, 0, 0), fadeOutDuration)
            .SetEase(Ease.OutQuad).OnComplete(DisableText);
    }
    
    private void DisableText()
    {
        textObject.SetActive(false);
    }
}