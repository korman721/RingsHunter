using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] public GameObject _arrowPrefab;
    [SerializeField] private GameObject _corsourPrefab;

    private Vector3 _mousePos;
    private GameObject _currentArrow;
    private GameObject _currentCorsour;
    private SpringJoint2D _springJoint;
    private bool _isAiming;

    void Update()
    {
        if (GameManager.Instance._endScreen.activeSelf == false && GameManager.Instance._settings.activeSelf == false )
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartAiming();
            }
            if (Input.GetMouseButton(0) && _isAiming)
            {
                Aim();
            }
            if (Input.GetMouseButtonUp(0))
            {
                ReleaseArrow();
            }
        }
    }

    void StartAiming()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _currentCorsour = Instantiate(_corsourPrefab, new Vector3(_mousePos.x, _mousePos.y), Quaternion.identity);
        _currentArrow = Instantiate(_arrowPrefab, new Vector3(_mousePos.x, _mousePos.y), Quaternion.identity);
        _springJoint = _currentArrow.GetComponent<SpringJoint2D>();
        _springJoint.connectedBody = _currentCorsour.GetComponent<Rigidbody2D>();
        _isAiming = true;
    }

    void Aim()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (Vector2)(mousePosition - _currentCorsour.transform.position);
        _springJoint.distance = direction.magnitude;
        _currentArrow.transform.up = -direction;
    }

    void ReleaseArrow()
    {
        Destroy(_springJoint);
        if (_springJoint.distance <= 0.5f && _springJoint != null)
        {
            Destroy(_currentArrow);
        }
        _currentArrow.GetComponent<Rigidbody2D>().velocity = _currentArrow.transform.up * _springJoint.distance * 22.5f;
        Destroy(_currentCorsour);
        _isAiming = false;
    }
}
