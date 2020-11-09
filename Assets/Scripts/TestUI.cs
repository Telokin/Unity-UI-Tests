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
    private TextMeshProUGUI testText;

    Vector3 pos;
    float x, y, z;

    public Text fpsText;
    public float deltaTime;
    int i = 0;

    // Start is called before the first frame update

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString();

        
        Debug.Log(Time.time);
    }



    void Start()
    {
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
        GameObject canvas = GameObject.Find("Child");
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

        for (i = 0; i <= 500; i++)
        {
            Image hit = Instantiate(inCanvas, transform.position, Quaternion.identity);
            hit.transform.SetParent(canvas.transform, false);
            x = Random.Range(0, 1000);
            y = Random.Range(0, 400);
            z = 0;
            pos = new Vector3(x, y, z);
            hit.transform.position = pos;
        }

    }

    



}
