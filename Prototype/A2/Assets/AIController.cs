using UnityEngine;
using UnityEngine.AI;

public class NavController : MonoBehaviour
{
    public GameObject theTarget;
    private NavMeshAgent theAgent;
    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        theAgent.destination = theTarget.transform.position;
    }
}
