using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update
    public void DestroySelf()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.name != "Bullet(Clone)")
            DestroySelf();

    }
}
