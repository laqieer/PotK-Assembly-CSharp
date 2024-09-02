// Decompiled with JetBrains decompiler
// Type: Quest0022MissionDescription
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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

  [DebuggerHidden]
  public IEnumerator InitValue(QuestStoryMission[] missions, PlayerMissionHistory[] hists)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022MissionDescription.\u003CInitValue\u003Ec__Iterator1E7()
    {
      hists = hists,
      missions = missions,
      \u003C\u0024\u003Ehists = hists,
      \u003C\u0024\u003Emissions = missions,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitValue(QuestExtraMission[] missions, PlayerMissionHistory[] hists)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022MissionDescription.\u003CInitValue\u003Ec__Iterator1E8()
    {
      hists = hists,
      missions = missions,
      \u003C\u0024\u003Ehists = hists,
      \u003C\u0024\u003Emissions = missions,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator LoadAnimation()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022MissionDescription.\u003CLoadAnimation\u003Ec__Iterator1E9()
    {
      \u003C\u003Ef__this = this
    };
  }
}
