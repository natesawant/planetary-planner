using UnityEngine;
using UnityEngine.InputSystem;

public class PlanetPlacer : MonoBehaviour
{
    [SerializeField]
    GameObject planetPrefab;
    [SerializeField]
    float radius = 1f;
    [SerializeField]
    Transform planetOutline;
    [SerializeField]
    Transform gravityOutline;

    void Update()
    {
        Vector3 outlinePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        outlinePosition.z = 0;

        planetOutline.transform.position = outlinePosition;
        gravityOutline.transform.position = outlinePosition;
    }
}
