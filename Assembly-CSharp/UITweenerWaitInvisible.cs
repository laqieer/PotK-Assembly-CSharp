// Decompiled with JetBrains decompiler
// Type: UITweenerWaitInvisible
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class UITweenerWaitInvisible : MonoBehaviour
{
  private UITweener tween;
  private float time;

  private void Start()
  {
    this.tween = this.GetComponent<UITweener>();
    this.time = 0.0f;
  }

  private void Update()
  {
    if (!(bool) (Object) this.tween)
      return;
    this.time += Time.deltaTime;
    this.GetComponent<Renderer>().enabled = this.IsStarted();
  }

  private bool IsStarted() => (double) this.time > (double) this.tween.delay;
}
