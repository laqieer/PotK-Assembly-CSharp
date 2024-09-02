// Decompiled with JetBrains decompiler
// Type: TopPressBtnAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class TopPressBtnAnimation : MonoBehaviour
{
  [SerializeField]
  private Animator anim;
  private TopSceneEN topScene;

  public void Init(TopSceneEN scene)
  {
    this.topScene = scene;
    this.anim.Play("TOP_PressStart");
  }

  public void StartAnimFinish()
  {
    if (!Object.op_Inequality((Object) this.topScene, (Object) null))
      return;
    this.topScene.EnablePressStartBtn = true;
  }
}
