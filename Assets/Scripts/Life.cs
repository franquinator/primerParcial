using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField]
    private Animator animatorDeExplosion;
    private int lifes;
    [SerializeField]
    [Min(1)]
    private int maxLifes = 1;
    [SerializeField]
    private string damageLayer;
    void Start()
    {
        lifes = maxLifes;
    }
    public void LoseLife(int damage)
    {
        lifes -= damage;
        if (lifes < 1)
        {
            Dead();
        }
    }
    public void Dead()
    {
        animatorDeExplosion.SetBool("Explode", true);
    }
}
