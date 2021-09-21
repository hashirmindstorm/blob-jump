using UnityEngine;

public class HorizontalPlayerMovement : MonoBehaviour
{
    private Touch touch;
    private float speedModifier = 0.009f;

    private void Update()
    {
        if (Input.touchCount > 0 && transform.position.y > 1)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedModifier,
                    transform.position.y,
                    transform.position.z);
            }
        }
    }
}
