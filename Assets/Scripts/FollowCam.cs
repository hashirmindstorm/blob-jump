using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToFollow;
    private Vector3 offset = new Vector3(0, 1.25f, -2.5f);

    void LateUpdate()
    {
        transform.position = objectToFollow.transform.position + offset;
    }
}
