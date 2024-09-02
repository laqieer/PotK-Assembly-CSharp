// Decompiled with JetBrains decompiler
// Type: DetailMenuScrollViewBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DetailMenuScrollViewBase : MonoBehaviour
{
  public bool isEarthMode;

  public virtual bool Init(PlayerUnit playerUnit)
  {
    ((Component) this).gameObject.SetActive(true);
    return true;
  }

  [DebuggerHidden]
  public virtual IEnumerator setModel(
    PlayerUnit playerUnit,
    GameObject modelPrefab,
    Vector3 modelPos,
    bool light,
    System.Action action = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    DetailMenuScrollViewBase.\u003CsetModel\u003Ec__Iterator8B5 modelCIterator8B5 = new DetailMenuScrollViewBase.\u003CsetModel\u003Ec__Iterator8B5();
    return (IEnumerator) modelCIterator8B5;
  }

  [DebuggerHidden]
  public virtual IEnumerator initAsync(PlayerUnit playerUnit, GameObject[] prefabs = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    DetailMenuScrollViewBase.\u003CinitAsync\u003Ec__Iterator8B6 asyncCIterator8B6 = new DetailMenuScrollViewBase.\u003CinitAsync\u003Ec__Iterator8B6();
    return (IEnumerator) asyncCIterator8B6;
  }

  protected virtual void setText(UILabel label, int v) => label.SetTextLocalize(v);

  public virtual void EndScene()
  {
  }
}
