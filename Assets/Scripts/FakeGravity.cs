using UnityEngine;

public class FakeGravity : MonoBehaviour
{
    private Rigidbody rb;
    private static float gravity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gravity = -9.81f;
    }

    private void FixedUpdate()
    {
        rb.velocity += new Vector3(0, gravity * Time.fixedDeltaTime, 0);
    }

    public static void SetGravity(float g)
    {
        gravity = g;
    }
}
