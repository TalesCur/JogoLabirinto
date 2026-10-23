using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 3f;
    public float accceleration = .5f;
    public Rigidbody2D rb;
    private Vector2 velocity = new Vector2(0f, 0f);
    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }   
    
    void Move()
    {
        float h_spd = Input.GetAxis("Horizontal");
        float v_spd = Input.GetAxis("Vertical");
        velocity = new Vector2(h_spd*speed, v_spd*speed);
        rb.linearVelocity = velocity;

        if (h_spd < 0){

            sr.flipX = true;
        }else if (h_spd > 0){

            sr.flipX = false;
        }
    }
}
