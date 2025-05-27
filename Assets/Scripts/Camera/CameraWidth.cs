using UnityEngine;
[RequireComponent(typeof(Camera))]
public class CameraWidth : MonoBehaviour
{
    private const float _width = 1080f;
    private const float _halfSizeInPixel = 200f;

    private void Awake()
    {
        GetComponent<Camera>().orthographicSize = _width * Screen.height/ Screen.width/ _halfSizeInPixel;
    }
}

