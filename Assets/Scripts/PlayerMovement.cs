using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 3;
    public bool collidedWithCollectible = false;
    private Rigidbody playerRB;

    private void Start()
    {
        playerRB=GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if(collidedWithCollectible)
        {
            playerRB.mass *= 2;
            collidedWithCollectible = false;
        }
    }
}
