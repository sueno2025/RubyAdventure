using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance {get; private set;}
    public UnityEngine.UI.Image mask;
    float originalSize;

    void Awake()
    {
        instance= this;    
    }
    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
    }
    public void SetValue(float value){
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,originalSize * value);
    }
}
