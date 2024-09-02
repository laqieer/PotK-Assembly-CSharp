// Decompiled with JetBrains decompiler
// Type: NGLongTap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

[RequireComponent(typeof (UIEventTrigger))]
public class NGLongTap : MonoBehaviour
{
  public float LongTapSeconds = 3f;
  public MonoBehaviour Target;
  public string MethodName = string.Empty;

  private void Start()
  {
    this.GetComponent<UIEventTrigger>().onPress.Add(new EventDelegate(new EventDelegate.Callback(this.tapStart)));
    this.GetComponent<UIEventTrigger>().onRelease.Add(new EventDelegate(new EventDelegate.Callback(this.tapEnd)));
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

  private IEnumerator checkLongTap()
  {
    yield return (object) new WaitForSeconds(this.LongTapSeconds);
    if ((Object) this.Target == (Object) null)
      Debug.Log((object) "no set long tap Target");
    else if (this.MethodName == string.Empty)
      Debug.Log((object) "no set long tap MethodName");
    else
      this.Target.SendMessage(this.MethodName);
  }
}
