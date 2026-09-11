using UnityEngine;
using UnityEngine.InputSystem;

public class Balle : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float force = 10f;

    public InputAction lancerAction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Start()
    {
        lancerAction.Enable();
        lancerAction.performed += Lancer;
    }

    public void Lancer(InputAction.CallbackContext content)
    {
        rb.AddForce(Vector3.right * force, ForceMode.Impulse);
    }

    private void OnDestroy()
    {
        lancerAction.performed -= Lancer;
        lancerAction.Disable();
    }
}