using HealthSystem;
using System;
using UISystem;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyController : MonoBehaviour, IHitable
    {
        [SerializeField] private EnemyDataSO enemyData;

        [Header("Health")]
        [SerializeField] private LoadCapacityDisplayer healthDisplayer;

        [Header("Hit Effects")]
        [SerializeField] private AudioSource gettingHitSource;

        [Header("Perception")]
        [SerializeField] private EnemyPerception.PerceptionReferences perceptionReferences;

        [Header("Movement")]
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Animator animator;

        [Header("Communication")]
        [SerializeField] private EnemyCommunication.CommunicationReferences communicationReferences;

        [Header("Combat")]
        [SerializeField] private EnemyWeapon.WeaponReferences weaponReferences;

        [Header("Objectives")]
        [SerializeField] private EnemyObjectives objectives;

        private Health _health;
        private EnemyPerception _perception;
        private EnemyMovement _movement;
        private EnemyCommunication _communication;
        private EnemyWeapon _weapon;

        public bool IsActive;

        private StateMachine _stateMachine;

        private void Awake()
        {
            _health = new(enemyData.MaxHealth, enemyData.MaxHealth);
            _health.OnHealthExpired += Death;
            HealthDisplayerController healthDisplayerController = new(_health, healthDisplayer);

            _perception = new(perceptionReferences, enemyData.PerceptionParameters);
            _movement = new(agent, animator, enemyData.MovementParameters);
            _communication = new(communicationReferences, enemyData.CommunicationParameters);
            _weapon = new(weaponReferences, enemyData.WeaponParameters);

            _stateMachine = new StateMachine();

            InactiveState inactiveState = new();
            ActiveState activeState = new(_movement, _perception, _communication, _weapon, objectives);

            _stateMachine.AddTransition(inactiveState, activeState, () => IsActive);
            _stateMachine.AddTransition(activeState, inactiveState, () => !IsActive);

            _stateMachine.SetState(inactiveState);
        }

        private void Start()
        {
            agent.updateRotation = false;
            agent.updateUpAxis = false;
        }

        private void FixedUpdate()
        {
            _stateMachine.Tick();
        }

        private void Death()
        {
            _health.OnHealthExpired -= Death;
            Destroy(gameObject);
        }

        public void Hit(int damage, Vector3 from)
        {
            gettingHitSource.Play();
            _health.CurrentHealth -= damage;
            objectives.PositionOfInterest = from;
        }

        public void SetPositionOfInterest(Vector3 position)
        {
            objectives.PositionOfInterest = position;
        }

        [Serializable]
        public class EnemyObjectives
        {
            [field: SerializeField] public Transform[] Waypoins { get; private set; }
            [field: SerializeField] public bool IsPatroling { get; private set; }
            public Vector3 PositionOfInterest { get; set; }
        }
    }
}
