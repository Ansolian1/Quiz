using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameState))]
public class CellClickHandler : MonoBehaviour
{
    private GameState levelState;

    private void Awake()
    {
        levelState = GetComponent<GameState>();
    }

    public void CellClicked(ObjectInformation cellObjectInformation, Cell cell)
    {
        if (levelState.IsRightAnswer(cellObjectInformation))
        {
            cell.RightAnswerClicked();
            levelState.NextStage();
        }
        else
        {
            cell.WrongAnswerClicked();
        }
    }
}
