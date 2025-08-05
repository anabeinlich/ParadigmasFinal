using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSearch : MonoBehaviour
{
    [SerializeField] private float searchRadius = 3f;
    [SerializeField] private Color highlightColor = Color.yellow;
    [SerializeField] private float flashDuration = 1f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BuscarYResaltar();
        }
    }

    private void BuscarYResaltar()
    {
        var interactable = Physics2D.OverlapCircleAll(transform.position, searchRadius)
            .Select(c => c.GetComponent<IInteractable>())
            .Where(i => i != null)
            .OrderBy(i => Vector2.Distance(transform.position, ((MonoBehaviour)i).transform.position))
            .FirstOrDefault();

        if (interactable != null)
        {
            StartCoroutine(FlashInteractableColor(interactable));
        }
    }

    private IEnumerator FlashInteractableColor(IInteractable interactable)
    {
        var mono = (MonoBehaviour)interactable;
        var sr = mono.GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            Color original = sr.color;
            sr.color = highlightColor;

            yield return new WaitForSeconds(flashDuration);

            sr.color = original;
        }
    }
}
