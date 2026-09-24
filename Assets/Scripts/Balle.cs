using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Balle : MonoBehaviour
{
    private Rigidbody rb;
    private bool bouge = false;

    [SerializeField]
    private float force = 10f;

    [SerializeField]
    private float friction = 0.97f;

    public InputAction lancerAction;

    [SerializeField]
    private Transform trans;

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
        if (!bouge)
        {
            Vector3 direction = -trans.forward;
            rb.AddForce(direction * force, ForceMode.Impulse);
            bouge = true;
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Sol")
        {
            rb.linearVelocity *= friction;
            if (rb.linearVelocity.magnitude < 0.1) {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                bouge = false;
            }
        }
    }

    private void OnDestroy()
    {
        lancerAction.performed -= Lancer;
        lancerAction.Disable();
    }
}