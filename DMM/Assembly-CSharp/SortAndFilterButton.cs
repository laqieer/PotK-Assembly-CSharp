// Decompiled with JetBrains decompiler
// Type: SortAndFilterButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

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
    this.button = this.GetComponent<UIButton>();
    if ((Object) this.sprite == (Object) null)
      this.sprite = this.GetComponent<UISprite>();
    this.sprite2d = this.GetComponent<UI2DSprite>();
    this.tweens = this.GetComponents<TweenColor>();
  }

  public void SpriteColorGray(bool flag)
  {
    if (this.tweens != null)
    {
      foreach (Behaviour tween in this.tweens)
        tween.enabled = false;
    }
    Color color = Color.gray;
    if (flag)
      color = Color.white;
    if ((Object) this.button != (Object) null)
    {
      this.button.defaultColor = color;
      this.button.hover = color;
      this.button.pressed = color;
    }
    if ((Object) this.sprite != (Object) null)
      this.sprite.color = color;
    if (!((Object) this.sprite2d != (Object) null))
      return;
    this.sprite2d.color = color;
  }

  public virtual void PressButton()
  {
  }
}
