// Decompiled with JetBrains decompiler
// Type: battle01718aMissionObj
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class battle01718aMissionObj : BattleBackButtonMonoBehaiviour
{
  [SerializeField]
  private battle01718aMissionList[] MissionObjList;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new battle01718aMissionObj.\u003CStart_Battle\u003Ec__Iterator7CE()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitStoryMission(PlayerStoryQuestS story)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new battle01718aMissionObj.\u003CInitStoryMission\u003Ec__Iterator7CF()
    {
      story = story,
      \u003C\u0024\u003Estory = story,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitExtraMission(PlayerExtraQuestS extra)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new battle01718aMissionObj.\u003CInitExtraMission\u003Ec__Iterator7D0()
    {
      extra = extra,
      \u003C\u0024\u003Eextra = extra,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator init(GameCore.BattleInfo info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new battle01718aMissionObj.\u003Cinit\u003Ec__Iterator7D1()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  public void Back() => this.battleManager.popupDismiss();

  public override void onBackButton() => this.Back();
}
