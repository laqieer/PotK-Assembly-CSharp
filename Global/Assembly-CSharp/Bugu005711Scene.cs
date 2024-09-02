// Decompiled with JetBrains decompiler
// Type: Bugu005711Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu005711Scene : NGSceneBase
{
  public Bugu005711Menu menu;
  private PlayerItem[] supplies;
  public int id = 1;
  public Transform middleTransform;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005711Scene.\u003ConInitSceneAsync\u003Ec__Iterator342()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005711Scene.\u003ConStartSceneAsync\u003Ec__Iterator343()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerItem supply, Bugu0052Menu menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005711Scene.\u003ConStartSceneAsync\u003Ec__Iterator344()
    {
      supply = supply,
      menu = menu,
      \u003C\u0024\u003Esupply = supply,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int supply_id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005711Scene.\u003ConStartSceneAsync\u003Ec__Iterator345()
    {
      supply_id = supply_id,
      \u003C\u0024\u003Esupply_id = supply_id,
      \u003C\u003Ef__this = this
    };
  }
}
