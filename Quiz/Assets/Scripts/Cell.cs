using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Image cellContents;
    [SerializeField] private GameObject starParticles;
    private ObjectInformation _currentInformation;
    private CellClickHandler _cellClickHandler;

    public void SetData(ObjectInformation currentInformation, CellClickHandler cellClickHandler)
    {
        _cellClickHandler = cellClickHandler;
        _currentInformation = currentInformation;
        cellContents.sprite = currentInformation.image;
    }

    public void CellClick()
    {
        _cellClickHandler.CellClicked(_currentInformation, this);
    }

    public void WrongAnswerClicked()
    {
        EaseInBounceEffect(cellContents.transform, 1f);
    }

    public void RightAnswerClicked()
    {
        BounceObjectEffect(cellContents.transform);
        Instantiate(starParticles, transform.position + new Vector3(0, 0, -1), starParticles.transform.rotation);
    }

    public void BounceObjectEffect(Transform transform)
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
