using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody rb;
    private float _speed = 3;
    private float maxHeight = 5;
    private int jumpCount = 0;
    private GameObject nextTramp;
    public TrampolineGetter trampolineGetter;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetPlayerInitialPos();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trampoline")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            GameObject currTramp = trampolineGetter.GetCurrentTrampoline();
            ProjectileMotionHandler.ApplyCorrection(gameObject, currTramp);
            transform.position = new Vector3(transform.position.x, transform.position.y, currTramp.transform.position.z);
            nextTramp = trampolineGetter.GetNextTrampoline();
            StartCoroutine(PerformJump());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectible")
        {
            AddSpeed(0.75f);
            AddMaxHeight(0.75f);
        }
    }

    private IEnumerator PerformJump()
    {
        yield return new WaitForSeconds(0.1f);
        ProjectileMotionHandler.BouncePlayer(gameObject, nextTramp, _speed, maxHeight);
        ++jumpCount;
    }

    public void SetPlayerInitialPos()
    {
        Transform trampolineT = trampolineGetter.GetCurrentTrampoline().transform;
        trampolineT.position = new Vector3(0, trampolineT.position.y, trampolineT.position.z);
        transform.position = new Vector3(0, trampolineT.position.y + 0.5f, trampolineT.position.z);
    }

    public int getJumpCount()
    {
        return jumpCount;
    }

    public void resetJumpCount()
    {
        jumpCount = 0;
    }

    private void AddSpeed(float s)
    {
        _speed += s;
    }

    private void AddMaxHeight(float mh)
    {
        maxHeight += mh;
    }
}
