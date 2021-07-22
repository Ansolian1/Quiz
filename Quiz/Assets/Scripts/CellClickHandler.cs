using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelState))]
public class CellClickHandler : MonoBehaviour
{
    private LevelState levelState;

    private void Awake()
    {
        levelState = GetComponent<LevelState>();
    }

    public void CellClicked(ObjectInformation cellObjectInformation, Cell cell)
    {
        if (levelState.IsRightAnswer(cellObjectInformation))
        {
            cell.RightAnswerClicked();
        }
        else
        {
            cell.WrongAnswerClicked();
        }
    }
}
