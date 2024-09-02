// Decompiled with JetBrains decompiler
// Type: PopupClassChange
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

#nullable disable
public class PopupClassChange : MonoBehaviour
{
  [SerializeField]
  private UISprite sprite;
  private static readonly string[] spriteName = new string[12]
  {
    "text_ClassDown.png__GUI__versus_results_common__versus_results_common_prefab",
    "text_ClassStayed.png__GUI__versus_results_common__versus_results_common_prefab",
    "text_ClassStayedTop.png__GUI__versus_results_common__versus_results_common_prefab",
    "text_ClassUp.png__GUI__versus_results_common__versus_results_common_prefab",
    "text_ClassTitle.png__GUI__versus_results_common__versus_results_common_prefab",
    "text_ClassTitleTop.png__GUI__versus_results_common__versus_results_common_prefab",
    "text_ClassDownZone.png__GUI__versus_results_common__versus_results_common_prefab",
    "text_ClassStayedZone.png__GUI__versus_results_common__versus_results_common_prefab",
    "text_ClassStayedTop.png__GUI__versus_results_common__versus_results_common_prefab",
    "text_ClassUpZone.png__GUI__versus_results_common__versus_results_common_prefab",
    "text_ClassTitleZone.png__GUI__versus_results_common__versus_results_common_prefab",
    "text_ClassTitleTop.png__GUI__versus_results_common__versus_results_common_prefab"
  };
  private static readonly string spriteNameIsLowest = "text_ClassStayedBottom.png__GUI__versus_results_common__versus_results_common_prefab";
  private static readonly string spriteNameIsLowestZone = "text_ClassStayedZoneBottom.png__GUI__versus_results_common__versus_results_common_prefab";
  private static readonly string spriteNameClassTitleTopStayed = "text_ClassTitleTopStayed.png__GUI__versus_results_common__versus_results_common_prefab";
  private static readonly string spriteNameClassStayedTopSafe = "text_ClassStayedTopSafe.png__GUI__versus_results_common__versus_results_common_prefab";

  public void ChangeSprite(PvpClassKind.Condition c, bool isLowest = false, bool isTop = false)
  {
    string empty = string.Empty;
    string str;
    if (isLowest && c == PvpClassKind.Condition.STAY_ZONE)
      str = PopupClassChange.spriteNameIsLowestZone;
    else if (isLowest && c == PvpClassKind.Condition.STAY)
      str = PopupClassChange.spriteNameIsLowest;
    else if (isTop)
    {
      switch (c)
      {
        case PvpClassKind.Condition.STAY_TOPCLASS:
          str = PopupClassChange.spriteNameClassStayedTopSafe;
          break;
        case PvpClassKind.Condition.TITLE_TOPCLASS:
          str = PopupClassChange.spriteNameClassTitleTopStayed;
          break;
        default:
          str = PopupClassChange.spriteName[(int) c];
          break;
      }
    }
    else
      str = PopupClassChange.spriteName[(int) c];
    this.sprite.spriteName = str;
    this.sprite.MakePixelPerfect();
  }
}
