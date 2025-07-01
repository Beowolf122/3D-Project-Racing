using UnityEngine;

public class BombScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody RB;
    public float explosionForce = 1000f;
    public float explosionRadius = 5f;
    public float upwardsModifier = 3f;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == CompareTag("Player")) {
            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardsModifier, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
