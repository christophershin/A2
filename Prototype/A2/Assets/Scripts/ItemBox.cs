using UnityEditor.UIElements;
using UnityEngine;

public class ItemBox : MonoBehaviour
{

    [SerializeField] GameObject Item;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {

            this.gameObject.SetActive(false);
        }
    }
}
