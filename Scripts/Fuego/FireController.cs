using UnityEngine;
using UnityEngine.UI;

public class FireAndSparksSlider : MonoBehaviour
{
    [Header("Particle Systems")]
    [SerializeField] private ParticleSystem fireParticles;   // Particle System del fuego
    [SerializeField] private ParticleSystem sparksParticles; // Particle System de chispas

    [Header("UI")]
    [SerializeField] private Slider slider;

    private ParticleSystem.EmissionModule fireEmission;
    private ParticleSystem.EmissionModule sparksEmission;

    void Start()
    {
        if (fireParticles != null && sparksParticles != null && slider != null)
        {
            // Obtenemos los módulos de emisión
            fireEmission = fireParticles.emission;
            sparksEmission = sparksParticles.emission;

            // Configuramos el slider con rango de 0 a 10
            slider.minValue = 0f;
            slider.maxValue = 10f;

            // Inicializamos el slider con el valor de la emisión del fuego (aproximado)
            slider.value = Mathf.Clamp(fireEmission.rateOverTime.constant, 0f, 10f);

            // Conectamos el slider al método SetIntensity
            slider.onValueChanged.AddListener(SetIntensity);
        }
    }

    // Ajusta ambos Particle Systems con el mismo valor
    public void SetIntensity(float value)
    {
        if (fireParticles != null)
        {
            var rateFire = fireEmission.rateOverTime;
            rateFire.constant = value;
            fireEmission.rateOverTime = rateFire;
        }

        if (sparksParticles != null)
        {
            var rateSparks = sparksEmission.rateOverTime;
            rateSparks.constant = value;
            sparksEmission.rateOverTime = rateSparks;
        }
    }

    void OnDestroy()
    {
        if (slider != null)
            slider.onValueChanged.RemoveListener(SetIntensity);
    }
}