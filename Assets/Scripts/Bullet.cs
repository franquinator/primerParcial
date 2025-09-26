using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Bullet : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private int damage;
    [SerializeField]
    private AudioClip impactSound;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().LoseLife(damage);
            AudioManager.instance.PlayAudioClip(impactSound);
        }
        animator.SetBool("Explode", true);
    }
    public void Dead()
    {
        Destroy(gameObject);
    }
}
