using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject jumpPlatform;
    [SerializeField] private GameObject Player;
    [SerializeField] private CollectableSpawner collectableSpawnerRef;
    private PlayerJump playerJumpRef;
    private float xRange = 3;
    private float _lastTileZPosition;
    private float zRangeL = 4;
    public PlayerMovement playerMovementRef;
    //Variable For Overlap

    // Start is called before the first frame update
    void Start()
    {
        playerJumpRef = GameObject.Find("Sphere").GetComponent<PlayerJump>();
        _lastTileZPosition = Player.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerJumpRef.playerJump == 2)
        {
            spawnTiles();
            playerJumpRef.playerJump = 0;
            
        }

    }

    void spawnTiles()
    {
            for (int i = 0; i < 10; i++)
            {
                _lastTileZPosition += Random.Range(zRangeL, zRangeL + 3);
                float spawnPosX = Random.Range(-xRange, xRange);
                Vector3 newTilePos = new Vector3(spawnPosX, 0.1f, _lastTileZPosition);
                Instantiate(jumpPlatform, newTilePos, jumpPlatform.transform.rotation);
                if (i == 9)
                {
                    collectableSpawnerRef.spawnCollectible(newTilePos);
                    zRangeL++;
                }

            }
        
    }
}
