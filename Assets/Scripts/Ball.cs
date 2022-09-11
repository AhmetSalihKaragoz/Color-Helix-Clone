using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    [SerializeField] private new Renderer renderer;

    private Image _progressBarImage;
    
    
    private void Start()
    {
        _progressBarImage = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<Image>();
        ChangeBallColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ColorShifter"))
        {
            SetGameColor(other.gameObject);
            ChangeBallColor();
            ChangeProgressBarColor();
        }
        else if (other.gameObject.CompareTag("FinishLine"))
        {
            LevelManager.Instance.LoadNextLevel();
        }
        
    }

    private void ChangeBallColor()
    {
        renderer.material.color = ColorManager.Instance.CurrentColor;
    }

    private void ChangeProgressBarColor()
    {
        _progressBarImage.material.color = ColorManager.Instance.CurrentColor;
    }

    private void SetGameColor(GameObject other)
    {
        ColorManager.Instance.CurrentColor = other.GetComponent<Renderer>().material.color;
    }
    
}
