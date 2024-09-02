// Decompiled with JetBrains decompiler
// Type: Battle01PVPDispositionHeader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01PVPDispositionHeader : NGBattleMenuBase
{
  [SerializeField]
  private UILabel toVictory;
  [SerializeField]
  private UILabel toVictorySub;
  [SerializeField]
  private UILabel matching;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01PVPDispositionHeader.\u003CStart_Battle\u003Ec__Iterator87D()
    {
      \u003C\u003Ef__this = this
    };
  }

  private string matchingText(PvpMatchingTypeEnum type)
  {
    Consts instance = Consts.GetInstance();
    switch (type)
    {
      case PvpMatchingTypeEnum.friend:
      case PvpMatchingTypeEnum.guest:
        return instance.PVP_MATCHING_TYPE_FREAND;
      case PvpMatchingTypeEnum.class_match:
        return instance.PVP_MATCHING_TYPE_CLASS;
      default:
        return instance.PVP_MATCHING_TYPE_RANDOM;
    }
  }
}
