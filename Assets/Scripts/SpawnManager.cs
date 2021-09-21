using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject jumpPlatform;
    [SerializeField] private GameObject Player;
    [SerializeField] private CollectableSpawner collectableSpawnerRef;
    [SerializeField] private GameObject trampolineParent;
    private MovePlayer playerJumpRef;
    private float[] xRange = {-1.1f, 0, 1.1f};
    private float zOffset = 3;
    private float _lastTileZPosition;

    void Awake()
    {
        _lastTileZPosition = Player.transform.position.z;
        spawnTiles();
    }

    void Start()
    {
        playerJumpRef = GameObject.Find("Player").GetComponent<MovePlayer>();
    }

    void Update()
    {
        if (playerJumpRef.getJumpCount() >= 5)
        {
            spawnTiles();
            playerJumpRef.resetJumpCount();
        }

    }

    void spawnTiles()
    {
        if (trampolineParent.transform.hierarchyCount > 25)
            return;

        for (int i = 0; i < 10; i++)
        {
            _lastTileZPosition += zOffset;
            float spawnPosX = xRange[Random.Range(0, 3)];
            Vector3 newTilePos = new Vector3(spawnPosX, 0.1f, _lastTileZPosition);
            Instantiate(jumpPlatform, newTilePos, jumpPlatform.transform.rotation, trampolineParent.transform);
            if (i == 9)
            {
                collectableSpawnerRef.spawnCollectible(newTilePos);
                zOffset++;
            }
        }
    }
}
