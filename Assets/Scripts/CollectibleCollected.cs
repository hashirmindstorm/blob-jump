using UnityEngine;

public class CollectibleCollected : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            other.gameObject.transform.localScale += new Vector3(0.004f, 0.004f, 0.004f);
        }
    }
}
