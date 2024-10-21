
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{

    [SerializeField] private Slider slider;

    public void UpdateHealthBar(float currentValue)
    {
        slider.value = currentValue;
    }

  

}
