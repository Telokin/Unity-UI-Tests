using System.IO;
using UnityEngine;

public class CreateCSV : MonoBehaviour
{
    private SimpleTest simpleTest;

    private static string reportDirectoryName = "Report";
    private static string reportFileName = "report.csv";
    //private string reportSeparator = ";";
    //private static string timeStampHeader = "time stamp";

    #region Interactions

    public void AppendToReport()
    {
        VerifyDirectory();
        //VerifyFile();
        using (StreamWriter sw = File.AppendText(GetFilePath()))
        {
                foreach (var entry in simpleTest.dataCollected)
                    sw.WriteLine("[{0} {1};]", entry.Key, entry.Value);
        }
    }

    //public void CreateReport()
    //{
    //    VerifyDirectory();
    //    using (StreamWriter sw = File.CreateText(GetFilePath()))
    //    {
    //        //string finalString = "";
    //        //for (int i = 0; i < reportHeaders.Length; i++)
    //        //{
    //        //if (finalString != "")
    //        //    {
    //        //        finalString += reportSeparator;
    //        //    }
    //        ////    finalString += reportHeaders[i];
    //        ////}
    //        //finalString += reportSeparator + timeStampHeader;
    //        //sw.WriteLine(finalString);
    //    }
    //}

    #endregion


    #region Operations

     void VerifyDirectory()
    {
        string dir = GetDirectoryPath();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    //void VerifyFile()
    //{
    //    string file = GetFilePath();
    //    if (!File.Exists(file))
    //    {
    //        CreateReport();
    //    }
    //    else
    //    {
    //        CreateReport();
    //    }
    //}

    #endregion


    #region Queries

     string GetDirectoryPath()
    {
        return Application.dataPath + "/" + reportDirectoryName;
    }

     string GetFilePath()
    {
        return GetDirectoryPath() + "/" + reportFileName;
    }

    //static string GetTimeStamp()
    //{
    //    return System.DateTime.UtcNow.ToString();
    //}

    #endregion
}
