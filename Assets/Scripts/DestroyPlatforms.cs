using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatforms : MonoBehaviour
{
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Sphere");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z<Player.transform.position.z)
        {
            Destroy(gameObject);
        }
        
    }
}
