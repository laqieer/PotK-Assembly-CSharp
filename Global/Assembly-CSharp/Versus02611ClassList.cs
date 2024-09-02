// Decompiled with JetBrains decompiler
// Type: Versus02611ClassList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus02611ClassList : MonoBehaviour
{
  [SerializeField]
  private GameObject unlockClass;
  [SerializeField]
  private GameObject currentClass;
  [SerializeField]
  private GameObject lockClass;
  [SerializeField]
  private UILabel txtName;
  private int id;
  private int best_class;

  [DebuggerHidden]
  public IEnumerator Init(int id, string name, int current_id, bool isLock, int best_class)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02611ClassList.\u003CInit\u003Ec__Iterator578()
    {
      id = id,
      best_class = best_class,
      current_id = current_id,
      name = name,
      isLock = isLock,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Ebest_class = best_class,
      \u003C\u0024\u003Ecurrent_id = current_id,
      \u003C\u0024\u003Ename = name,
      \u003C\u0024\u003EisLock = isLock,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnChangeScene() => Versus02612Scene.ChangeScene(true, this.id, this.best_class);
}
