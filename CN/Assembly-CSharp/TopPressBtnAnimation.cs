// Decompiled with JetBrains decompiler
// Type: TopPressBtnAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
