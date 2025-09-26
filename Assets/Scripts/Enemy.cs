using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    [SerializeField]
    private Vector2 direction;
    [SerializeField]
    private int damage;
    [SerializeField]
    [Min(1)]
    private int maxLifes = 1;
    private int lifes;
    [SerializeField]
    private AudioClip destroySound;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        lifes = maxLifes;
        rb.velocity = direction;
    }
    public void LoseLife(int damage)
    {
        lifes -= damage;
        if (lifes < 1)
        {
            AudioManager.instance.PlayAudioClip(destroySound);
            animator.SetBool("Explode", true);
        }
    }
    public void Dead()
    {
        ScoreManager.instance.AddScorePerKill();
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        HealthManager.instance.RemoveLives(damage);
        animator.SetBool("Explode", true);
    }
    
}
