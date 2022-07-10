using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoader : MonoBehaviour
{
    public Toggle powerUps;
    public void PlayButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void PowerUpButton(GameObject enemy)
    {
        if (enemy.transform.GetComponent<EnemyLogic>().spawnPowerUp == false)
        {
            enemy.transform.GetComponent<EnemyLogic>().spawnPowerUp = true;
            powerUps.isOn = true;
        }
        else if (enemy.transform.GetComponent<EnemyLogic>().spawnPowerUp == true)
        {
            enemy.transform.GetComponent<EnemyLogic>().spawnPowerUp = false;
            powerUps.isOn = false;
        }
    }
   
}
