using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FadeText : MonoBehaviour, IFade
{
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        FadeIn();
    }

    public void FadeIn()
    {
        text.DOFade(1, 2f);
    }

    public void FadeOut()
    {
        text.DOFade(0, 2f);
    }
}
