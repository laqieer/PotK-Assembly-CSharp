// Decompiled with JetBrains decompiler
// Type: TopPressBtnAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class TopPressBtnAnimation : MonoBehaviour
{
  [SerializeField]
  private Animator anim;
  private TopScene topScene;

  public void Init(TopScene scene)
  {
    this.topScene = scene;
    this.anim.Play("TOP_PressStart");
  }

  public void StartAnimFinish()
  {
    if (!Object.op_Inequality((Object) this.topScene, (Object) null))
      ;
  }
}
