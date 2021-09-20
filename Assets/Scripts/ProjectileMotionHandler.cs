using UnityEngine;

public class ProjectileMotionHandler : MonoBehaviour
{
    private static float correctionFactorY = 0;

    public static void BouncePlayer(GameObject player, GameObject destTrampoline, float speed, float maxHeight)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();

        Vector3 fireVelocity;
        float gravity;

        SolveBallisticArcLateral(
            new Vector3(0, player.transform.position.y, player.transform.position.z),
            speed,
            new Vector3(0, destTrampoline.transform.position.y, destTrampoline.transform.position.z),
            maxHeight,
            out fireVelocity,
            out gravity);

        FakeGravity.SetGravity(-gravity);
        fireVelocity += new Vector3(0, correctionFactorY, 0);
        rb.velocity += fireVelocity;
    }

    public static void ApplyCorrection(GameObject player, GameObject destTrampoline)
    {
        if (player.transform.position.z < destTrampoline.transform.position.z)
        {
            correctionFactorY += 0.0065f;
        }
        else
        {
            correctionFactorY -= 0.0065f;
        }
    }

    private static bool SolveBallisticArcLateral(Vector3 proj_pos, float lateral_speed, Vector3 target_pos, float max_height, out Vector3 fire_velocity, out float gravity)
    {
        fire_velocity = Vector3.zero;
        gravity = float.NaN;

        Vector3 diff = target_pos - proj_pos;
        Vector3 diffXZ = new Vector3(diff.x, 0f, diff.z);
        float lateralDist = diffXZ.magnitude;

        if (lateralDist == 0)
            return false;

        float time = lateralDist / lateral_speed;

        fire_velocity = diffXZ.normalized * lateral_speed;

        float a = proj_pos.y;
        float b = max_height;
        float c = target_pos.y;

        gravity = -4*(a - 2*b + c) / (time* time);
        fire_velocity.y = -(3*a - 4*b + c) / time;

        return true;
    }
}
