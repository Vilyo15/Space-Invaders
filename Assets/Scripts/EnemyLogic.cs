using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{

   
    public GameObject enemyBullet;
    public Transform enemyMuzzle;
    public GameObject powerUp;
    public bool spawnPowerUp;
    public GameObject explosion;

   

    void Start()
    {
        Invoke("ShootRepeat", Random.Range(1.0f, 5.0f));
    }


    void Update()
    {
        

        if (transform.position.y <= -7)
            GameObject.Find("Player").GetComponent<PlayerLogic>().EndGame();
    }

    private void DestroySelf()
    {
        if (Random.value < 0.10f && spawnPowerUp)
            Instantiate(powerUp, transform.position, Quaternion.identity);
        GameObject.Find("Player").GetComponent<PlayerLogic>().score++;
        Instantiate(explosion, transform.position, Quaternion.identity); 
        gameObject.SetActive(false);
        Destroy(gameObject);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        DestroySelf();
    }
    private void Shoot()
    {
        Instantiate(enemyBullet, enemyMuzzle.position, Quaternion.identity);
    }

    private void ShootRepeat()
    {
        if (!GameObject.Find("Player").GetComponent<PlayerLogic>().gameEnd)
        {
            float randomTime = Random.Range(1.0f, 5.0f);
            if (Random.value < 0.20f)
                Shoot();
            Invoke("ShootRepeat", randomTime);
        }
    }

    private void SpawnPowerUp()
    {

    }
}
