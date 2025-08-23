using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public float speed;
    private bool IsWalking;


    private Rigidbody2D rb;
    private Transform player;
    private Animator animator;

    private float LastInputX;
    private float LastInputY;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (IsWalking == true)
        {                                           //pozitia slime
            Vector2 direction = (player.position - transform.position).normalized; 
            rb.linearVelocity = direction * speed;
            animator.SetFloat("InputX", direction.x);
            animator.SetFloat("InputY", direction.y);

            if (direction.magnitude > 0f)
            {
                LastInputX = direction.x;
                LastInputY = direction.y;
            }
        }
        else
        {
            animator.SetFloat("LastInputX", LastInputX);
            animator.SetFloat("LastInputY", LastInputY);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(player == null)
            {
                player = collision.transform;
            }
            animator.SetBool("IsWalking", true);
            IsWalking = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetBool("IsWalking", false);
            IsWalking = false;

        }

    }
}
