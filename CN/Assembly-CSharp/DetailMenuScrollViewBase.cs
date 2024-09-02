// Decompiled with JetBrains decompiler
// Type: DetailMenuScrollViewBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    DetailMenuScrollViewBase.\u003CsetModel\u003Ec__IteratorA2D modelCIteratorA2D = new DetailMenuScrollViewBase.\u003CsetModel\u003Ec__IteratorA2D();
    return (IEnumerator) modelCIteratorA2D;
  }

  [DebuggerHidden]
  public virtual IEnumerator initAsync(PlayerUnit playerUnit, GameObject[] prefabs = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    DetailMenuScrollViewBase.\u003CinitAsync\u003Ec__IteratorA2E asyncCIteratorA2E = new DetailMenuScrollViewBase.\u003CinitAsync\u003Ec__IteratorA2E();
    return (IEnumerator) asyncCIteratorA2E;
  }

  protected virtual void setText(UILabel label, int v) => label.SetTextLocalize(v);

  public virtual void EndScene()
  {
  }
}
