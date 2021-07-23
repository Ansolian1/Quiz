using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CellClickHandler))]
public class CellsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Transform cellsContainer;
    private CellClickHandler cellClickHandler;
    private List<ObjectInformation> usedObjects;

    private GameObject cellObject;
    private Cell cell;

    private void Awake()
    {
        usedObjects = new List<ObjectInformation>();
        cellClickHandler = GetComponent<CellClickHandler>();
    }

    public void SpawnCells(int cellsCount, List<ObjectInformation> objects, ObjectInformation targetObject, bool showEffects)
    {
        int targetObjectPosition = Random.Range(0, cellsCount);
        ClearCellContainer();
        for (int i = 0; i < cellsCount; i++)
        {
            if (i == targetObjectPosition)
            {
                SpawnCell(targetObject, showEffects);
                continue;
            }

            ObjectInformation currentObject = objects[Random.Range(0, objects.Count)];
            if (currentObject == targetObject || usedObjects.Contains(currentObject))
            {
                i--;
                continue;
            }

            SpawnCell(currentObject, showEffects);
            usedObjects.Add(currentObject);
        }

        usedObjects = new List<ObjectInformation>();
    }

    private void SpawnCell(ObjectInformation targetObject, bool showEffects)
    {
        cellObject = Instantiate(cellPrefab, cellsContainer.transform);
        cell = cellObject.GetComponent<Cell>();
        cell.SetData(targetObject, cellClickHandler);
        if (showEffects)
        {
            usedObjects.Add(targetObject);
            cell.BounceObjectEffect(cellObject.transform);
        }
    }

    private void ClearCellContainer()
    {
        for (int i = 0; i < cellsContainer.childCount; i++)
        {
            Destroy(cellsContainer.GetChild(i).gameObject);
        } 
    }
}
