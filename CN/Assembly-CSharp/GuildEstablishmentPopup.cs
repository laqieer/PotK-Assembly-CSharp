// Decompiled with JetBrains decompiler
// Type: GuildEstablishmentPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
