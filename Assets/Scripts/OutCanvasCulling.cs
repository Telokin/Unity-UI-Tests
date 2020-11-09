using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutCanvasCulling : MonoBehaviour
{
    Vector3 pos;
    float x, y, z;
    int i = 0;
    [SerializeField]
    private Image outCanvas;
    void Start()
    {
        TestCulling2();

    }

    private void TestCulling2()
    {
        for(i = 0; i <= 10000; i++)
        {
            GameObject canvas = GameObject.Find("Test");
            Image hit = Instantiate(outCanvas, transform.position, Quaternion.identity);
            hit.transform.SetParent(canvas.transform, false);
            x = Random.Range(-1000, -100);
            y = Random.Range(0, 1000);
            z = 0;
            pos = new Vector3(x, y, z);
            hit.transform.position = pos;
        }
        
        
    }
}
