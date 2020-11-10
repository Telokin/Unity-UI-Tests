using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimpleTest : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI testTextOne = null;

    [SerializeField]
    private TextMeshProUGUI testTextTwo = null;

    private readonly int maxLogCount = 1000;
    int i = 0;
    private int logCount = 0;
    private Dictionary<int, int> dataCollected = new Dictionary<int, int>();

    private void Update()
    {
        if (logCount >= maxLogCount)
            return;

        AddLog();
    }

    private void AddLog()
    {

        testTextOne.text = "TestLog nr " + (logCount + 1).ToString();
        testTextTwo.text = "FPS: " + (int)(1 / Time.unscaledDeltaTime);
        Debug.Log("TestLog nr " + logCount + 1);
        logCount++;

        if (logCount % 100 == 0)
            AddData();
    }

    private void AddData()
    {
        dataCollected.Add(logCount, (int)(1 / Time.unscaledDeltaTime));
       Debug.LogWarning("DataCount: " + dataCollected.Count + " | LogCount: " + logCount + " | CurrentFPS: " + (int)(1 / Time.unscaledDeltaTime));


    }

}
