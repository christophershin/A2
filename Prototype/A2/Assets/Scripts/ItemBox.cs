using UnityEditor.UIElements;
using UnityEngine;

public class ItemBox : MonoBehaviour
{

    [SerializeField] GameObject itemBox;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemBox.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Car")
        {
            itemBox.SetActive(false);
        }
    }
}
