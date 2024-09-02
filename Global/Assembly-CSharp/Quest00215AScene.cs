// Decompiled with JetBrains decompiler
// Type: Quest00215AScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new Quest00215AScene.\u003ConStartSceneAsync\u003Ec__Iterator1A1()
    {
      episode = episode,
      unit = unit,
      \u003C\u0024\u003Eepisode = episode,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }
}
