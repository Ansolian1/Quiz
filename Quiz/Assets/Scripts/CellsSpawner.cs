using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CellClickHandler))]
public class CellsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Transform cellsContainer;
    public CellClickHandler cellClickHandler;

    private void Awake()
    {
        cellClickHandler = GetComponent<CellClickHandler>();
    }

    public void SpawnCells(int cellsCount, List<ObjectInformation> informations, ObjectInformation targetObject)
    {
        int targetObjectPosition = Random.Range(0, cellsCount);
        for (int i = 0; i < cellsCount; i++)
        {
            GameObject cell = Instantiate(cellPrefab, cellsContainer.transform);
            if (i == targetObjectPosition)
            {
                cell.GetComponent<Cell>().SetData(targetObject, cellClickHandler);
                continue;
            }
            cell.GetComponent<Cell>().SetData(informations[Random.Range(0, informations.Count)], cellClickHandler);
        }
    }
}
