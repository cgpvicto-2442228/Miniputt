using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField]
    private float force = 50f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Rigidbody rbBalle))
            rbBalle.AddForce(Vector3.up * force, ForceMode.Impulse);           
    }
}
