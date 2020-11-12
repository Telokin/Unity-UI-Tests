using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExecuteReport
{
    public static SimpleTest simpleTest;
    [MenuItem("My Tools/1. Add Defaults To Report %F1")]
    static void DEV_AppendDefaultsToReport()
    {
        CreateCSV.AppendToReport(
            new string[1] {
                ""
            }
        );
        EditorApplication.Beep();
        Debug.Log("<color=green>Report updated successfully!</color>");
    }

    [MenuItem("My Tools/2. Reset Report %F12")]
    static void DEV_ResetReport()
    {
        CreateCSV.CreateReport();
        EditorApplication.Beep();
        Debug.Log("<color=orange>The report has been reset...</color>");
    }

}
