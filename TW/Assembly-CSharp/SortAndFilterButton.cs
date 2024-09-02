// Decompiled with JetBrains decompiler
// Type: SortAndFilterButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    Color color = Color.gray;
    if (flag)
      color = Color.white;
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
