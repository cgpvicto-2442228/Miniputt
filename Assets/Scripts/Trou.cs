using UnityEngine;

public class Trou : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private Animator animation;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 position = other.transform.position;
        position.x = -8f;
        position.y = 0.2f;
        position.z = 0f;

        other.transform.position = position;
        animation.SetTrigger("Rentrer");

        if (rb != null )
        {
            rb.linearVelocity = Vector3.zero; 
            rb.angularVelocity = Vector3.zero;
        }
    }
}
