using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject indicator;
    private bool indShowing;
    public int keys = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!indicator){

            return;
        }
        if (indShowing){
            
            //Position
            indicator.transform.localPosition = new Vector3(
                indicator.transform.localPosition.x,
                Mathf.Lerp(indicator.transform.localPosition.y, 1f, .02f),
                indicator.transform.localPosition.z);

            //Color
            Color col = indicator.GetComponent<SpriteRenderer>().color;
            col.a = Mathf.Lerp(col.a, 1f, .02f);
            indicator.GetComponent<SpriteRenderer>().color = col;
        }else{

            //Position
            indicator.transform.localPosition = new Vector3(
                indicator.transform.localPosition.x,
                Mathf.Lerp(indicator.transform.localPosition.y, .3f, .02f),
                indicator.transform.localPosition.z);
            
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
        if (keys >= 7){

            GameManagerScript.Instance.NextLevel();
        }
    }
}
