using UnityEngine;

public class ReEnableCube : MonoBehaviour
{


    public GameObject child;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(!child.activeSelf)
        {
            timer -= Time.deltaTime;
        }

        if (child.activeSelf)
        {
            timer = 2f;
        }


        if (timer <= 0)
        {
            child.SetActive(true);
        }
    }
}
