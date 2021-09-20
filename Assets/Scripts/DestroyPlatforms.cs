using UnityEngine;

public class DestroyPlatforms : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if(transform.position.z + 1 < player.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
