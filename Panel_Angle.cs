using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Angle : MonoBehaviour
{
    #region シングルトン
    /// <summary>
    /// シングルトン
    /// </summary>
    private static Panel_Angle instance;

    public static Panel_Angle Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError(typeof(Panel_Angle) + "が存在しません");
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    #endregion

    //画像表示用のImage
    [SerializeField] List<Image> Panel;
    //Resourceのパス
    [SerializeField] List<string> FilePath;
    //クリアキャンバス
    [SerializeField] Canvas ClearCanvas;
    //タイトルキャンバス
    [SerializeField] Canvas TitleCanvas;
    //メインキャンバス
    [SerializeField] Canvas MainCanvas;

    void Start()
    {
        ReStart();
    }

    /// <summary>
    /// 再配置
    /// </summary>
    public void ReStart()
    {
        ClearCanvas.gameObject.SetActive(false);
        var sprites = Load.LoadSprite(FilePath[Random.Range(0, FilePath.Count)]);

        for(int i = 0; i < Panel.Count; i++)
        {
            Panel[i].transform.eulerAngles += new Vector3(0, 0, 90 * Random.Range(0, 4));
            Panel[i].sprite = sprites[i];
        }
        
    }

    /// <summary>
    /// クリアしているかどうかの判定
    /// </summary>
    public void CheckAngle()
    {
        foreach(var list in Panel)
        {
            if((int)list.transform.eulerAngles.z != 0)
            {
                return;
            }
        }

        Clear();

     }

    /// <summary>
    /// クリア処理
    /// </summary>
    void Clear()
    {
        ClearCanvas.gameObject.SetActive(true);
    }
    
    /// <summary>
    /// スタート処理
    /// </summary>
    public void GameStart()
    {
        TitleCanvas.gameObject.SetActive(false);
        MainCanvas.gameObject.SetActive(true);
    }
}
