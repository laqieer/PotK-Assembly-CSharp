// Decompiled with JetBrains decompiler
// Type: NGLongTap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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

  private void tapStart() => this.StartCoroutine("checkLongTap");

  private void tapEnd() => this.StopCoroutine("checkLongTap");

  [DebuggerHidden]
  private IEnumerator checkLongTap()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGLongTap.\u003CcheckLongTap\u003Ec__Iterator8E1()
    {
      \u003C\u003Ef__this = this
    };
  }
}
