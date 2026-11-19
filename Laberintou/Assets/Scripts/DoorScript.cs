using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject indicator;
    private bool indShowing;
    private int keys = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (!indicator){

            return;
        }
        if (indShowing){
            
            //Position
            indicator.transform.position = new Vector3(
                indicator.transform.position.x,
                Mathf.Lerp(indicator.transform.position.y, 2.9f, .02f),
                indicator.transform.position.z);

            //Color
            Color col = indicator.GetComponent<SpriteRenderer>().color;
            col.a = Mathf.Lerp(col.a, 1f, .02f);
            indicator.GetComponent<SpriteRenderer>().color = col;
        }else{

            //Position
            indicator.transform.position = new Vector3(
                indicator.transform.position.x,
                Mathf.Lerp(indicator.transform.position.y, 2.3f, .02f),
                indicator.transform.position.z);
            
            //Color
            Color col = indicator.GetComponent<SpriteRenderer>().color;
            col.a = Mathf.Lerp(col.a, 0f, .05f);
            indicator.GetComponent<SpriteRenderer>().color = col;
        }
    }

    void OnTriggerEnter2D(Collider2D col){

        if (col.CompareTag("Player"))
        {
            indShowing = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){

        if (col.CompareTag("Player"))
        {
            indShowing = false;
        }
    }

    public void Lock(){

        keys++;
    }
}
