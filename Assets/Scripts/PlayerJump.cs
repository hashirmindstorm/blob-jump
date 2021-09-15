using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private float speed = 10;
    private Rigidbody rb;
    public int playerJump = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
        playerJump++;
    }
}
