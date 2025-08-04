using UnityEngine;

public class ChickenEnemy : Enemy
{
    //Enemigo; Gallina que dispara huevos.
    [SerializeField] private GameObject huevoPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float tiempoEntreDisparos = 2f;
    [SerializeField] private float rangoDisparo = 5f;

    private float temporizador;

    private void Update()
    {
        if (player == null || player.IsHidden) return;

        float distancia = Vector2.Distance(transform.position, player.transform.position);

        if (distancia <= rangoDisparo)
        {
            temporizador += Time.deltaTime;

            if (temporizador >= tiempoEntreDisparos)
            {
                DispararHuevo();
                temporizador = 0f;
            }
        }
    }

    private void DispararHuevo()
    {
        Vector2 direccion = (player.transform.position - spawnPoint.position).normalized;

        GameObject huevo = Instantiate(huevoPrefab, spawnPoint.position, Quaternion.identity);

        if (huevo.TryGetComponent<Bullet>(out var proyectil))
        {
            proyectil.SetDirection(direccion);
            proyectil.SetTargetTag("Player"); // El enemigo ataca al jugador
        }
    }
}
