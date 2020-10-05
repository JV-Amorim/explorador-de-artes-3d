using UnityEngine;
using UnityEngine.UI;

public class CameraZoomController : MonoBehaviour
{
    #region Inspector Fields
    [Tooltip("The zoom value is equal to the MainCamera field of view.")]
    public float defaultZoomValue;
    public float maximumZoomPercentage;
    public Slider zoomSlider;
    #endregion

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        ResetZoom();
        zoomSlider.maxValue = maximumZoomPercentage / 100;
        zoomSlider.onValueChanged.AddListener((value) => mainCamera.fieldOfView = (1 - value) * defaultZoomValue);
    }

    public void ResetZoom()
    {
        mainCamera.fieldOfView = defaultZoomValue;
        zoomSlider.value = 0;
    }
}
