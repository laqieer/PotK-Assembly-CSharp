// Decompiled with JetBrains decompiler
// Type: DetailMenuScrollViewBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    DetailMenuScrollViewBase.\u003CsetModel\u003Ec__IteratorB08 modelCIteratorB08 = new DetailMenuScrollViewBase.\u003CsetModel\u003Ec__IteratorB08();
    return (IEnumerator) modelCIteratorB08;
  }

  [DebuggerHidden]
  public virtual IEnumerator initAsync(PlayerUnit playerUnit, GameObject[] prefabs = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    DetailMenuScrollViewBase.\u003CinitAsync\u003Ec__IteratorB09 asyncCIteratorB09 = new DetailMenuScrollViewBase.\u003CinitAsync\u003Ec__IteratorB09();
    return (IEnumerator) asyncCIteratorB09;
  }

  protected virtual void setText(UILabel label, int v) => label.SetTextLocalize(v);

  public virtual void EndScene()
  {
  }
}
