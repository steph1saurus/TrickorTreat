
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloatingHealthBar : MonoBehaviour
{

    [Header("Health UI")]
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;

    public void UpdateHealthBar(float currentValue)
    {
        slider.value = currentValue;
    }

  

}
