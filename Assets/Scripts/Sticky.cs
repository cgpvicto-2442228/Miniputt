using UnityEngine;

public class Sticky : MonoBehaviour
{

    [SerializeField]
    private float force = 0.9f;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Rigidbody rbBalle))
            rbBalle.linearVelocity *= force;
    }
}
