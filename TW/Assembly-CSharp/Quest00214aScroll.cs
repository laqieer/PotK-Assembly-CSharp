// Decompiled with JetBrains decompiler
// Type: Quest00214aScroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00214aScroll : MonoBehaviour
{
  public UILabel label;
  public GameObject charcter;

  [DebuggerHidden]
  public IEnumerator Init(GameObject iconPreafab, QuestDisplayConditionConverter data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214aScroll.\u003CInit\u003Ec__Iterator1FE()
    {
      data = data,
      iconPreafab = iconPreafab,
      \u003C\u0024\u003Edata = data,
      \u003C\u0024\u003EiconPreafab = iconPreafab,
      \u003C\u003Ef__this = this
    };
  }
}
