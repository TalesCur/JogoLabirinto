using UnityEngine;

public class KeyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject Tracking;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Tracking){

            transform.position = Tracking.transform.position;
        }
    }

    public void Track(GameObject trackObj)
    {
        Tracking = trackObj;
    }

    public void Collect(GameObject trackObj)
    {
        Destroy(gameObject);
    }
}
