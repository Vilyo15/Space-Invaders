using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletSpeed = 20;
    public bool enemy;
    
    private float startTime;
    private float timeToLive = 1f;
    void Start()
    {
        
    }

    void Update()
    {
        if (Time.time - startTime > timeToLive)
        {
            DestroySelf();
        }
        if (enemy)
            transform.Translate(bulletSpeed * Time.deltaTime * Vector2.down);
        else
            transform.Translate(bulletSpeed * Time.deltaTime * Vector2.up);
    }
    private void Awake()
    {
        startTime = Time.time;
    }
    private void DestroySelf()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("hit");
        DestroySelf();
    }
}
    