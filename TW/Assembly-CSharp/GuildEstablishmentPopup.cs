// Decompiled with JetBrains decompiler
// Type: GuildEstablishmentPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class GuildEstablishmentPopup : MonoBehaviour
{
  private const float animNormalSpeed = 1f;
  private const float animSkipSpeed = 162f;
  [SerializeField]
  private Animator anim;

  public void Skip() => this.anim.speed = 162f;

  public void Stop() => this.anim.speed = 1f;

  public void ChangeScene()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    Guild0281Scene.ChangeSceneGuildTop(true);
  }

  public void PlaySound(string clip) => Singleton<NGSoundManager>.GetInstance().PlaySe(clip);
}
