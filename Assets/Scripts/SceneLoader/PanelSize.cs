using UnityEditor.SearchService;
using UnityEngine;



[RequireComponent(typeof(RectTransform))]
public class PanelSize : MonoBehaviour
{
    [SerializeField] private Location _location;


    private void Awake()
    {
        CalculateSafeArea();
    }

    private void CalculateSafeArea()
    {
        var safeArea = Screen.safeArea;
        var anchorMin = safeArea.position;
        var anchorMax = anchorMin + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        SetAnchors(anchorMin, anchorMax);
    }

    private void SetAnchors(Vector2 anchorMin, Vector2 anchorMax)
    {
        var rectTranform = GetComponent<RectTransform>();

        switch (_location)
        {
            case Location.Top:
                rectTranform.anchorMin = new Vector2(anchorMin.x, anchorMax.y);
                if(rectTranform.anchorMin.y == rectTranform.anchorMax.y)
                {
                    gameObject.SetActive(false);
                }
                break;
            case Location.Centre:
                rectTranform.anchorMin = anchorMin;
                rectTranform.anchorMax = anchorMax;
                break;
            case Location.Bottom:
                rectTranform.anchorMax = new Vector2(anchorMax.x, anchorMin.y);
                if (rectTranform.anchorMax.y == rectTranform.anchorMin.y)
                {
                    gameObject.SetActive(false) ;
                }
                    break;
        }

    }

    public enum Location
    {
        Top,
        Centre,
        Bottom
    }
}
