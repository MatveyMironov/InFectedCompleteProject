using System;
using UnityEngine;

namespace PlayerSystem
{
    public class Movement
    {
        private Rigidbody2D _rigidbody;

        public Movement(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        private Vector2 _movementVelocity;

        public float CurrentSpeed { get => _movementVelocity.magnitude; }

        public void Move(Vector2 targetVelocity, float acceleration, float deceleration)
        {
            if (Vector2.Angle(targetVelocity, _movementVelocity) > 90)
            {
                Decelerate(deceleration);
            }
            else
            {
                Accelerate(targetVelocity, acceleration);
            }
        }

        private void Accelerate(Vector2 targetVelocity, float acceleration)
        {
            _movementVelocity = Vector2.MoveTowards(_movementVelocity, targetVelocity, acceleration * Time.deltaTime);
            _rigidbody.velocity = _movementVelocity;
        }

        private void Decelerate(float deceleration)
        {
            _movementVelocity = Vector2.MoveTowards(_movementVelocity, Vector2.zero, deceleration * Time.deltaTime);
            _rigidbody.velocity = _movementVelocity;
        }
    }
}
