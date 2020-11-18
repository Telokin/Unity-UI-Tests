using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class FPSTest : MonoBehaviour
{
    [SerializeField]
    private int maxLogCount = 16;

    private float currentFPS;
    private float start;
    private int logCount = 0;
    private Dictionary<int, float> dataCollected = new Dictionary<int, float>();

    private static string reportFileName = "report.csv";
    private static string reportDirectoryName = "StreamingAssets";
    private IEnumerator Start()
    {
        start = Time.frameCount/Time.time;
        var directoryPath = Application.dataPath + "/" + reportDirectoryName;
        Debug.Log("<color=red>FrameCount</color>");
        Debug.Log(directoryPath + "/" + reportFileName);
        do
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("TestLog nr " + logCount);
            logCount++;
            currentFPS = Time.frameCount/Time.time;
            //dataCollected.Add(logCount, currentFPS);

            if (logCount % 5 == 0)
            {
                currentFPS = currentFPS - start;
                dataCollected.Add(logCount, currentFPS);
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
            File.WriteAllLines(directoryPath + "/" + reportFileName, dataCollected.Select(x => x.Key + ";" + x.Value).ToArray());
        }
        Debug.Log("Save");
        yield return null;
    }
}
