// Decompiled with JetBrains decompiler
// Type: DailyMission0271PanelMissionHeader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission0271PanelMissionHeader : MonoBehaviour
{
  [SerializeField]
  private UI2DSprite header;
  [SerializeField]
  private GameObject remainingTimeRoot;
  [SerializeField]
  private UISprite remainingTimeUnit;
  [SerializeField]
  private UISprite remainingTimeLeftNumber;
  [SerializeField]
  private UISprite remainingTimeRightNumber;
  private static readonly string NumberSpriteBaseName = "slc_number_{0}.png__GUI__002-17_sozai__002-17_sozai_prefab";
  private static readonly string UnitDaySpriteName = "slc_Limitday_16.png__GUI__002-17_sozai__002-17_sozai_prefab";
  private static readonly string UnitHourySpriteName = "slc_Limithour_16.png__GUI__002-17_sozai__002-17_sozai_prefab";
  private static readonly string UnitMinuteSpriteName = "slc_Limitminute_16.png__GUI__002-17_sozai__002-17_sozai_prefab";
  private PlayerBingo playerBingo;

  [DebuggerHidden]
  public IEnumerator InitHeader(PlayerBingo bingoData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271PanelMissionHeader.\u003CInitHeader\u003Ec__Iterator6C8()
    {
      bingoData = bingoData,
      \u003C\u0024\u003EbingoData = bingoData,
      \u003C\u003Ef__this = this
    };
  }

  public void SetTime(TimeSpan remainingTime)
  {
    this.remainingTimeRoot.SetActive(true);
    int num1;
    if (remainingTime.Days > 0)
    {
      num1 = remainingTime.Days;
      this.remainingTimeUnit.spriteName = DailyMission0271PanelMissionHeader.UnitDaySpriteName;
    }
    else if (remainingTime.Hours > 0)
    {
      num1 = remainingTime.Hours;
      this.remainingTimeUnit.spriteName = DailyMission0271PanelMissionHeader.UnitHourySpriteName;
    }
    else
    {
      num1 = remainingTime.Minutes;
      this.remainingTimeUnit.spriteName = DailyMission0271PanelMissionHeader.UnitMinuteSpriteName;
    }
    int num2 = Mathf.Min(num1, 99);
    int num3 = num2 / 10 % 10;
    int num4 = num2 % 10;
    if (num3 > 0)
    {
      ((Component) this.remainingTimeLeftNumber).gameObject.SetActive(true);
      this.remainingTimeLeftNumber.spriteName = string.Format(DailyMission0271PanelMissionHeader.NumberSpriteBaseName, (object) num3);
    }
    else
      ((Component) this.remainingTimeLeftNumber).gameObject.SetActive(false);
    this.remainingTimeRightNumber.spriteName = string.Format(DailyMission0271PanelMissionHeader.NumberSpriteBaseName, (object) num4);
  }

  public PlayerBingo GetPlayerBingoData() => this.playerBingo;
}
