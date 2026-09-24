using UnityEngine;

public class SuivreBalle : MonoBehaviour
{
    [SerializeField]
    private Transform trans;

    private void LateUpdate()
    {
        transform.position = trans.position;
    }
}
