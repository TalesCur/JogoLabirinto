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
        }else{

            transform.position = new Vector3(transform.position.x, transform.position.y+Mathf.Sin(Time.time)*.0005f, transform.position.z);
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
