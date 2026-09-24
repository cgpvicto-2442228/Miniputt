using UnityEngine;
using UnityEngine.InputSystem;

public class DirectionBalle : MonoBehaviour
{
    [SerializeField, Tooltip("Vitesse de rotation en deg/sec")]
    private float vitesseRotation;

    [Header("Références aux objets de jeu")]
    [SerializeField, Tooltip("Le PlayerInput qui gère les actions de la personne qui joue")]
    private PlayerInput controles;

    /// <summary>
    /// La rotation actuelle de la direction de la balle
    /// </summary>
    private float rotation;

    private void Start()
    {
        InputAction actionRotation = controles.actions.FindAction("player/DirectionBalle");
        actionRotation.performed += CommencerRotation;
        actionRotation.canceled += TerminerRotation;
    }

    private void Update()
    {
        TournerCamera();
    }

    private void OnDestroy()
    {
        if (controles == null || controles.actions == null) { return; }

        InputAction actionRotation = controles.actions.FindAction("player/DirectionBalle");
        actionRotation.performed -= CommencerRotation;
        actionRotation.canceled -= TerminerRotation;
    }
    
    /// <summary>
    /// Commence la rotation de la direction de la balle
    /// </summary>
    /// <param name="contexte">Information du callback de l'action</param>
    private void CommencerRotation(InputAction.CallbackContext contexte)
    {
        rotation = vitesseRotation * contexte.ReadValue<float>();
    }

    /// <summary>
    /// Termine la rotation de la direction de la balle
    /// </summary>
    /// <param name="contexte">Information du callback de l'action</param>
    private void TerminerRotation(InputAction.CallbackContext contexte)
    {
        rotation = 0.0f;
    }

    /// <summary>
    /// Effectue la rotation de la direction de la balle
    /// </summary>
    private void TournerCamera()
    {
        transform.Rotate(new Vector3(0.0f, rotation * Time.deltaTime, 0.0f), Space.World);
    }
}
