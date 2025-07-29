using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    private Camera camara;

    private void Start()
    {
        camara = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Disparar();
        }
    }

    private void Disparar()
    {
        Vector3 mousePos = camara.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector2 direccion = (mousePos - bulletSpawnPoint.position).normalized;

        GameObject bala = Instantiate(proyectilPrefab, bulletSpawnPoint.position, Quaternion.identity);

        if (bala.TryGetComponent<Bullet>(out var proyectil))
        {
            proyectil.SetDirection(direccion);
            proyectil.SetTargetTag("Enemy");
        }

        Collider2D balaCollider = bala.GetComponent<Collider2D>();
        Collider2D playerCollider = GetComponent<Collider2D>();
        if (balaCollider && playerCollider)
            Physics2D.IgnoreCollision(balaCollider, playerCollider);
    }
}
