// Decompiled with JetBrains decompiler
// Type: Quest00219List
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
  public UISprite Clear;
  [SerializeField]
  public UISprite New;

  [DebuggerHidden]
  public IEnumerator Init(PlayerExtraQuestS extra, bool isClear, bool isNew)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00219List.\u003CInit\u003Ec__Iterator200()
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
