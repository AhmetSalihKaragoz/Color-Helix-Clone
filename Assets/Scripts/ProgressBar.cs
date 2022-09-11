using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image progressBarImage;
    [SerializeField] private TextMeshProUGUI progressPercentageText;

    private Transform _finishLine;
    private float _progressPercentage;
    private float _fillAmount;
    private float _maxDistance;
    private void Update()
    {
        Progress();
        ProgressText();
    }

    private void Start()
    {
        _finishLine = GameObject.FindGameObjectWithTag("FinishLine").GetComponent<Transform>();
        _maxDistance = _finishLine.transform.position.z;
        progressBarImage.material.color = ColorManager.Instance.CurrentColor;
    }

    private void Progress()
    {
        if (!GameManager.Instance.HasStarted) return;
        var distanceOffset = _maxDistance - _finishLine.position.z;
        progressBarImage.fillAmount = _fillAmount;
        _fillAmount = distanceOffset / _maxDistance;
    }

    private void ProgressText()
    {
        if (!GameManager.Instance.HasStarted) return;
        _progressPercentage = Mathf.Clamp(((0.01f - _fillAmount) * -100), 0, 100);
        progressPercentageText.text = (int)_progressPercentage + "%";

    }
    
}
