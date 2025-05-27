using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    private const float _offSet = 3f;
    [SerializeField] private Camera _camera;

    private void Start()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        var positionY = _camera.ScreenToWorldPoint(Screen.safeArea.min).y + _offSet;
        transform.position = new Vector2(transform.position.x, positionY);
    }
}
