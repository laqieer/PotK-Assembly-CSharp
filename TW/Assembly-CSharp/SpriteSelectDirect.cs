// Decompiled with JetBrains decompiler
// Type: SpriteSelectDirect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[RequireComponent(typeof (UISprite))]
public class SpriteSelectDirect : MonoBehaviour
{
  [SerializeField]
  protected string spritePrefix;
  [SerializeField]
  protected string spriteExt;
  [SerializeField]
  private UISprite sprite;
  protected string spriteName = string.Empty;

  public virtual void SetSpriteName<T>(T n)
  {
    this.spriteName = string.Format(this.spritePrefix + "{0}" + this.spriteExt, (object) n);
    this.sprite.ChangeSprite(this.spriteName);
  }
}
