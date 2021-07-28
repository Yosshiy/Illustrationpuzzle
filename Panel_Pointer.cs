using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// ポインターの処理
/// </summary>
public class Panel_Pointer : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    //回転する角度
    const float Angle = 90;
    //Image
    Image PanelImage;
    //ポインターが乗ったときの色
    Color32 EnterColor = new Color(185, 255, 185, 255);

    private void Start()
    {
        PanelImage = GetComponent<Image>();
    }

    /// <summary>
    /// ポインターが上に乗ったら
    /// </summary>
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        PanelImage.color = EnterColor;
    }

    /// <summary>
    /// ポインターが外れたら
    /// </summary>
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        PanelImage.color = Color.white;
    }

    /// <summary>
    /// クリックしたら
    /// </summary>
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        transform.eulerAngles += new Vector3(0, 0, Angle);
        Panel_Angle.Instance.CheckAngle();
    }
}
