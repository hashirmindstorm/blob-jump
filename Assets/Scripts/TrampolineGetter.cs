using UnityEngine;

public class TrampolineGetter : MonoBehaviour
{
    public GameObject GetCurrentTrampoline()
    {
        return transform.GetChild(0).gameObject;
    }

    public GameObject GetNextTrampoline()
    {
        return transform.GetChild(1).gameObject;
    }
}
