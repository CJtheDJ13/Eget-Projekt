using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine.Scripting.APIUpdating;
using System.Runtime.CompilerServices;
using UnityEditor.Tilemaps;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float speed = 1f;

    [SerializeField]
    float jumpForce = 5f;

    [SerializeField]
    GameObject groundChecker;

    [SerializeField]
    LayerMask groundLayer;

    public Animator anim;
    private float move;

    void Start()
    {
    }

    void Update()
    {
    // MOVE
        float InputX = Input.GetAxisRaw("Horizontal");
        Vector2 movement = Vector2.right * InputX;
        transform.Translate(movement * speed * Time.deltaTime);

        move = Input.GetAxisRaw("Horizontal");

    // ANIMATOR
        if (move >= 0.1f || move < -0.1f)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

    // FLIP SPRITE
        if (move > 0.1f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (move < -0.1f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

    }

    void FixedUpdate()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundChecker.transform.position, 1f, groundLayer);

        if (Input.GetKey(KeyCode.Space) && isGrounded == true || Input.GetKey(KeyCode.W) && isGrounded == true)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            Destroy(this.gameObject);
        }
    }
}
