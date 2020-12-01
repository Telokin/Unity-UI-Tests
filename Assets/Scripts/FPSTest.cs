using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class FPSTest : MonoBehaviour
{

    [SerializeField]
    private int maxLogCount = 16;

    #region Variables
    private float currentFPS = 0;
    private float startTime = 0;
    private int startFrame = 0;
    private int passedFrame = 0;
    private float passedTime = 0;
    private int logCount = 0;
    private Dictionary<int, float> dataCollected = new Dictionary<int, float>();
    #endregion


    #region Directories
    private static string reportFileName = "nothingOnCanvas.csv";
    private static string alphaZeroTest = "alphaZero.csv";
    private static string textTest = "textTest.csv";
    private static string cullingTestInCanvas = "inCanvasCulling.csv";
    private static string cullingTestOutCanvas = "outCanvasCulling.csv";
    private static string reportDirectoryName = "StreamingAssets";
    #endregion

    private TestUI testUI;

    private void Update()
    {

    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        startTime = Time.time;
        startFrame = Time.frameCount;
        #region Automatization
        //for (int j = 0; j<=4; j++)
        //{
        //    if (j == 1)
        //    {
        //dataCollected.Clear();
        //        logCount = 0;
        //        testUI.Test();
        //        yield return new WaitForSeconds(5f);
        //startTime = Time.time;
        //startFrame = Time.frameCount;
        //        reportFileName = alphaZeroTest;

        //    }else if(j == 2)
        //    {
        //        Destroy(testUI.alphaZeroCanvas);
        //dataCollected.Clear();
        //        logCount = 0;
        //        testUI.TestTextMeshPro();
        //        yield return new WaitForSeconds(5f);
        //startTime = Time.time;
        //startFrame = Time.frameCount;
        //        reportFileName = textTest;
        //    }
        //    else if(j == 3)
        //    {
        //        Destroy(testUI.textCanvas);
        //        testUI.TestCulling();
        //dataCollected.Clear();
        //        logCount = 0;
        //        yield return new WaitForSeconds(5f);
        //startTime = Time.time;
        //startFrame = Time.frameCount;
        //        reportFileName = cullingTestInCanvas;
        //    }
        //    else if(j == 4)
        //    {
        //        Destroy(testUI.cullingInCanvas);
        //        testUI.TestCulling2();
        //dataCollected.Clear();
        //        logCount = 0;
        //        yield return new WaitForSeconds(5f);
        //startTime = Time.time;
        //startFrame = Time.frameCount;
        //        reportFileName = cullingTestOutCanvas;
        //    }
        #endregion

        var directoryPath = Application.dataPath + "/" + reportDirectoryName;
        do
        {
            yield return new WaitForSeconds(2f);
            logCount++;
            passedFrame = Time.frameCount - startFrame;
            passedTime = Time.time - startTime;
            currentFPS = passedFrame / passedTime;
            dataCollected.Add(logCount, currentFPS);
            Debug.Log("<color=blue> Log: </color>" + logCount + "<color=yellow> FPS: </color>" + currentFPS);

            yield return null;
        }while (logCount < maxLogCount);
            logCount = 0;
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
        Debug.Break();
        yield return null;
    }
    //    yield return null;
    //}
}
