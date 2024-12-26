using HealthSystem;
using InteractionSystem;
using UnityEngine;

public class FieldSurgeryPack : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionIndicator indicator;
    [Space]
    [SerializeField] private int healthPerUse;

    [Header("Interaction Effects")]
    [SerializeField] private AudioClip interactionClip;

    private void Start()
    {
        indicator.SetInteractionInformation($"{healthPerUse}%\r\nHealth");
        HideInteraction();
    }

    public void ShowInteraction()
    {
        indicator.ShowIndicator();
    }

    public void HideInteraction()
    {
        indicator.HideIndicator();
    }

    public void Interact(Interaction interaction)
    {
        Health health = interaction.Health;

        if (health.CurrentHealth < health.MaxHealth)
        {
            health.CurrentHealth += healthPerUse;
            interaction.PlayInteractionEffect(interactionClip);
            Destroy(gameObject);
        }
    }
}
