using UnityEngine;
using UnityEngine.UI;

public class LightIntensityController : MonoBehaviour
{
    #region Inspector Fields
    public float defaultLightIntensity = 1;
    public float minimumLightIntensity = 0.5f;
    public Slider lightIntensitySlider;
    #endregion

    private Light directionalLight;

    private void Start()
    {
        directionalLight = GameObject.FindGameObjectWithTag("DirectionalLight").GetComponent<Light>();
        ResetLightIntensity();
        lightIntensitySlider.minValue = minimumLightIntensity;
        lightIntensitySlider.onValueChanged.AddListener((value) => directionalLight.intensity = value * defaultLightIntensity);
    }

    public void ResetLightIntensity()
    {
        directionalLight.intensity = defaultLightIntensity;
        lightIntensitySlider.value = 1;
    }
}
