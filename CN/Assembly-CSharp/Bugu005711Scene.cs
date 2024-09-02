// Decompiled with JetBrains decompiler
// Type: Bugu005711Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Bugu005711Scene.\u003ConInitSceneAsync\u003Ec__Iterator3B9()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005711Scene.\u003ConStartSceneAsync\u003Ec__Iterator3BA()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(InventoryItem item, Bugu0052Menu menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005711Scene.\u003ConStartSceneAsync\u003Ec__Iterator3BB()
    {
      item = item,
      menu = menu,
      \u003C\u0024\u003Eitem = item,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int supply_id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005711Scene.\u003ConStartSceneAsync\u003Ec__Iterator3BC()
    {
      supply_id = supply_id,
      \u003C\u0024\u003Esupply_id = supply_id,
      \u003C\u003Ef__this = this
    };
  }
}
