using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    private int lifes;
    [SerializeField]
    [Range(1, 7)]
    private int maxLifes;
    [SerializeField]
    private string layer;
    void Start()
    {
        lifes = maxLifes;
    }
    public void LoseLife(int damage)
    {
        
    }
}
