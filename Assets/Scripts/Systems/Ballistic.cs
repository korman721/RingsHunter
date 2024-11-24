using TMPro;
using UnityEngine;

public class Ballistic : MonoBehaviour
{
    public static Ballistic Instance;

    private float g = Physics.gravity.y;

    private void Awake()
    {
        Instance = this;
    }

    public void Throw(Transform _spawn, Transform _target, float _angleInDegrees, GameObject _ring)
    {
        Vector3 FromTo = _target.position - _spawn.position;

        _spawn.Rotate(0, 0, _angleInDegrees);

        float x = FromTo.magnitude;
        float y = FromTo.y;

        float InRadians = _angleInDegrees * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(InRadians) * x) * Mathf.Pow(Mathf.Cos(InRadians), 2));
        float v = Mathf.Sqrt(Mathf.Abs(v2));

        GameObject SpawnRing = Instantiate(_ring, _spawn.position, Quaternion.identity);
        SpawnRing.GetComponent<Rigidbody2D>().velocity = _spawn.right * v;

        _spawn.Rotate(0, 0, -_angleInDegrees);
    }
}
