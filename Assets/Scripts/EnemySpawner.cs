using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _location;
    [SerializeField] private int _timeToWait;

    private int _currentPoint;
    private Transform[] _points;

    private void Start()
    {
        SetPoints();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(Create());
        }
    }

    private void SetPoints()
    {
        _points = new Transform[_location.childCount];

        for (int i = 0; i < _location.childCount; i++)
        {
            _points[i] = _location.GetChild(i);
        }
    }

    private IEnumerator Create()
    {
        for (int i = 0; i < _location.childCount; i++)
        {
            Instantiate(_enemyPrefab, _points[i].transform.position, quaternion.identity);
            yield return new WaitForSeconds(_timeToWait);
        }
    }
}