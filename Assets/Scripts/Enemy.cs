using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    [SerializeField]
    private Vector2 direction;
    [SerializeField]
    private int damage;
    [SerializeField]
    [Min(1)]
    private int lives;
    [SerializeField]
    private int speed = 1;
    [SerializeField]
    private AudioClip destroySound;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        _rb.velocity = direction*speed;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.instance.RemoveLives(damage);
        _animator.SetBool("Explode", true);
    }
    public void LoseLife(int damage)
    {
        lives -= damage;
        if (lives < 1)
        {
            AudioManager.instance.PlayAudioClip(destroySound);
            _animator.SetBool("Explode", true);
        }
    }
    public void Dead()
    {
        GameManager.instance.AddScorePerKill();
        Destroy(gameObject);
    }



}
