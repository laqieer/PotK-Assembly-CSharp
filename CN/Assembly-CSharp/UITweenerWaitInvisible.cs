// Decompiled with JetBrains decompiler
// Type: UITweenerWaitInvisible
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class UITweenerWaitInvisible : MonoBehaviour
{
  private UITweener tween;
  private float time;

  private void Start()
  {
    this.tween = ((Component) this).GetComponent<UITweener>();
    this.time = 0.0f;
  }

  private void Update()
  {
    if (!Object.op_Implicit((Object) this.tween))
      return;
    this.time += Time.deltaTime;
    ((Component) this).GetComponent<Renderer>().enabled = this.IsStarted();
  }

  private bool IsStarted() => (double) this.time > (double) this.tween.delay;
}
