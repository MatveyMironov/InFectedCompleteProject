namespace InteractionSystem
{
    public interface IInteractable
    {
        public void ShowInteraction();

        public void HideInteraction();

        public void Interact(Interaction interaction);
    }
}