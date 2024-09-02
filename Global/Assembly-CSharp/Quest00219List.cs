// Decompiled with JetBrains decompiler
// Type: Quest00219List
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00219List : MonoBehaviour
{
  [SerializeField]
  public UIButton Dock;
  [SerializeField]
  public UILabel Name;
  [SerializeField]
  public GameObject Clear;
  [SerializeField]
  public GameObject New;

  [DebuggerHidden]
  public IEnumerator Init(PlayerExtraQuestS extra, bool isClear, bool isNew)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00219List.\u003CInit\u003Ec__Iterator1C3()
    {
      isClear = isClear,
      isNew = isNew,
      extra = extra,
      \u003C\u0024\u003EisClear = isClear,
      \u003C\u0024\u003EisNew = isNew,
      \u003C\u0024\u003Eextra = extra,
      \u003C\u003Ef__this = this
    };
  }
}
