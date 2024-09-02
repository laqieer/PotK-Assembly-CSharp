// Decompiled with JetBrains decompiler
// Type: Quest00215AScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Quest00215AScene : NGSceneBase
{
  public Quest00215AMenu menu;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int episode, UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00215AScene.\u003ConStartSceneAsync\u003Ec__Iterator208()
    {
      episode = episode,
      unit = unit,
      \u003C\u0024\u003Eepisode = episode,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }
}
