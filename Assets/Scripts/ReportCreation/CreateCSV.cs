using System.IO;
using UnityEngine;

public static class CreateCSV
{

    private static string reportDirectoryName = "Report";
    private static string reportFileName = "report.csv";

    #region Interactions
    public static void AppendToReport(SimpleTest simpleTest)
    {
        VerifyFile();
        VerifyDirectory();
        
        
        Debug.Log("<color=red>Verified</color>");
        ExecuteReport data = new ExecuteReport(simpleTest);
        using (StreamWriter sw = File.AppendText(GetFilePath()))
        {
            foreach (var item in data.savedData)
            {
                sw.WriteLine("[{0} {1}]", item.Key, item.Value + ";");
            }

            Debug.Log("<color=red>Saved</color>");
        }
    }


    #endregion


    #region Operations

    private static void VerifyDirectory()
    {
        string dir = GetDirectoryPath();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }
    public static void VerifyFile()
    {
        string file = GetFilePath();
        if (File.Exists(file))
        {
           File.Delete(file);
        }


    }


    #endregion


    #region Queries

    static string GetDirectoryPath()
    {
        return Application.dataPath + "/" + reportDirectoryName;
    }

     static string GetFilePath()
    {
        return GetDirectoryPath() + "/" + reportFileName;
    }
    #endregion
}
