using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToFollow;
    private Vector3 offset = new Vector3(0, 1.5f, -3);

    void LateUpdate()
    {
        transform.position = new Vector3(
            objectToFollow.transform.position.x / 1.5f,
            objectToFollow.transform.position.y + offset.y,
            objectToFollow.transform.position.z + offset.z);
    }
}
