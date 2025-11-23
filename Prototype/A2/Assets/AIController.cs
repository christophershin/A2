using UnityEngine;
using UnityEngine.AI;

public class NavController : MonoBehaviour
{
    
    private NavMeshAgent theAgent;
    private GameObject theTarget;
    public float maxTargetDistance;
    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {


        if (theTarget)
        {
            float dis = Vector3.Distance(transform.position, theTarget.transform.position);

            if(dis>=maxTargetDistance)
            {
                theTarget = null;
            }
            else
            {
                theAgent.destination = theTarget.transform.position;
            }  
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if(theTarget==null)
        {
            if (other.gameObject.CompareTag("Vehicle"))
            {
                if (other.gameObject.GetComponent<NavTarget>().isOccupied == false)
                {
                    theTarget = other.gameObject;
                    other.gameObject.GetComponent<NavTarget>().isOccupied = true;
                }

            }
        }
    }

}
