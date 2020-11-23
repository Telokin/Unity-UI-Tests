using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class FPSTest : MonoBehaviour
{
    [SerializeField]
    private int maxLogCount = 16;

    [SerializeField]
    private float saveEverySample = 0;

    private float currentFPS;
    private float startTime;
    private float startFrame;
    private float avgFPS;

    private int logs = 0;
    private int logCount = 0;
    private int i;
    private Dictionary<int, float> dataCollected = new Dictionary<int, float>();

    private static string reportFileName = "report.csv";
    private static string reportDirectoryName = "StreamingAssets";

    void Update()
    {
        
        //Debug.LogWarning("<color=red>Log</color>" + logs++);
        //Debug.LogWarning("<color=yellow>Log</color>" + logs++);
        //Debug.LogWarning("<color=blue>Log</color>" + logs++);

            for (i = 0; i < 1000; i++)
            {
                Debug.LogWarning(logs++);
            }



    }
    private IEnumerator Start()
    {
        startTime = Time.time;
        startFrame = Time.frameCount;
        //dataCollected.Clear();
        var directoryPath = Application.dataPath + "/" + reportDirectoryName;
        do
        {
            yield return new WaitForSeconds(1f);
            //Debug.Log("TestLog nr " + logCount);
            logCount++;
            currentFPS = (float)Time.frameCount / Time.time;
            avgFPS += currentFPS;
            if (logCount % saveEverySample == 0)
            {
                currentFPS = (avgFPS/ saveEverySample) - (startTime/startFrame);
                dataCollected.Add(logCount, currentFPS);
                avgFPS = 0;
               Debug.Log("<color=green>DataCount: </color>" + dataCollected.Count + " | LogCount: " + logCount + " | CurrentFPS: " + currentFPS);
                yield return null;
            }

            yield return null;
        }while (logCount < maxLogCount);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            File.WriteAllLines(directoryPath + "/" + reportFileName, dataCollected.Select(x => x.Key + ";" + x.Value).ToArray());
        }
        else
        {
            File.Delete(reportFileName);
            File.WriteAllLines(directoryPath + "/" + reportFileName, dataCollected.Select(x => x.Key + ";" + x.Value).ToArray());
        }
        Debug.Log("Save");
        Debug.Break();
        yield return null;
    }
}
