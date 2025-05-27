using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class CameraBorderHight : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private const float _fullSize = 2f;

    private void Start()
    {
        SetSize();
    }

    private void SetSize()
    {
        float yScale = _camera.ScreenToWorldPoint(Screen.safeArea.max).y * _fullSize;
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(boxCollider2D.size.x, yScale);
    }
}
