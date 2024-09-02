// Decompiled with JetBrains decompiler
// Type: battle01718aMissionObj
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
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
    return (IEnumerator) new battle01718aMissionObj.\u003CStart_Battle\u003Ec__Iterator688()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitStoryMission(PlayerStoryQuestS story)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new battle01718aMissionObj.\u003CInitStoryMission\u003Ec__Iterator689()
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
    return (IEnumerator) new battle01718aMissionObj.\u003CInitExtraMission\u003Ec__Iterator68A()
    {
      extra = extra,
      \u003C\u0024\u003Eextra = extra,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator init(BattleInfo info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new battle01718aMissionObj.\u003Cinit\u003Ec__Iterator68B()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  public void Back() => this.battleManager.popupDismiss();

  public override void onBackButton() => this.Back();
}
