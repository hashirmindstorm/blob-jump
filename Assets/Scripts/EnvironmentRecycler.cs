using UnityEngine;

public class EnvironmentRecycler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private GameObject env1;
    private GameObject env2;
    private float envOffset = 70;
    private float envLimit = 70;

    void Start()
    {
        env1 = transform.GetChild(0).gameObject;
        env2 = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        if (player.transform.position.z > envLimit + 4)
        {
            envLimit += envOffset;
            if (env1.transform.position.z < env2.transform.position.z)
            {
                env1.transform.position = new Vector3(0, 0, envLimit);
            }
            else
            {
                env2.transform.position = new Vector3(0, 0, envLimit);
            }
        }
    }
}
