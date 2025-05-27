using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void ShowValue(int value)
    {
        _text.text = value.ToString();
    }
}
