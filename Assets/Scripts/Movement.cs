using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Movement : MonoBehaviour
{

    [SerializeField]
    private float speed;
    private Vector3 Direction;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private float anchoDeZonaDeJuego;
    [SerializeField]
    private float altoDeZonaDeJuego;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Direction.x = Input.GetAxis("Horizontal");
        Direction.y = Input.GetAxis("Vertical");

        
        anim.SetBool("Doblando", false);
        if (Direction.y != 0)
        {
            anim.SetBool("Doblando", true);
        }
        

        if (Direction.y > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (Direction.y < 0) {
            spriteRenderer.flipX = true;
        }

        Direction = Direction.normalized;
    }
    private void FixedUpdate()
    {
        Vector2 proxPosicion = transform.position + Direction * speed;
        proxPosicion.y = Mathf.Clamp(proxPosicion.y, -altoDeZonaDeJuego, altoDeZonaDeJuego);
        proxPosicion.x = Mathf.Clamp(proxPosicion.x, -anchoDeZonaDeJuego, anchoDeZonaDeJuego);

        rb.MovePosition(proxPosicion);
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(Vector2.zero, new Vector2(anchoDeZonaDeJuego*2,altoDeZonaDeJuego*2));
    }
}
