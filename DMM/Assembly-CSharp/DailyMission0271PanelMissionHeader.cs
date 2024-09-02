// Decompiled with JetBrains decompiler
// Type: DailyMission0271PanelMissionHeader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using UnityEngine;

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

  public IEnumerator InitHeader(PlayerBingo bingoData)
  {
    this.playerBingo = bingoData;
    BingoBingo bingoBingo = MasterData.BingoBingo[bingoData.bingo_id];
    if (bingoBingo.end_at.HasValue)
      this.SetTime(bingoBingo.end_at.Value - ServerTime.NowAppTimeAddDelta());
    else
      this.remainingTimeRoot.SetActive(false);
    Future<UnityEngine.Sprite> imageF = Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>(string.Format("PanelMission/Header/{0}", (object) bingoBingo.header_image_name));
    IEnumerator e = imageF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    UnityEngine.Sprite result = imageF.Result;
    this.header.sprite2D = result;
    this.header.width = (int) result.textureRect.width;
    this.header.height = (int) result.textureRect.height;
  }

  public void SetTime(TimeSpan remainingTime)
  {
    this.remainingTimeRoot.SetActive(true);
    int a;
    if (remainingTime.Days > 0)
    {
      a = remainingTime.Days;
      this.remainingTimeUnit.spriteName = DailyMission0271PanelMissionHeader.UnitDaySpriteName;
    }
    else if (remainingTime.Hours > 0)
    {
      a = remainingTime.Hours;
      this.remainingTimeUnit.spriteName = DailyMission0271PanelMissionHeader.UnitHourySpriteName;
    }
    else
    {
      a = remainingTime.Minutes;
      this.remainingTimeUnit.spriteName = DailyMission0271PanelMissionHeader.UnitMinuteSpriteName;
    }
    int num1 = Mathf.Min(a, 99);
    int num2 = num1 / 10 % 10;
    int num3 = num1 % 10;
    if (num2 > 0)
    {
      this.remainingTimeLeftNumber.gameObject.SetActive(true);
      this.remainingTimeLeftNumber.spriteName = string.Format(DailyMission0271PanelMissionHeader.NumberSpriteBaseName, (object) num2);
    }
    else
      this.remainingTimeLeftNumber.gameObject.SetActive(false);
    this.remainingTimeRightNumber.spriteName = string.Format(DailyMission0271PanelMissionHeader.NumberSpriteBaseName, (object) num3);
  }

  public PlayerBingo GetPlayerBingoData() => this.playerBingo;
}
