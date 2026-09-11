using UnityEngine;

public class Sticky : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float force = 0.7f;

    private void OnTriggerEnter(Collider other)
    {
        if (rb != null)
            rb.linearVelocity *= force;
    }
}
