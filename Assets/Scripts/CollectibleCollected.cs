using UnityEngine;

public class CollectibleCollected : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            other.gameObject.transform.localScale += new Vector3(0.025f, 0.025f, 0.025f);
            other.gameObject.GetComponent<TrailRenderer>().startWidth += 0.0275f;
        }
    }
}
