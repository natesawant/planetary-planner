using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField]
    float initialBoostForce = 1f;
    Rigidbody2D thisRb;

    void Start()
    {
        thisRb = GetComponent<Rigidbody2D>();

        thisRb.AddForce(transform.right * initialBoostForce);
    }
}
