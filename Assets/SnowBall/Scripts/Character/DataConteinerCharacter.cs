using UnityEngine;

public class DataConteinerCharacter : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    public float speedMove=>_speedMove;
    [SerializeField] private float _shotDelay;
    public float shotDelay => _shotDelay;
    
}
