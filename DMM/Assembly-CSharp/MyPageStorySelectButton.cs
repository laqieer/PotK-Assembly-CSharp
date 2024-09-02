// Decompiled with JetBrains decompiler
// Type: MyPageStorySelectButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MyPageStorySelectButton : MonoBehaviour
{
  [SerializeField]
  private UIButton button;
  [SerializeField]
  private UISprite sprite;
  private Color defaultSpriteColor;

  private void Start() => this.defaultSpriteColor = this.sprite.color;

  public void OnPress(bool isDown)
  {
    if (isDown)
      this.sprite.color = this.button.pressed;
    else
      this.sprite.color = this.defaultSpriteColor;
  }

  private void OnDragOut(GameObject draggedObject) => this.sprite.color = this.defaultSpriteColor;

  private void OnDragEnd() => this.sprite.color = this.defaultSpriteColor;
}
