using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMovementController
    {
        private Camera _mainCamera;
        private PlayerMovement _playerMovement;

        public PlayerMovementController(Camera mainCamera, PlayerMovement playerMovement)
        {
            _mainCamera = mainCamera;
            _playerMovement = playerMovement;
        }

        public void Move(Vector2 movementDirection)
        {
            _playerMovement.SetMovementDirection(movementDirection);
        }

        public void SwitchSprint(bool shouldSprint)
        {
            _playerMovement.SetSprint(shouldSprint);
        }

        public void Aim(Vector2 mousePosition)
        {
            Vector2 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(mousePosition);

            _playerMovement.SetAim(mouseWorldPosition);
        }

    }
}