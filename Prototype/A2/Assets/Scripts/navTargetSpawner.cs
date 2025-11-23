using System.Collections.Generic;
using NUnit.Framework;
using Unity.Splines.Examples;
using UnityEngine;
using UnityEngine.Splines;

public class navTargetSpawner : MonoBehaviour
{

    public GameObject navTargetwithOffset;
    public int maxTargetWithOffset;
    public SplineContainer splineContainer1;
    public SplineContainer splineContainer2;
    public SplineContainer splineContainer3;
    private List<GameObject> targetsWithoffset = new List<GameObject>();




    public float maxTimer;
    private float timer;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(timer<=0)
        {
            if (targetsWithoffset.Count <= maxTargetWithOffset)
            {
                GameObject obj = Instantiate(navTargetwithOffset, transform);
                GameObject obj2 = Instantiate(navTargetwithOffset, transform);
                obj.GetComponent<AnimateCar>().m_SplineContainer = splineContainer1;
                obj2.GetComponent<AnimateCar>().m_SplineContainer = splineContainer2;
                targetsWithoffset.Add(obj);
                targetsWithoffset.Add(obj2);
                timer = maxTimer;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
