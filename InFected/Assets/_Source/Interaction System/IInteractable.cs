namespace InteractionSystem
{
    public interface IInteractable
    {
        void ShowInteraction();
        void HideInteraction();
        void Interact(InteractionData interaction);
    }
}