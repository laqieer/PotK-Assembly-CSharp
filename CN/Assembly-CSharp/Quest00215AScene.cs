// Decompiled with JetBrains decompiler
// Type: Quest00215AScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Quest00215AScene.\u003ConStartSceneAsync\u003Ec__Iterator1DB()
    {
      episode = episode,
      unit = unit,
      \u003C\u0024\u003Eepisode = episode,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }
}
