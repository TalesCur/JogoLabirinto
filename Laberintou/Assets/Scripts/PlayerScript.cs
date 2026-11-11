using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 3f;
    public float accceleration = .5f;
    public Rigidbody2D rb;
    private Vector2 velocity = new Vector2(0f, 0f);
    public GameObject sr;
    private bool isMoving = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //sr = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Animations();
    }   
    
    void Move()
    {
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
        
        if (isMoving){

            an.Play("PlayerRun");
        }else{

            an.Play("PlayerIdle");
        }
    }

    void OnTriggerEnter2D(Collider2D col){

        if(col.CompareTag("Key")){

            col.gameObject.GetComponent<KeyScript>().Collect();
        }
    }
}
