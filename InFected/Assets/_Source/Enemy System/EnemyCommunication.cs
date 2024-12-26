using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyCommunication
    {
        private CommunicationReferences _references;
        private CommunicationParameters _parameters;

        public EnemyCommunication(CommunicationReferences references, CommunicationParameters parameters)
        {
            _references = references;
            _parameters = parameters;
        }

        public void CommunicatePosition(Vector3 position)
        {
            Vector3 communicatorPosition = _references.Communicator.position;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(communicatorPosition, _parameters.CommunicationRadius, _parameters.RecievingLayers);
            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out EnemyController reciever))
                {
                    Vector3 toReciever = collider.transform.position - communicatorPosition;
                    Vector3 direction = toReciever.normalized;
                    float distance = toReciever.magnitude;

                    RaycastHit2D[] hits = Physics2D.RaycastAll(communicatorPosition, direction, distance);

                    if (hits.Length > 1)
                    {
                        if (hits[1].transform.TryGetComponent(out EnemyController enemy))
                        {
                            enemy.SetPositionOfInterest(position);
                        }
                    }
                }
            }
        }

        [Serializable]
        public class CommunicationReferences
        {
            [field: SerializeField] public Transform Communicator { get; private set; }
        }

        [Serializable]
        public class CommunicationParameters
        {
            [field: SerializeField] public LayerMask RecievingLayers { get; private set; }
            [field: SerializeField] public float CommunicationRadius { get; private set; }
        }
    }
}
