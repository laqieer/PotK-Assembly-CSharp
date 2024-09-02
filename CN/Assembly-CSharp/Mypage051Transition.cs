// Decompiled with JetBrains decompiler
// Type: Mypage051Transition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    Singleton<CommonRoot>.GetInstance().isTouchBlock = true;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.playSE("SE_1039");
    this.StartCoroutine(this.menu.CloudAnimationStart());
  }

  public void onEventQuest()
  {
    if (this.menu.IsPushAndSet())
      return;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.playSE("SE_1002");
    Quest052171Scene.ChangeScene(true);
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
