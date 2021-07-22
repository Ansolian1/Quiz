using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FadeImage : MonoBehaviour
{
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
        FadeIn();
    }

    public void FadeIn()
    {
        image.DOFade(1, 2f);
    }

    public void FadeOut()
    {
        image.DOFade(0, 2f);
    }
}
