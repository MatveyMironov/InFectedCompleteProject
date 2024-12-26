using UnityEngine;

namespace PlayerSystem
{
    public class Turning
    {
        private Rigidbody2D _rigidbody;

        public Turning(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void TurnInstantly(float aimAngle)
        {
            if (_rigidbody.rotation != aimAngle)
            {
                _rigidbody.rotation = aimAngle;
            }
        }

        public void TurnWithSpeed(float aimAngle, float turningSpeed)
        {
            if (_rigidbody.rotation != aimAngle)
            {
                _rigidbody.rotation = Mathf.MoveTowardsAngle(_rigidbody.rotation, aimAngle, turningSpeed * Time.fixedDeltaTime);
            }
        }
    }
}
