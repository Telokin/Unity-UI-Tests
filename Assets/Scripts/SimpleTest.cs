using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimpleTest : MonoBehaviour
{
    #region Out of use
    [SerializeField]
    private TextMeshProUGUI testTextOne = null;

    [SerializeField]
    private TextMeshProUGUI testTextTwo = null;

    [SerializeField]
    private int maxLogCount = 200;

    private int logCount = 0;
    private int currentFPS =0;
    public Dictionary<int, int> dataCollected = new Dictionary<int, int>();

    private void Update()
    {
        if (logCount >= maxLogCount)
            return;

        AddLog();
        
    }

    public void AddLog()
    {
        currentFPS = (int)(1 / Time.unscaledDeltaTime);
        //testTextOne.text = "TestLog nr " + (logCount + 1).ToString();
        //testTextTwo.text = "FPS: " + currentFPS.ToString();
        Debug.Log("TestLog nr " + logCount + 1);
        logCount++;

        //if (logCount % 100 == 0)
            AddData();
    }

    public void AddData()
    {
        currentFPS = (int)(1 / Time.unscaledDeltaTime);
        dataCollected.Add(logCount, currentFPS);
        //Debug.Log("<color=green>DataCount: </color>" + dataCollected.Count + " | LogCount: " + logCount + " | CurrentFPS: " + currentFPS);
        if(logCount % maxLogCount == 0)
        {
            CreateCSV.AppendToReport(this);
            //Debug.Log("<color=yellow>File created</color>");
        }
    }
    #endregion
}
