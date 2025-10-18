using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Movement : MonoBehaviour
{

    [SerializeField]
    private float speed;
    private Vector3 direction;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private float widthOfPlayZone;
    [SerializeField]
    private float heightOfPlayZone;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        MovementInput();
        MovementAnimation();
    }
    private void FixedUpdate()
    {
        Vector2 proxPosition = transform.position + direction * speed;

        proxPosition.y = Mathf.Clamp(proxPosition.y, -heightOfPlayZone, heightOfPlayZone);
        proxPosition.x = Mathf.Clamp(proxPosition.x, -widthOfPlayZone, widthOfPlayZone);
        rb.MovePosition(proxPosition);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(Vector2.zero, new Vector2(widthOfPlayZone * 2, heightOfPlayZone * 2));
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            anim.SetTrigger("Explode");
        }
    }
    private void MovementInput()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        direction = direction.normalized;
    }
    private void MovementAnimation()
    {
        anim.SetBool("Turning", false);
        if (direction.y != 0)
        {
            anim.SetBool("Turning", true);
        }
        if (direction.y > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (direction.y < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
