// Decompiled with JetBrains decompiler
// Type: Quest0022MissionDescription
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest0022MissionDescription : MonoBehaviour
{
  public Quest0022MissionList[] MissionList;
  public GameObject[] ThumbnailList;
  public UIButton btnClose;

  [DebuggerHidden]
  public virtual IEnumerator InitValue(QuestStoryMission[] missions, PlayerMissionHistory[] hists)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022MissionDescription.\u003CInitValue\u003Ec__Iterator260()
    {
      hists = hists,
      missions = missions,
      \u003C\u0024\u003Ehists = hists,
      \u003C\u0024\u003Emissions = missions,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator InitValue(QuestExtraMission[] missions, PlayerMissionHistory[] hists)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022MissionDescription.\u003CInitValue\u003Ec__Iterator261()
    {
      hists = hists,
      missions = missions,
      \u003C\u0024\u003Ehists = hists,
      \u003C\u0024\u003Emissions = missions,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator LoadAnimation()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022MissionDescription.\u003CLoadAnimation\u003Ec__Iterator262()
    {
      \u003C\u003Ef__this = this
    };
  }
}
