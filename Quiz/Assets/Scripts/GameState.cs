using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    [SerializeField] private DataStore dataStore;
    [SerializeField] private FadeText targetText;
    [SerializeField] private FadeImage blackScreen;
    [SerializeField] private int dataSetCount = 2;

    private int currentStage = 0;
    private ObjectInformation rightAnswer;
    private List<ObjectInformation> dataSet;
    private List<ObjectInformation> usedTargetObjects;
    private CellsSpawner cellsSpawner;

    private void Awake()
    {
        cellsSpawner = GetComponent<CellsSpawner>();
        usedTargetObjects = new List<ObjectInformation>();
    }

    private void Start()
    {
        GetDataSet();
        StartStage(3, true);
    }

    private void GetDataSet()
    {
        int dataSetNumber = Random.Range(0, dataSetCount);
        switch (dataSetNumber)
        {
            case 0:
                dataSet = dataStore.letters;
                break;
            case 1:
                dataSet = dataStore.numbers;
                break;
        }
    }

    public void NextStage()
    {
        switch (currentStage)
        {
            case 0:
                currentStage++;
                StartStage(6);
                break;
            case 1:
                currentStage++;
                StartStage(9);
                break;
            case 2:
                currentStage = 0;
                ShowRestartMenu();
                break;
        }
    }

    private void CreateTargetObject()
    {
        rightAnswer = dataSet[Random.Range(0, dataSet.Count)];
        while (usedTargetObjects.Contains(rightAnswer))
        {
            rightAnswer = dataSet[Random.Range(0, dataSet.Count)];
        }

        usedTargetObjects.Add(rightAnswer);
    }

    public void ShowRestartMenu()
    {
        blackScreen.FadeIn();
        targetText.FadeOut();
    }

    public void StartStage(int cellsCount, bool showEffects = false)
    {
        CreateTargetObject();
        targetText.GetComponent<Text>().text = "Find " + rightAnswer.name;
        cellsSpawner.SpawnCells(cellsCount, dataSet, rightAnswer, showEffects);
    }

    public void RestartGame()
    {
        blackScreen.FadeOut();
        targetText.FadeIn();
        GetDataSet();
        StartStage(3, true);
    }

    public bool IsRightAnswer(ObjectInformation answer)
    {
        if(rightAnswer == answer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
