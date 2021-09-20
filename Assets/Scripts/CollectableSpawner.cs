using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] private GameObject collectible;

    public void spawnCollectible(Vector3 tilePosition)
    {
        Vector3 collectiblePosition = new Vector3(tilePosition.x, tilePosition.y + 0.5f, tilePosition.z);
        Instantiate(collectible,collectiblePosition , collectible.transform.rotation);
    }
}
