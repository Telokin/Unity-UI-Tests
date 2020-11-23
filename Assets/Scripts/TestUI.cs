using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class TestUI : MonoBehaviour
{
    #region SerializedFields
    [SerializeField]
    private Image image = null;

    [SerializeField]
    private GameObject canvas = null;

    [SerializeField]
    private GameObject canvasOut = null;

    [SerializeField]
    private int amountOfImages;

    [SerializeField]
    private TextMeshProUGUI testText = null;
    #endregion

    #region FPS visualization
    float avgFramerate;
    float startTime;
    float startFrame;
    
    // Start is called before the first frame update

    void Update()
    {
        
        //avgFramerate = Time.frameCount / Time.time;
        //avgFramerate = avgFramerate - (startTime/ startFrame);
        //Debug.Log(avgFramerate);
    }
    #endregion


    void Start()
    {
        //Test();
        //TestTextMeshPro();
        //TestCulling();
        TestCulling2();
        startTime = Time.time;
        startFrame = Time.frameCount;
    }

    #region Tests
    private void Test()
    {
        var tempColor = image.color;
        tempColor.a = 0;
        image.color = tempColor;
    }

    private void TestTextMeshPro()
    {
        testText = Instantiate(testText, transform.position, Quaternion.identity, canvas.transform);
    }


    private void TestCulling()
    {

        float x, y, z = 0;
        for (int i = 0; i <= amountOfImages; i++)
        {
            x = UnityEngine.Random.Range(0, 1);
            y = UnityEngine.Random.Range(0, 1);
            image = Instantiate(image, new Vector3(x, y, z), Quaternion.identity, canvas.transform);
        }
    }

    private void TestCulling2()
    {

        float x, y, z = 0;
        for (int i = 0; i <= amountOfImages; i++)
        {
            x = UnityEngine.Random.Range(-1000, -100);
            y = UnityEngine.Random.Range(0, 1000);
            image = Instantiate(image, new Vector3(x, y, z), Quaternion.identity, canvasOut.transform);
        }
    }
    #endregion
}
