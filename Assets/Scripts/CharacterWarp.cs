using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CharacterWarp : MonoBehaviour
{
    private Vector3 destination;
    void FadeOutPlayer()
    {
        this.GetComponent<SpriteRenderer>().DOFade(0f, 1f);
    }

    void FadeInPlayer()
    {
        this.GetComponent<SpriteRenderer>().DOFade(1f, 1f);
    }

    void ChangePostion()
    {
        this.transform.position = destination;
    }

    public void Warp(Vector3 _destination)
    {
        destination = _destination;
        StartCoroutine(CoroutineWarp());
    }

    IEnumerator CoroutineWarp()
    {
        FadeOutPlayer();
        yield return new WaitForSeconds(1f);
        ChangePostion();
        FadeInPlayer();
    }
}
