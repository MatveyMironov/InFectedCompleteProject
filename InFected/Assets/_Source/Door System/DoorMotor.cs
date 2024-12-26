using CustomUtilities;
using System.Collections;
using UnityEngine;

namespace DoorSystem
{
    public class DoorMotor
    {
        private Transform _door;
        private Vector3 _closedPosition;
        private Vector3 _openedPosition;
        private float _movingSpeed;
        private AudioSource _audioSource;

        public DoorMotor(Transform door, Vector3 closedPosition, Vector3 openedPosition, float movingSpeed, AudioSource audioSource)
        {
            _door = door;
            _closedPosition = closedPosition;
            _openedPosition = openedPosition;
            _movingSpeed = movingSpeed;
            _audioSource = audioSource;
        }

        public bool IsClosing { get; private set; }
        public bool IsOpening { get; private set; }

        public bool IsClosed { get { return _door.localPosition == _closedPosition; } }
        public bool IsOpened { get { return _door.localPosition == _openedPosition; } }

        public void OpenDoor()
        {
            if (IsOpened || IsOpening) return;

            CoroutineManager.StartRoutine(Opening());
        }

        public void CloseDoor()
        {
            if (IsClosed || IsClosing) return;

            CoroutineManager.StartRoutine(Closing());
        }

        private IEnumerator Opening()
        {
            _audioSource.Play();
            IsClosing = false;
            IsOpening = true;

            while (!IsOpened)
            {
                yield return null;

                _door.localPosition = Vector3.MoveTowards(_door.localPosition, _openedPosition, _movingSpeed * Time.deltaTime);
            }

            IsOpening = false;
        }

        private IEnumerator Closing()
        {
            _audioSource.Play();
            IsOpening = false;
            IsClosing = true;

            while (!IsClosed)
            {
                yield return null;

                _door.localPosition = Vector3.MoveTowards(_door.localPosition, _closedPosition, _movingSpeed * Time.deltaTime);
            }

            IsClosing = false;
        }
    }
}
