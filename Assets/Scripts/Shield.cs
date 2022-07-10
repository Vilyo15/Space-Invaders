using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    


    private void DestroySelf()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.name == "EnemyBullet(Clone)")
            DestroySelf();
        
    }
}
