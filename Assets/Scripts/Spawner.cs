using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wawe> _wawes;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private Wawe _currentWawe;
    private int _currentWaweNumber = 0;
    private float _timerAfterLastSpawn;
    private int _spawned;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWawe(_currentWaweNumber);
    }

    private void Update()
    {
        if (_currentWawe == null)
            return;

        _timerAfterLastSpawn += Time.deltaTime;

        if(_timerAfterLastSpawn >= _currentWawe.Delay)
        {
            InstantietEnemy();
            _spawned++;
            _timerAfterLastSpawn = 0;
            EnemyCountChanged?.Invoke(_spawned, _currentWawe.Count);
        }

        if (_currentWawe.Count <= _spawned)
        {
                if (_wawes.Count > _currentWaweNumber + 1)
                    AllEnemySpawned?.Invoke();

            _currentWawe = null;
        }
    }

    private void InstantietEnemy()
    {
        Enemy enemy = Instantiate(_currentWawe.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.Dying += OnEnemyDying;
    }

    private void SetWawe(int index)
    {
        _currentWawe = _wawes[index];
        EnemyCountChanged?.Invoke(0, 1);
    }

    public void NextWawe()
    {
      SetWawe(++_currentWaweNumber);
        _spawned = 0;
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;

        _player.AddMoney(enemy.Reward);
    }
}

[System.Serializable]
public class Wawe
{
    public GameObject Template;
    public float Delay;
    public int Count;
}
