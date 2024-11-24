using System.ComponentModel.Design;
using UnityEngine;

public class RotationOfRing : MonoBehaviour
{
    [SerializeField] private Transform Spawn;

    private float _spawny;

    private void Start()
    {
        _spawny = Spawn.position.y;
    }

    private void Update()
    {
        float NowX = transform.position.x;
        float NowY = transform.position.y - _spawny;
        RotateRing(NowX, NowY);
    }

    private void RotateRing(float x, float y)
    {
        float alpha = 90f + (Mathf.Atan(y / x) * 180) / Mathf.PI;
        if (gameObject.name.EndsWith("L(Clone)") && transform.position.x > 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, alpha - 180);
        }
        else if (gameObject.name.EndsWith("R(Clone)") && transform.position.x < 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, alpha - 180);
        }
        else { transform.rotation = Quaternion.Euler(0f, 0f, alpha); }
    }
}
