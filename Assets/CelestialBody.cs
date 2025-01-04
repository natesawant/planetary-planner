using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (CircleCollider2D))]
public class CelestialBody : GravityObject {

    public float radius;
    public float surfaceGravity;
    public Vector2 initialVelocity;
    public string bodyName = "Unnamed";
    Transform meshHolder;

    public Vector2 velocity { get; private set; }
    public float mass { get; private set; }
    Rigidbody2D rb;
    CircleCollider2D coll;

    void Awake () {
        rb = GetComponent<Rigidbody2D> ();
        coll = GetComponent<CircleCollider2D>();
        rb.mass = mass;
        velocity = initialVelocity;
    }

    public void UpdateVelocity (CelestialBody[] allBodies, float timeStep) {
        foreach (var otherBody in allBodies) {
            if (otherBody != this) {
                float sqrDst = (otherBody.rb.position - rb.position).sqrMagnitude;
                Vector2 forceDir = (otherBody.rb.position - rb.position).normalized;

                Vector2 acceleration = forceDir * Universe.gravitationalConstant * otherBody.mass / sqrDst;
                velocity += acceleration * timeStep;
            }
        }
    }

    public void UpdateVelocity (Vector2 acceleration, float timeStep) {
        velocity += acceleration * timeStep;
    }

    public void UpdatePosition (float timeStep) {
        rb.MovePosition (rb.position + velocity * timeStep);

    }

    void OnValidate () {
        mass = surfaceGravity * radius * radius / Universe.gravitationalConstant;
        meshHolder = transform.GetChild (0);
        meshHolder.localScale = Vector3.one * radius;
        coll.radius = radius / 2;
        gameObject.name = bodyName;
    }

    public Rigidbody2D Rigidbody {
        get {
            return rb;
        }
    }

    public Vector2 Position {
        get {
            return rb.position;
        }
    }

}