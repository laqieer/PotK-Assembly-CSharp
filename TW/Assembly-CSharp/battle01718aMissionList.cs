// Decompiled with JetBrains decompiler
// Type: battle01718aMissionList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class battle01718aMissionList : MonoBehaviour
{
  public battle01718aMission[] MissionList;

  [DebuggerHidden]
  public IEnumerator InitValue(PlayerMissionHistory[] hists, QuestStoryMission[] story)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new battle01718aMissionList.\u003CInitValue\u003Ec__Iterator897()
    {
      hists = hists,
      story = story,
      \u003C\u0024\u003Ehists = hists,
      \u003C\u0024\u003Estory = story,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitValue(PlayerMissionHistory[] hists, QuestExtraMission[] extra)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new battle01718aMissionList.\u003CInitValue\u003Ec__Iterator898()
    {
      hists = hists,
      extra = extra,
      \u003C\u0024\u003Ehists = hists,
      \u003C\u0024\u003Eextra = extra,
      \u003C\u003Ef__this = this
    };
  }

  public void ibtnBack() => Singleton<PopupManager>.GetInstance().onDismiss();
}
