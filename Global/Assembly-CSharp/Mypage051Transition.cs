// Decompiled with JetBrains decompiler
// Type: Mypage051Transition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Mypage051Transition : MonoBehaviour
{
  [SerializeField]
  private Mypage051Menu menu;

  public void onHeavenly()
  {
    if (this.menu.IsPushAndSet())
      return;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.playSE("SE_1039");
    this.StartCoroutine(this.menu.CloudAnimationStart());
  }

  public void onQuest()
  {
    if (this.menu.IsPushAndSet())
      return;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.playSE("SE_1002");
    Quest0528Scene.changeScene(true);
  }

  public void onMenu()
  {
    if (this.menu.IsPushAndSet())
      return;
    Menu0591Scene.ChangeScene(true);
  }
}
