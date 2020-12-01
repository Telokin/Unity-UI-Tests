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
    public GameObject alphaZeroCanvas = null;

    [SerializeField]
    public GameObject textCanvas = null;

    [SerializeField]
    public GameObject cullingInCanvas = null;


    [SerializeField]
    private GameObject canvasOut = null;

    [SerializeField]
    private int amountOfImages;

    [SerializeField]
    private TextMeshProUGUI testText = null;

    #endregion
    private float x, y, z = 0;

    private void Start()
    {
        Test();
    }

    #region Tests
    public void Test()
    {
        var tempColor = image.color;
        tempColor.a = 0;
        image.color = tempColor;
        for (int i = 0; i <= amountOfImages; i++)
        {
            x = UnityEngine.Random.Range(0, 600);
            y = UnityEngine.Random.Range(0, 300);
            image = Instantiate(image, new Vector3(x, y, z), Quaternion.identity, alphaZeroCanvas.transform);
        }
    }

    public void TestTextMeshPro()
    {
        testText = Instantiate(testText, transform.position, Quaternion.identity, textCanvas.transform);
    }


    public void TestCulling()
    {


        for (int i = 0; i <= amountOfImages; i++)
        {
            x = UnityEngine.Random.Range(0, 600);
            y = UnityEngine.Random.Range(0, 300);
            image = Instantiate(image, new Vector3(x, y, z), Quaternion.identity, cullingInCanvas.transform);
        }
    }

    public void TestCulling2()
    {

        
        for (int i = 0; i <= amountOfImages; i++)
        {
            x = UnityEngine.Random.Range(-1000, -100);
            y = UnityEngine.Random.Range(0, 1000);
            image = Instantiate(image, new Vector3(x, y, z), Quaternion.identity, canvasOut.transform);
        }
    }
    #endregion
}
