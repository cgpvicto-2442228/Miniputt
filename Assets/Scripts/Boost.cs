using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField]
    private float force = 50f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Rigidbody rbBalle))
            rbBalle.AddForce(Vector3.right * force, ForceMode.Impulse);        
    }
}
