using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Bullet : MonoBehaviour
{
    private Animator _animator;
    [SerializeField]
    private int damage;
    [SerializeField]
    private AudioClip impactSound;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().LoseLife(damage);
            AudioManager.instance.PlayAudioClip(impactSound);
        }
        _animator.SetBool("Explode", true);
    }
    public void Dead()
    {
        Destroy(gameObject);
    }
}
