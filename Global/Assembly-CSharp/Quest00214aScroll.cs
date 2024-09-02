// Decompiled with JetBrains decompiler
// Type: Quest00214aScroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new Quest00214aScroll.\u003CInit\u003Ec__Iterator197()
    {
      data = data,
      iconPreafab = iconPreafab,
      \u003C\u0024\u003Edata = data,
      \u003C\u0024\u003EiconPreafab = iconPreafab,
      \u003C\u003Ef__this = this
    };
  }
}
