// Decompiled with JetBrains decompiler
// Type: MyPageSubMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public abstract class MyPageSubMenu : MonoBehaviour
{
  protected MypageRootMenu RootMenu;
  protected NGSoundManager SoundMgr;

  public virtual void OnModeSwitch(MypageRootMenu.Mode mode)
  {
  }

  public virtual void OnModeSwitched(MypageRootMenu.Mode mode)
  {
  }

  protected new Coroutine StartCoroutine(IEnumerator e) => ((MonoBehaviour) this.RootMenu).StartCoroutine(e);
}
