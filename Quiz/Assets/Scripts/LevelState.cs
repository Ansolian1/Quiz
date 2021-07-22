using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelState : MonoBehaviour
{
    private CellsSpawner cellsSpawner;
    [SerializeField] private DataStore dataStore;

    private ObjectInformation rightAnswer;

    private void Awake()
    {
        cellsSpawner = GetComponent<CellsSpawner>();
    }

    private void Start()
    {
        rightAnswer = dataStore.letters[Random.Range(0, dataStore.letters.Count)];
        cellsSpawner.SpawnCells(3, dataStore.letters, rightAnswer);
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
