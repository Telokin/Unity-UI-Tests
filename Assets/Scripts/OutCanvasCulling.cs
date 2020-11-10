using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutCanvasCulling : MonoBehaviour
{
    
    
    [SerializeField]
    private Image outCanvas;

    [SerializeField]
    private GameObject canvas = null;


    void Start()
    {
        TestCulling2();
    }

    private void TestCulling2()
    {
        float x, y, z = 0;
        for (int i = 0; i <= 100; i++)
        {
            x = Random.Range(-1000, -100);
            y = Random.Range(0, 1000);
            outCanvas = Instantiate(outCanvas,new Vector3(x,y,z), Quaternion.identity, canvas.transform);
        }
        
        
    }

}
