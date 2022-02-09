using UnityEngine;

/// <summary>
/// Clicking on game objects
/// </summary>
public class Click : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerInfo;
    private GameObject _circle, _triangle, _square;
    void Update ()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            var p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(p, Vector2.zero); 
            if (hit.collider != null)
            {
                switch (hit.collider.gameObject.tag)
                {
                    case "Circle":
                        _circle = hit.collider.gameObject;
                        break;
                    case "Triangle":
                        _triangle = hit.collider.gameObject;
                        break;
                    case "Square":
                        _square = hit.collider.gameObject;
                        break;
                }
            }

            if (_triangle != null && _square != null)
            {
                _square.transform.localScale = new Vector3(_square.transform.localScale.x - 0.1f,_square.transform.localScale.y - 0.1f);
                _triangle.SetActive(false);
                _triangle = null;
                _playerInfo.DestroyEnergy();
            }

            if (_square == null && _circle != null)
            {
                _circle = null;
            }

            if (_square != null && _circle != null)
            {
                if (_circle.transform.localScale.x - 0.05f > _square.transform.localScale.x)
                {
                    _square.transform.position = _circle.transform.position;
                    _circle = null;
                    _square = null;
                    _playerInfo.UpMove();
                }
            }

            else
            {
                Debug.Log("Select game object");
            }
        }
    }
}