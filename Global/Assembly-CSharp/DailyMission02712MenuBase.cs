// Decompiled with JetBrains decompiler
// Type: DailyMission02712MenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DailyMission02712MenuBase : NGMenuBase
{
  [Header("Missions panel")]
  [SerializeField]
  protected GameObject DirMission;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UI2DSprite LaevateinnSprite;
  [SerializeField]
  protected UI2DSprite MasamuneSprite;
  [SerializeField]
  protected UI2DSprite OtherMissionBanner;
  [Header("Bingo panel")]
  [SerializeField]
  protected GameObject[] DirMissionPanels;
  [SerializeField]
  protected GameObject backUnit;
  [SerializeField]
  protected GameObject backShadowUnit;
  [SerializeField]
  protected GameObject backButon;
  [Header("Choose unit panel")]
  [SerializeField]
  protected GameObject DirChooseUnit;
  [SerializeField]
  protected GameObject IbtnLaevateinn;
  [SerializeField]
  protected GameObject IbtnMasamune;

  public void openChooseUnit() => this.DirChooseUnit.SetActive(true);
}
