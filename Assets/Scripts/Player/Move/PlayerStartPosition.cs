using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    private const float _offSet = 3f;

    private void Start()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        var positionY = new SafeAreaDATA().GetMin().y+2;
        transform.position = new Vector2(transform.position.x, positionY);
    }
}
