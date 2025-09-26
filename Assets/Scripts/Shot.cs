using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform shotPosition;
    [SerializeField]
    private Vector2 ShotDirection;
    [SerializeField]
    private float speed;
    [SerializeField]
    private AudioClip shotSound;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            AudioManager.instance.PlayAudioClip(shotSound);
            GameObject bulleInstance = Instantiate(bullet, shotPosition.position, bullet.transform.rotation);
            bulleInstance.GetComponent<Rigidbody2D>().velocity = ShotDirection.normalized * speed;
        }
    }
}
