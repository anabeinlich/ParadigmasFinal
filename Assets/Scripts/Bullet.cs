using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 0.5f;
    [SerializeField] private int damage = 1;
    [SerializeField] private string targetTag = "Enemy"; // Por defecto, daña enemigos

    private Vector2 direction;
    private Rigidbody2D rb;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    public void SetTargetTag(string tag)
    {
        targetTag = tag;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag) && other.TryGetComponent<IDamageable>(out var d))
        {
            d.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (!other.isTrigger)
        {
            Destroy(gameObject);
        }
    }
}
