using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 1.0f);
    }

    // Update is called once per frame
 
    private void DestroySelf()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
