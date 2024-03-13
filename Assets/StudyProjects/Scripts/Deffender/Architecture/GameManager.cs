using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] private Transform _base;

    [Header("Enemies Options")]
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private List<Transform> _spawnPoints = new();
    [SerializeField] private float _spawnDelay = 5;
    private float _spawnTimer = 0f;

    private Player _player;

    public Vector3 BasePos => _base.position;

    void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer > _spawnDelay)
        {
            Vector3 spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
            GameObject obj = Instantiate(_enemyPrefab, spawnPoint, new Quaternion());
            obj.GetComponent<Enemy>().Init(BasePos);
            _spawnTimer = 0f;
        }
    }
}
