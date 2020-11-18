using System.IO;
using System.Linq;
using UnityEngine;

public static class CreateCSV
{

    private static string reportFileName = "report.csv";

    #region Interactions
    public static void AppendToReport(SimpleTest simpleTest)
    {
        VerifyFile();
        //Debug.Log("<color=red>Verified</color>");
        File.WriteAllLines(reportFileName, simpleTest.dataCollected.Select(x => x.Key + ";" + x.Value).ToArray());
        //Debug.Log("<color=red>Saved</color>");

    }


    #endregion


    #region Operations

    public static void VerifyFile()
    {
        string file = reportFileName;
        if (File.Exists(file))
        {
            File.Delete(file);
        }


    }


    #endregion
}
