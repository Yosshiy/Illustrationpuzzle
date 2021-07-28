using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// ResourceからSpriteを読み込む拡張メソッド
/// </summary>
public class Load : MonoBehaviour
{
    public static List<Sprite> LoadSprite(string filename)
    {
        var sprites = Resources.LoadAll<Sprite>(filename);
        return sprites.ToList();
    }
}
