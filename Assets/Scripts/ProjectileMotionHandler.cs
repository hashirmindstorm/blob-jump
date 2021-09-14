using UnityEngine;

public class ProjectileMotionHandler : MonoBehaviour
{
    public static bool BouncePlayer(GameObject player, GameObject destTrampoline, float speed)
    {
        float gravity = 9.8f;
        Rigidbody rb = player.GetComponent<Rigidbody>();

        Vector3 lowAngleImpulse;
        Vector3 highAngleImpulse;

        int numOfSolutions = SolveBallisticArc(
            player.transform.position,
            speed,
            destTrampoline.transform.position,
            gravity,
            out lowAngleImpulse,
            out highAngleImpulse);

        if (numOfSolutions == 0)
        {
            return false;
        }
        else
        {
            if (highAngleImpulse != Vector3.zero)
            {
                rb.AddForce(highAngleImpulse, ForceMode.Impulse);
            }
            else
            {
                rb.AddForce(lowAngleImpulse, ForceMode.Impulse);
            }
            return true;
        }
    }

    private static int SolveBallisticArc(Vector3 projPos, float projSpeed, Vector3 target, float gravity, out Vector3 s0, out Vector3 s1)
    {
        s0 = Vector3.zero;
        s1 = Vector3.zero;

        Vector3 diff = target - projPos;
        Vector3 diffXZ = new Vector3(diff.x, 0f, diff.z);
        float groundDist = diffXZ.magnitude;

        float speed2 = projSpeed * projSpeed;
        float speed4 = projSpeed * projSpeed * projSpeed * projSpeed;
        float y = diff.y;
        float x = groundDist;
        float gx = gravity * x;

        float root = speed4 - gravity * (gravity * x * x + 2 * y * speed2);

        if (root < 0)
            return 0;

        root = Mathf.Sqrt(root);

        float lowAng = Mathf.Atan2(speed2 - root, gx);
        float highAng = Mathf.Atan2(speed2 + root, gx);
        int numSolutions = lowAng != highAng ? 2 : 1;

        Vector3 groundDir = diffXZ.normalized;
        s0 = groundDir * Mathf.Cos(lowAng) * projSpeed + Vector3.up * Mathf.Sin(lowAng) * projSpeed;
        if (numSolutions > 1)
            s1 = groundDir * Mathf.Cos(highAng) * projSpeed + Vector3.up * Mathf.Sin(highAng) * projSpeed;

        return numSolutions;
    }
}
