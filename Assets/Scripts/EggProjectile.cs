using UnityEngine;

public class EggProjectile : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float tiempoDeVida = 5f;
    [SerializeField] private int daño = 1;

    private Vector2 direccion;
    private Rigidbody2D rb;

    public void SetDireccion(Vector2 dir)
    {
        direccion = dir.normalized;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.AddForce(direccion * velocidad, ForceMode2D.Impulse);
        Destroy(gameObject, tiempoDeVida);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent<IDamageable>(out var objetivo))
            {
                objetivo.TakeDamage(daño);
            }

            Destroy(gameObject);
        }
        else if (!other.isTrigger) // choca con el entorno
        {
            Destroy(gameObject);
        }
    }
}
