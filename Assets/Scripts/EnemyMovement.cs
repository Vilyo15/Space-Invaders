using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject[] enemyRows;
    public float enemySpeed = 1;

    private string direction = "left";
    private int turnCounter;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveRepeat", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveRepeat()
    {
        foreach (GameObject row in enemyRows)
            StartCoroutine(Move(row));
    }

    IEnumerator Move(GameObject row)
    {

        yield return new WaitForSeconds(Random.Range(0.0f,0.5f));

        if (direction == "left" && !GameObject.Find("Player").GetComponent<PlayerLogic>().gameEnd && row.transform.position.x >= -8)
        {
            row.transform.Translate(enemySpeed * Vector2.left);
            yield return null;
        }
        else if (direction == "right" && !GameObject.Find("Player").GetComponent<PlayerLogic>().gameEnd && row.transform.position.x <= 8)
        {
            row.transform.Translate(enemySpeed * Vector2.right);
            yield return null;
        }
        if (row.transform.position.x <= -8 && direction == "left" && !GameObject.Find("Player").GetComponent<PlayerLogic>().gameEnd)
        {
            turnCounter++;
            if (turnCounter == 9)
            {
                //row.transform.position.Set(-8, row.transform.position.y, row.transform.position.z);
                transform.Translate(Vector2.down);

                enemySpeed += 0.2f;
                direction = "right";
                turnCounter = 0;
            }
            
        }
        if (row.transform.position.x >= 8 && direction == "right" && !GameObject.Find("Player").GetComponent<PlayerLogic>().gameEnd)
        {
            turnCounter++;
            if (turnCounter == 9)
            {
                //row.transform.position.Set(-8, row.transform.position.y, row.transform.position.z);
                transform.Translate(Vector2.down);

                enemySpeed += 0.2f;
                direction = "left";
                turnCounter = 0;
            }
        }
    }
}
