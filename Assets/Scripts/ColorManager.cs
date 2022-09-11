using System;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance;
    private Color32 _currentColor = new Color32(0xFE, 0x00, 0xBC,0xFF);

    public Color32 CurrentColor
    {
        get
        {
            return _currentColor;
        }
        set
        {
            _currentColor = value;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    
}

