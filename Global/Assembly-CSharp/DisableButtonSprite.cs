// Decompiled with JetBrains decompiler
// Type: DisableButtonSprite
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[RequireComponent(typeof (UIButton))]
public class DisableButtonSprite : MonoBehaviour
{
  public Color EnabledColor = new Color(0.5f, 0.5f, 0.5f);
  public Color DisabledColor = new Color(0.25f, 0.25f, 0.25f);
  private UIButton button;
  private UISprite[] sprites;
  private bool buttonEnabled;
  private bool initialized;

  private void Awake()
  {
    this.button = ((Component) this).gameObject.GetComponent<UIButton>();
    this.sprites = ((Component) this).gameObject.GetComponentsInChildren<UISprite>();
  }

  private void Update()
  {
    if (Object.op_Equality((Object) this.button, (Object) null) || this.initialized && this.button.isEnabled == this.buttonEnabled)
      return;
    this.buttonEnabled = this.button.isEnabled;
    this.initialized = true;
    foreach (UIWidget sprite in this.sprites)
      sprite.color = !this.buttonEnabled ? this.DisabledColor : this.EnabledColor;
  }
}
