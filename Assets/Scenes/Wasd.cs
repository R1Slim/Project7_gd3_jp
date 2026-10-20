using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public List list = new List();
    public int timer;
    public Vector2 vector2;
    public int MaxJump;
    public int jumpCounter;
    public bool onPlatform;
    public Rigidbody2D PlrRB;
    public BoxCollider2D PlrBC;
    public float speed = 5f;
    public float force  = 5f;
    public LayerMask  Mask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlrRB = GetComponent<Rigidbody2D>();
        PlrBC = GetComponent<BoxCollider2D>();
    }
    private void Awake()
    {
        Mask = LayerMask.GetMask("Platforms");
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
       
    }
     void FixedUpdate()
    {
        groundCheck();
    }
    public void Movement()
    {
        float H = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(H, PlrRB.linearVelocityY);
        PlrRB.linearVelocity = Vector2.Lerp(PlrRB.linearVelocity, movement, 0.1f);
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlrRB.AddForce(transform.up * force, ForceMode2D.Impulse);
            jumpCounter -= 1;
        }

        
    }
    public void groundCheck()
    {
       

        RaycastHit2D hit = Physics2D.Raycast(PlrRB.position, Vector2.down, 0.75f, Mask);
        if(hit)
        {
            var currentblock = hit.collider;
        }
        Debug.DrawRay(PlrRB.position, Vector2.down * 0.75f, Color.blue);
        
    }

}   
