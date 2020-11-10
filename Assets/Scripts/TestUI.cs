using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class TestUI : MonoBehaviour
{

    [SerializeField]
    private Image inCanvas;

    [SerializeField]
    private GameObject canvas = null;

    [SerializeField]
    private TextMeshProUGUI fpsText = null;

    float avgFramerate;
    string display = "{0} FPS";
    int i = 0;

    private Coroutine saveFps = null;

    // Start is called before the first frame update

    void Update()
    {
        avgFramerate = 1 / Time.unscaledDeltaTime;
        fpsText.text = string.Format(display, avgFramerate.ToString());
    }



    void Start()
    {
        saveFps = StartCoroutine(SaveIt());
        //Test();
        //TestTextMeshPro();
        //TestCulling();
        //Debug.Log(Time.realtimeSinceStartup);

    }

    private void Test()
    {
        //var tempColor = image.color;
        //tempColor.a = 0;
        //image.color = tempColor;
        //Debug.LogWarning(image);
    }

    private void TestTextMeshPro()
    {
        //GameObject canvas = GameObject.Find("Canvas");
        //TextMeshProUGUI hit = Instantiate(testText, transform.position, Quaternion.identity);
        //hit.transform.SetParent(canvas.transform, false);
        //hit.transform.position = transform.position;
    }

    private void TestCulling()
    {

        //if (Time.deltaTime <= 10)
        //{

        //        Image hit = Instantiate(inCanvas, transform.position, Quaternion.identity);
        //        hit.transform.SetParent(canvas.transform, false);
        //        x = Random.Range(0, 1000);
        //        y = Random.Range(0, 400);
        //        z = 0;
        //        pos = new Vector3(x, y, z);
        //        hit.transform.position = pos;


        //}

        float x, y, z = 0;
        for (int i = 0; i <= 100; i++)
        {
            x = UnityEngine.Random.Range(-1000, -100);
            y = UnityEngine.Random.Range(0, 1000);
            inCanvas = Instantiate(inCanvas, new Vector3(x, y, z), Quaternion.identity, canvas.transform);
        }
    }

    private IEnumerator SaveIt()
    {
        int i = 0;

        for(i=0; i<=100; i++)
        {
            yield return new WaitForSeconds(5);
            // Save current fps in csv file
        }

        yield return null;
    }

    



}
