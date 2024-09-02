// Decompiled with JetBrains decompiler
// Type: PopupClassChange
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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

  public void ChangeSprite(PvpClassKind.Condition c, bool isLowest = false)
  {
    string empty = string.Empty;
    this.sprite.spriteName = !isLowest || c != PvpClassKind.Condition.STAY_ZONE ? (!isLowest || c != PvpClassKind.Condition.STAY ? PopupClassChange.spriteName[(int) c] : PopupClassChange.spriteNameIsLowest) : PopupClassChange.spriteNameIsLowestZone;
    this.sprite.MakePixelPerfect();
  }
}
