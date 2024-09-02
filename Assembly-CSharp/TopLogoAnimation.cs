// Decompiled with JetBrains decompiler
// Type: TopLogoAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TopLogoAnimation : MonoBehaviour
{
  [SerializeField]
  private Animator backGroundAnim;
  [SerializeField]
  private Animator btnAnim;
  private System.Action finishCallback;

  public void Init()
  {
  }

  public void Finish(System.Action finishCallback_) => this.finishCallback = finishCallback_;

  public void Fade()
  {
  }

  public void SceneChange()
  {
  }
}
