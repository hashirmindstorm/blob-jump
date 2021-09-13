using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToFollow;

    private Vector3 offset = new Vector3(0, 0.88f, -2);

    void LateUpdate()
    {
        transform.position = objectToFollow.transform.position + offset;
    }
}
