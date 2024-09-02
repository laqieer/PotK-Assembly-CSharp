// Decompiled with JetBrains decompiler
// Type: NGLongTap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new NGLongTap.\u003CcheckLongTap\u003Ec__IteratorA74()
    {
      \u003C\u003Ef__this = this
    };
  }
}
