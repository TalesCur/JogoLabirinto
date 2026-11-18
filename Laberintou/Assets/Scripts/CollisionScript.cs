using UnityEngine;
using UnityEngine.Tilemaps;
public class CollisionScript : MonoBehaviour
{
    public GameObject sp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<TilemapRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
