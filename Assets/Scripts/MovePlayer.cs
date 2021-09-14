using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 10;
    public GameObject nextTramp; // only for testing

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trampoline")
        {
            rb.velocity = Vector3.zero;
            ProjectileMotionHandler.BouncePlayer(this.gameObject, nextTramp, speed);
        }
    }
}
