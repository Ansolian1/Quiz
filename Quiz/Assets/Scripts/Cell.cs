using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Image cellContents;
    [SerializeField] private GameObject starParticles;
    private int _currentNumber;

    public void SetData(int currentNumber, Image currentImage)
    {
        _currentNumber = currentNumber;
        cellContents = currentImage;
    }

    public void WrongAnswerClick()
    {
        EaseInBounceEffect(cellContents.transform, 1f);
    }

    public void RightAnswerClick()
    {
        BounceObjectEffect(cellContents.transform);
        Instantiate(starParticles, transform.position + new Vector3(0, 0, -1), starParticles.transform.rotation);
    }

    private void BounceObjectEffect(Transform transform)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(new Vector2(0f, 0f), 0));
        sequence.Append(transform.DOScale(new Vector2(1.2f, 1.2f), 0.2f));
        sequence.Append(transform.DOScale(new Vector2(0.95f, 0.95f), 0.2f));
        sequence.Append(transform.DOScale(new Vector2(1f, 1f), 0.2f));
    }

    private void EaseInBounceEffect(Transform transform, float effectTime)
    {
        transform.DOShakePosition(effectTime, 3);
    }
}
