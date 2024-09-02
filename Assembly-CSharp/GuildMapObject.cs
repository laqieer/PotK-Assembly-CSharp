// Decompiled with JetBrains decompiler
// Type: GuildMapObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class GuildMapObject : BackButtonMenuBase
{
  [SerializeField]
  private bool isInitialize;
  private bool overlapControl;
  private UITweener[] tweens;
  private float tweensTime;

  public bool IsInitialize
  {
    get => this.isInitialize;
    set => this.isInitialize = value;
  }

  public IEnumerator StartUp()
  {
    GuildMapObject guildMapObject = this;
    guildMapObject.isInitialize = false;
    guildMapObject.transform.localPosition = new Vector3(999f, 999f, 0.0f);
    if (guildMapObject.tweens == null)
    {
      guildMapObject.tweens = NGTween.findTweeners(guildMapObject.gameObject, true);
      float num1 = 0.0f;
      foreach (UITweener tween in guildMapObject.tweens)
      {
        if (tween.style != UITweener.Style.Loop)
        {
          float num2 = tween.delay + tween.duration;
          num1 = (double) num2 > (double) num1 ? num2 : num1;
        }
      }
      guildMapObject.tweensTime = num1;
    }
    guildMapObject.overlapControl = true;
    guildMapObject.PlayTween(false);
    yield return (object) new WaitForSeconds(guildMapObject.tweensTime);
    if ((UnityEngine.Object) guildMapObject.transform != (UnityEngine.Object) null)
      guildMapObject.transform.localPosition = Vector3.zero;
    guildMapObject.isInitialize = true;
  }

  public override void onBackButton() => this.backScene();

  public void SetActive(bool flag)
  {
    if (!((UnityEngine.Object) this.gameObject != (UnityEngine.Object) null))
      return;
    this.gameObject.SetActive(flag);
  }

  public bool PlayTween(bool flag)
  {
    if (this.tweens == null || this.overlapControl == flag)
      return false;
    this.overlapControl = flag;
    if (flag)
    {
      this.SetActive(flag);
      ((IEnumerable<UITweener>) this.tweens).Where<UITweener>((Func<UITweener, bool>) (x => x.tweenGroup == 13)).ForEach<UITweener>((System.Action<UITweener>) (x => x.enabled = false));
      NGTween.playTweens(this.tweens, NGTween.Kind.START);
    }
    else if (this.gameObject.activeSelf)
    {
      this.StartCoroutine(this.DelaySetActive(flag, this.tweensTime));
      ((IEnumerable<UITweener>) this.tweens).Where<UITweener>((Func<UITweener, bool>) (x => x.tweenGroup == 12)).ForEach<UITweener>((System.Action<UITweener>) (x => x.enabled = false));
      NGTween.playTweens(this.tweens, NGTween.Kind.END);
    }
    return true;
  }

  private IEnumerator DelaySetActive(bool flag, float time)
  {
    while (flag == this.overlapControl)
    {
      if ((double) time >= 0.0)
      {
        time -= Time.deltaTime;
        yield return (object) true;
      }
      else
      {
        this.SetActive(flag);
        break;
      }
    }
  }
}
