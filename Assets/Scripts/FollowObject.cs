using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToFollow;
    [SerializeField]
    private Vector3 offset;

    void LateUpdate()
    {
        transform.position = objectToFollow.transform.position + offset;
    }
}
