using UnityEngine;

public class CowEnemy : Enemy
{
    //Enemigo vaca que hace patrullaje. 
    [SerializeField] private Transform[] puntosPatrulla;
    [SerializeField] private float velocidad = 2f;
    [SerializeField] private int damage = 2;

    private int indiceActual = 0;

    private void Update()
    {
        if (puntosPatrulla.Length == 0) return;

        Transform objetivo = puntosPatrulla[indiceActual];
        transform.position = Vector2.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);

        if (Vector2.Distance(transform.position, objetivo.position) < 0.1f)
        {
            indiceActual = (indiceActual + 1) % puntosPatrulla.Length;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent<IDamageable>(out var objetivo))
        {
            objetivo.TakeDamage(damage);
        }
    }
}
