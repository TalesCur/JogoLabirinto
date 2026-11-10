using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(
        Mathf.Lerp(transform.position.x, target.transform.position.x, 0.01f),
        Mathf.Lerp(transform.position.y, target.transform.position.y, 0.01f),
        transform.position.z);
    }
}
