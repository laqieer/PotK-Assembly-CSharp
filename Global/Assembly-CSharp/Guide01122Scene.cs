// Decompiled with JetBrains decompiler
// Type: Guide01122Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Guide01122Scene : NGSceneBase
{
  public Guide01122Menu menu;
  public bool one;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide01122Scene.\u003ConInitSceneAsync\u003Ec__Iterator4B0()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide01122Scene.\u003ConStartSceneAsync\u003Ec__Iterator4B1()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene() => this.menu.onEndScene();

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide01122Scene.\u003ConEndSceneAsync\u003Ec__Iterator4B2()
    {
      \u003C\u003Ef__this = this
    };
  }
}
