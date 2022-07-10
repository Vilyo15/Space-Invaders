using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerLogic : MonoBehaviour
{
    public int speed = 100;
    public GameObject bullet;
    public Transform muzzle;
    public int health = 3;
    public TextMeshProUGUI healthText;
    public int score;
    public TextMeshProUGUI scoreText;
    public bool gameEnd = false;
    public GameObject endScreen;
    public GameObject winscreen;
    public GameObject explosion;


    private GameObject liveBullet;
    public int power = 1;
    
    void Update()
    {
        healthText.text = ("health: " + health.ToString());
        scoreText.text = ("score: " + score.ToString());

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -20 && !gameEnd)
            transform.Translate(speed * Time.deltaTime * Vector2.left);
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 20 && !gameEnd)
            transform.Translate(speed * Time.deltaTime * Vector2.right);
        if (Input.GetKeyDown(KeyCode.Space) && !gameEnd)
            Shoot();

        if (health <= 0)
        {
            EndGame();
        }

        if (GameObject.Find("Enemy") == null)
        {
            gameEnd = true;
            winscreen.SetActive(true);
        }
    }

    private void Shoot()
    {
        if (liveBullet == null)
            if (power == 1)
                liveBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
            else
            {
                for (int i = 1; i < power; i++)
                {
                    liveBullet = Instantiate(bullet, muzzle.position - new Vector3(0.5f*i,0,0), Quaternion.identity);
                    liveBullet = Instantiate(bullet, muzzle.position + new Vector3(0.5f*i, 0, 0), Quaternion.identity);
                }
            }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.transform.name == "EnemyBullet(Clone)")
        {
            health--;
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
            
        
        else if (other.transform.name == "PowerUp(Clone)")
        {
            PowerUp();
            
        }
    }

    public void EndGame()
    {
        gameEnd = true;
        endScreen.SetActive(true);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PowerUp()
    {
        power++;
    }
}
