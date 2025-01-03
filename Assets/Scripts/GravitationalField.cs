using UnityEngine;

public class GravitationalField : MonoBehaviour
{
    [SerializeField]
    double gravityConstant = 6.67e-11;

    Rigidbody2D thisRb;

    void Start()
    {
        thisRb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D otherRb = other.attachedRigidbody;

        Vector2 gravityVector = transform.position - otherRb.transform.position;
        float distance = gravityVector.magnitude;
        float gravityForce = (float)gravityConstant * thisRb.mass * otherRb.mass / Mathf.Pow(distance, 2);

        Debug.Log("Gravity Force: " + gravityForce);

        otherRb.AddForce(gravityVector.normalized * gravityForce);

        Debug.DrawLine(transform.position, otherRb.transform.position);
    }
}
