using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    private void Start()
    {
        transform.rotation = Quaternion.Euler(120, 0, 0);
    }

    void Update()
    {
        transform.Rotate(new Vector3(1,0));
    }
}
