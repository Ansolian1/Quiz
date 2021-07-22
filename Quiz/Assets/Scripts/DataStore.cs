using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataStore : MonoBehaviour
{
    public List<ObjectInformation> letters;
    public List<ObjectInformation> numbers;
}

[Serializable]
public class ObjectInformation
{
    public Sprite image; 
    public string name;
}
