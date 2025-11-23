using System.Collections.Generic;
using DitzelGames.FastIK;
using NUnit.Framework;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{

    public GameObject hand;
    public Animator model;
    bool isHoldingItem;
    public List<GameObject> items = new List<GameObject>();
    public float itemHoldTimer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        if(itemHoldTimer<=0)
        {
            isHoldingItem = false;
        }
        else
        {
            itemHoldTimer -= Time.deltaTime;
        }

        if(itemHoldTimer>0 && itemHoldTimer<1f)
        {
            model.SetBool("CanThrow", true);
        }
        else
        {
            model.SetBool("CanThrow", false);
        }


        if (isHoldingItem)
        {
            hand.GetComponent<FastIKFabric>().enabled = true;
            items[0].SetActive(true);
        }
        else
        {
            hand.GetComponent<FastIKFabric>().enabled = false;
            items[0].SetActive(false);
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("MysteryCube"))
        {
            itemHoldTimer = 10f;
            isHoldingItem = true;
        }
    }
}
