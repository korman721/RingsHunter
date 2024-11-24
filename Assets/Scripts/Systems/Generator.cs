using System.Collections;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    [SerializeField] public GameObject[] _rings;

    private float _timer;

    private void Awake()
    {
        _timer = 4f;
    }

    private void Update()
    {
        if (_timer <= 0.1f)
        {
            Gener();
            _timer = 4f;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
    private void Gener()
    {
        int _point = Random.Range(0, 2);
        if (_point == 0)
        {
            Ballistic.Instance.Throw(_points[0], _points[1], Random.Range(64.5f, 70.5f), _rings[0]);
        }
        if (_point == 1)
        {
            Ballistic.Instance.Throw(_points[1], _points[0], Random.Range(115.5f, 109.5f), _rings[1]);
        }
    }
}
