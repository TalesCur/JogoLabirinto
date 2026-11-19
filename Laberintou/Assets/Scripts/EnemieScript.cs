using UnityEngine;

public class EnemieScript : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject target;
    public AudioSource aSource;
    public bool Awakened = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        aSource.spatialBlend = 1f;
        aSource.volume = 1.5f;
        aSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && Awakened){

            agent.SetDestination(target.transform.position);
        }
    }
}
