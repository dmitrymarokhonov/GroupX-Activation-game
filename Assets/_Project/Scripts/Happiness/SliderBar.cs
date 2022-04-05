using System;
using UnityEngine;
using UnityEngine.UI;

namespace Relanima.Happiness
{
    public class SliderBar : MonoBehaviour
    {
        public Slider slider;
        public Gradient gradient;
        public Image fill;
        public bool useGradient;
    
        public Color blue = new Color(0.36f, 0.29f, 1, 1);
        public Color cyan = new Color(0.34f, 0.93f, 1, 1);
        public Color green = new Color(0.29f, 1, 0.32f, 1);

        private void Start()
        {
            fill.color = green;
        }

        public void SetMaxValue(float value)
        {
            slider.maxValue = value;
        }

        public void SetValue(float value)
        {
            slider.value = value;
            EvaluateGradientColor();
        }

        public void Reset()
        {
            gameObject.SetActive(false);
            useGradient = false;
            fill.color = green;
        }

        public void UseGradient()
        {
            useGradient = true;
        }

        private void EvaluateGradientColor()
        {
            if (!useGradient) return;
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }
}
