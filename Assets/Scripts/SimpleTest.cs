using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimpleTest : MonoBehaviour
{
    private CreateCSV createCSV;

    [SerializeField]
    private TextMeshProUGUI testTextOne = null;

    [SerializeField]
    private TextMeshProUGUI testTextTwo = null;

    private readonly int maxLogCount = 200;
    public string test;
    public int logCount = 0;
    public Dictionary<int, int> dataCollected = new Dictionary<int, int>();

    private void Update()
    {
        if (logCount >= maxLogCount)
            return;

        AddLog();
        
    }

    public void AddLog()
    {
        int currentFPS = (int)(1 / Time.unscaledDeltaTime);
        testTextOne.text = "TestLog nr " + (logCount + 1).ToString();
        testTextTwo.text = "FPS: " + currentFPS.ToString();
        //Debug.Log("TestLog nr " + logCount + 1);
        logCount++;

        if (logCount % 100 == 0)
            AddData();
    }

    public void AddData()
    {
        int currentFPS = (int)(1 / Time.unscaledDeltaTime);
        dataCollected.Add(logCount, currentFPS);
        
        //Debug.LogWarning("DataCount: " + dataCollected.Count + " | LogCount: " + logCount + " | CurrentFPS: " + currentFPS);
        Debug.Log("<color=green>DataCount: </color>" + dataCollected.Count + " | LogCount: " + logCount + " | CurrentFPS: " + currentFPS);
        if (logCount % 200 == 0)
        {
            createCSV.AppendToReport();
            Debug.Log("<color=green>Raport created</color>");
        }
    }

}
