using UnityEngine;

public class SaveSafeArea : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Start()
    {
        SafeAreaDATA safeAreaDATA = new SafeAreaDATA();
        safeAreaDATA.SetMax(_camera.ScreenToWorldPoint(Screen.safeArea.max));
        safeAreaDATA.SetMin(_camera.ScreenToWorldPoint(Screen.safeArea.min));
    }
}
