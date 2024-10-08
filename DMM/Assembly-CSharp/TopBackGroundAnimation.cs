﻿// Decompiled with JetBrains decompiler
// Type: TopBackGroundAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TopBackGroundAnimation : MonoBehaviour
{
  [SerializeField]
  private Animator anim;
  private System.Action finishCallback;

  public void Init()
  {
  }

  public void StartFinishAnim(System.Action finishCallback_)
  {
    this.finishCallback = finishCallback_;
    this.anim.StopPlayback();
    this.anim.SetInteger("Start_Fade_anim", 1);
  }

  public void Finish()
  {
    if (this.finishCallback == null)
      return;
    this.finishCallback();
  }
}
