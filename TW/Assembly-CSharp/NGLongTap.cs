// Decompiled with JetBrains decompiler
// Type: NGLongTap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
[RequireComponent(typeof (UIEventTrigger))]
public class NGLongTap : MonoBehaviour
{
  public float LongTapSeconds = 3f;
  public MonoBehaviour Target;
  public string MethodName = string.Empty;

  private void Start()
  {
    ((Component) this).GetComponent<UIEventTrigger>().onPress.Add(new EventDelegate(new EventDelegate.Callback(this.tapStart)));
    ((Component) this).GetComponent<UIEventTrigger>().onRelease.Add(new EventDelegate(new EventDelegate.Callback(this.tapEnd)));
  }

  private void tapStart()
  {
    Debug.Log((object) "tap start");
    this.StartCoroutine("checkLongTap");
  }

  private void tapEnd()
  {
    Debug.Log((object) "tap end");
    this.StopCoroutine("checkLongTap");
  }

  [DebuggerHidden]
  private IEnumerator checkLongTap()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGLongTap.\u003CcheckLongTap\u003Ec__IteratorB55()
    {
      \u003C\u003Ef__this = this
    };
  }
}
