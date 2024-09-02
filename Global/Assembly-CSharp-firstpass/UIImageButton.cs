// Decompiled with JetBrains decompiler
// Type: UIImageButton
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/UI/Image Button")]
public class UIImageButton : MonoBehaviour
{
  public UISprite target;
  public string normalSprite;
  public string hoverSprite;
  public string pressedSprite;
  public string disabledSprite;
  public bool pixelSnap = true;

  public bool isEnabled
  {
    get
    {
      Collider component = ((Component) this).GetComponent<Collider>();
      return Object.op_Implicit((Object) component) && component.enabled;
    }
    set
    {
      Collider component = ((Component) this).GetComponent<Collider>();
      if (!Object.op_Implicit((Object) component) || component.enabled == value)
        return;
      component.enabled = value;
      this.UpdateImage();
    }
  }

  private void OnEnable()
  {
    if (Object.op_Equality((Object) this.target, (Object) null))
      this.target = ((Component) this).GetComponentInChildren<UISprite>();
    this.UpdateImage();
  }

  private void OnValidate()
  {
    if (!Object.op_Inequality((Object) this.target, (Object) null))
      return;
    if (string.IsNullOrEmpty(this.normalSprite))
      this.normalSprite = this.target.spriteName;
    if (string.IsNullOrEmpty(this.hoverSprite))
      this.hoverSprite = this.target.spriteName;
    if (string.IsNullOrEmpty(this.pressedSprite))
      this.pressedSprite = this.target.spriteName;
    if (!string.IsNullOrEmpty(this.disabledSprite))
      return;
    this.disabledSprite = this.target.spriteName;
  }

  private void UpdateImage()
  {
    if (!Object.op_Inequality((Object) this.target, (Object) null))
      return;
    if (this.isEnabled)
      this.SetSprite(!UICamera.IsHighlighted(((Component) this).gameObject) ? this.normalSprite : this.hoverSprite);
    else
      this.SetSprite(this.disabledSprite);
  }

  private void OnHover(bool isOver)
  {
    if (!this.isEnabled || !Object.op_Inequality((Object) this.target, (Object) null))
      return;
    this.SetSprite(!isOver ? this.normalSprite : this.hoverSprite);
  }

  private void OnPress(bool pressed)
  {
    if (pressed)
      this.SetSprite(this.pressedSprite);
    else
      this.UpdateImage();
  }

  private void SetSprite(string sprite)
  {
    if (Object.op_Equality((Object) this.target.atlas, (Object) null) || this.target.atlas.GetSprite(sprite) == null)
      return;
    this.target.spriteName = sprite;
    if (!this.pixelSnap)
      return;
    this.target.MakePixelPerfect();
  }
}
