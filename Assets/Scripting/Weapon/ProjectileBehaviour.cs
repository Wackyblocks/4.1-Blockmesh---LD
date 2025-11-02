using UnityEngine;
using System.Collections;
using System.Threading;

public class ProjectileBehaviour : MonoBehaviour
{
    // speed
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float lifetime = 4.0f;
    private bool collided = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        StartCoroutine(DestroyAfterTime());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collided) return;

        collided = true;

        // deal damage (maybe later)
        //play effects and sounds (maybe later)

        Destroy(gameObject);
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifetime);
        if (!collided)
        {
            Destroy(gameObject);
        }
    }
}
