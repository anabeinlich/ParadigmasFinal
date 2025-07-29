using UnityEngine;

public class Bush : MonoBehaviour, IInteractable
{
    public void Interact(Player player)
    {
        player.SetHidden(true);
        Debug.Log("El jugador esta escindido");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.SetHidden(false);
                Debug.Log("El jugador salió del arbusto.");
            }
        }
    }
}
