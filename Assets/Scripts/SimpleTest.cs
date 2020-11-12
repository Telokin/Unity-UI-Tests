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
    public string test;
    public int logCount = 0;
    public static Dictionary<int, int> dataCollected = new Dictionary<int, int>();

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
        foreach (KeyValuePair<int, int> thisKey in dataCollected)
        {
            test += string.Format("{0}, {1}\n", thisKey.Key, thisKey.Value);
        }
        //Debug.LogWarning("DataCount: " + dataCollected.Count + " | LogCount: " + logCount + " | CurrentFPS: " + currentFPS);
        Debug.Log("<color=green>Test data: </color>" + test);
    }

    public static void Test()
    {
        
    }

}
