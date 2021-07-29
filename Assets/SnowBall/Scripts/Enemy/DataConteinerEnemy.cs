using UnityEngine;

[CreateAssetMenu(fileName ="EnemyData",menuName ="Data/Enemy")]
public class DataConteinerEnemy : ScriptableObject
{
    [SerializeField] private float _speed;
   public float speed => _speed;
   [SerializeField]private int _coins;
   public int coins => _coins;

    [SerializeField] private int _timeToStateShoot;
    public int timeToStateShoot => _timeToStateShoot;
    [SerializeField] private string _skin;
    public string skin => _skin;

}
