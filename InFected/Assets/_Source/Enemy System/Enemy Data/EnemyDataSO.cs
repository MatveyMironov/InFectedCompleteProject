using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy/Enemy Data")]
    public class EnemyDataSO : ScriptableObject
    {
        [Header("Health")]
        [SerializeField] private int maxHealth;

        [field: SerializeField] public EnemyPerception.PerceptionParameters PerceptionParameters { get; private set; }
        [field: SerializeField] public EnemyMovement.MovementParameters MovementParameters { get; private set; }
        [field: SerializeField] public EnemyCommunication.CommunicationParameters CommunicationParameters { get; private set; }
        [field: SerializeField] public EnemyWeapon.WeaponParameters WeaponParameters { get; private set; }

        public int MaxHealth { get => maxHealth; }
    }
}
