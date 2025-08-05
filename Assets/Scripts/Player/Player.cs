using System;
using UnityEngine;
using static UnityEngine.Rendering.GPUSort;
using System.Collections;

public class Player : DamageableEntity, IDamageable
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    [SerializeField] private int aura; // representa el score

    private Rigidbody2D rb;
    private Vector2 movement;

    public Action<int> OnHealthChanged;
    public Action<int> OnAuraChanged;

    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;
    public int CurrentAuras => aura;

    public bool IsHidden { get; private set; }

    private IInteractable objetoCercano;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    private void Start()
    {
        Debug.Log("Vida del jugador: " +  currentHealth);
        OnHealthChanged?.Invoke(currentHealth);
        OnAuraChanged?.Invoke(aura);
    }

    private void Update()
    {
        //para el movimiento
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Debug.Log(currentHealth);

        //para las interacciones
        if (Input.GetKeyDown(KeyCode.E) && objetoCercano != null)
        {
            objetoCercano.Interact(this);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        FlashOnDamage();
        OnHealthChanged?.Invoke(currentHealth);
    }


    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth);
    }

    public void AddAura(int amount)
    {
        aura += amount;
        OnAuraChanged?.Invoke(aura);
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    //para el bush
    public void SetHidden(bool hidden)
    {
        IsHidden = hidden;
        Debug.Log("Hidden = " + IsHidden);
        spriteRenderer.color = IsHidden ? Color.green : Color.white;
    }

    // ----- para los interactuables 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            objetoCercano = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable) && interactable == objetoCercano)
        {
            objetoCercano = null;
        }
    }

    //Power Up de Velocidad: 
    public void ApplySpeedBoost(float multiplier, float duration)
    {
        StartCoroutine(SpeedBoostRoutine(multiplier, duration));
    }

    private IEnumerator SpeedBoostRoutine(float multiplier, float duration)
    {
        float originalSpeed = moveSpeed;
        moveSpeed *= multiplier;

        yield return new WaitForSeconds(duration);

        moveSpeed = originalSpeed;
    }
}
