using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FadeImage : MonoBehaviour, IFade
{
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
        FadeIn();
    }

    public void FadeIn()
    {
        gameObject.SetActive(true);
        image.DOFade(1, 2f);
    }

    public void FadeOut()
    {
        StartCoroutine(DisableObject());
    }

    IEnumerator DisableObject()
    {
        Tween hideTween = image.DOFade(0, 2f);
        while (hideTween.active)
        {
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
