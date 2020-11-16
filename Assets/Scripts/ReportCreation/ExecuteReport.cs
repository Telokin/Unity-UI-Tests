using System.Collections.Generic;
[System.Serializable]
public class ExecuteReport
{
    public Dictionary<int, int> savedData = new Dictionary<int, int>();
    public ExecuteReport(SimpleTest simpleTest)
    {
        savedData = simpleTest.dataCollected;
    }

}
