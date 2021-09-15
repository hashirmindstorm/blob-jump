using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{

    [SerializeField] private GameObject collectible;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnCollectible(Vector3 tilePosition)
    {
        Vector3 collectiblePosition = new Vector3(tilePosition.x, tilePosition.y + 0.5f, tilePosition.z);
        Instantiate(collectible,collectiblePosition , collectible.transform.rotation);
    }
}
