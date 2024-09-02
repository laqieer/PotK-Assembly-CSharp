// Decompiled with JetBrains decompiler
// Type: SortAndFilterButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SortAndFilterButton : MonoBehaviour
{
  private UIButton button;
  [SerializeField]
  private UISprite sprite;
  private UI2DSprite sprite2d;
  private TweenColor[] tweens;

  public UIButton Button => this.button;

  public UISprite Sprite => this.sprite;

  protected virtual void Awake()
  {
    this.button = ((Component) this).GetComponent<UIButton>();
    if (Object.op_Equality((Object) this.sprite, (Object) null))
      this.sprite = ((Component) this).GetComponent<UISprite>();
    this.sprite2d = ((Component) this).GetComponent<UI2DSprite>();
    this.tweens = ((Component) this).GetComponents<TweenColor>();
  }

  public void SpriteColorGray(bool flag)
  {
    foreach (Behaviour tween in this.tweens)
      tween.enabled = false;
    Color color = PunkColor.button_off;
    if (flag)
      color = PunkColor.button_on;
    this.button.defaultColor = color;
    if (Object.op_Inequality((Object) this.sprite, (Object) null))
      this.sprite.color = color;
    if (!Object.op_Inequality((Object) this.sprite2d, (Object) null))
      return;
    this.sprite2d.color = color;
  }

  public virtual void PressButton()
  {
  }
}
