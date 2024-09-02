// Decompiled with JetBrains decompiler
// Type: SheetGachaGetBonus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class SheetGachaGetBonus : MonoBehaviour
{
  public GameObject IconObject;
  public UILabel CompleteText;
  [SerializeField]
  private SheetGachaAnim anim;

  [DebuggerHidden]
  public IEnumerator Init(GachaG007PlayerPanel panel, System.Action endAction)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new SheetGachaGetBonus.\u003CInit\u003Ec__Iterator476()
    {
      panel = panel,
      endAction = endAction,
      \u003C\u0024\u003Epanel = panel,
      \u003C\u0024\u003EendAction = endAction,
      \u003C\u003Ef__this = this
    };
  }
}
