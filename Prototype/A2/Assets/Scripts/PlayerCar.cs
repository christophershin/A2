using System.Collections.Generic;
using DitzelGames.FastIK;
using NUnit.Framework;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{

    public GameObject hand;
    bool isHoldingItem;
    public List<GameObject> items = new List<GameObject>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isHoldingItem)
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
            isHoldingItem = true;
        }
    }
}
