using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 3;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
