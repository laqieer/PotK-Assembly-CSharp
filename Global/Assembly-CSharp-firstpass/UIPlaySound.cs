// Decompiled with JetBrains decompiler
// Type: UIPlaySound
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Play Sound")]
public class UIPlaySound : MonoBehaviour
{
  public AudioClip audioClip;
  public UIPlaySound.Trigger trigger;
  private bool mIsOver;
  [Range(0.0f, 1f)]
  public float volume = 1f;
  [Range(0.0f, 2f)]
  public float pitch = 1f;

  private void OnHover(bool isOver)
  {
    if (this.trigger == UIPlaySound.Trigger.OnMouseOver)
    {
      if (this.mIsOver == isOver)
        return;
      this.mIsOver = isOver;
    }
    if (!((Behaviour) this).enabled || (!isOver || this.trigger != UIPlaySound.Trigger.OnMouseOver) && (isOver || this.trigger != UIPlaySound.Trigger.OnMouseOut))
      return;
    NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
  }

  private void OnPress(bool isPressed)
  {
    if (this.trigger == UIPlaySound.Trigger.OnPress)
    {
      if (this.mIsOver == isPressed)
        return;
      this.mIsOver = isPressed;
    }
    if (!((Behaviour) this).enabled || (!isPressed || this.trigger != UIPlaySound.Trigger.OnPress) && (isPressed || this.trigger != UIPlaySound.Trigger.OnRelease))
      return;
    NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
  }

  private void OnClick()
  {
    if (!((Behaviour) this).enabled || this.trigger != UIPlaySound.Trigger.OnClick)
      return;
    NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
  }

  private void OnSelect(bool isSelected)
  {
    if (!((Behaviour) this).enabled || isSelected && UICamera.currentScheme != UICamera.ControlScheme.Controller)
      return;
    this.OnHover(isSelected);
  }

  public void Play() => NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);

  public enum Trigger
  {
    OnClick,
    OnMouseOver,
    OnMouseOut,
    OnPress,
    OnRelease,
    Custom,
  }
}
