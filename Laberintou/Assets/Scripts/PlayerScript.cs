using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public float speed = 3f;
    public float accceleration = .5f;
    public Rigidbody2D rb;
    private Vector2 velocity = new Vector2(0f, 0f);
    public GameObject sr;
    private bool isMoving = false;
    public GameObject Track = null;
    private bool picking = false;
    private GameObject key;
    private int keys;
    private GameObject inDoor = null;
    [SerializeField] public TMP_Text key_text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //sr = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //stransform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);

        Animations();

        if(Input.GetKeyDown(KeyCode.E) && inDoor && keys > 0){
            
            Debug.Log("Apertei");
            lostKey();
            inDoor.GetComponent<DoorScript>().Lock();
        }
    }   
    
    void Move()
    {
        if (picking){

            rb.linearVelocity = new Vector2(0f, 0f);
            return;
        }
        float h_spd = Input.GetAxisRaw("Horizontal");
        float v_spd = Input.GetAxisRaw("Vertical");
        velocity = new Vector2(h_spd*speed, v_spd*speed);
        rb.linearVelocity = velocity;
        
        if (h_spd < 0){

            sr.transform.localScale = new Vector3(-1, 1, 1);
        }else if (h_spd > 0){

            sr.transform.localScale = new Vector3(1, 1, 1);
        }

        if (h_spd != 0 || v_spd != 0){

            isMoving = true;           
        }else{isMoving = false;}
    }

    void Animations()
    {
        Animator an = sr.GetComponentInChildren<SpriteRenderer>().GetComponent<Animator>();
        
        if (picking){

            AnimatorStateInfo info = an.GetCurrentAnimatorStateInfo(0);
            an.Play("PlayerPicking");

            if (info.IsName("PlayerPicking") && info.normalizedTime >= 1f){
                
                key.GetComponent<KeyScript>().Collect(Track);
                getKey();
                picking = false;
                key = null;
            }
        }else{

            if (isMoving){

                an.Play("PlayerRun");
            }else{

                an.Play("PlayerIdle");
            }
        }
    }

    void getKey(){

        keys++;
        key_text.text = $"{keys}/3";
    }
    void lostKey(){

        keys--;
        key_text.text = $"{keys}/3";
    }
    void OnTriggerEnter2D(Collider2D col){

        Animator an = sr.GetComponentInChildren<SpriteRenderer>().GetComponent<Animator>();
        if(keys < 3 && col.CompareTag("Key") && !picking){

            key = col.gameObject;
            key.GetComponent<KeyScript>().Track(Track);
            picking = true;
        }else if(col.CompareTag("Door")){

            inDoor = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Door")){

            inDoor = null;
        }
    }
}
