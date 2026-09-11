using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float force = 50f;

    private void OnTriggerEnter(Collider other)
    {
        if (rb != null)
            rb.AddForce(Vector3.right * force, ForceMode.Impulse);
    }
}
