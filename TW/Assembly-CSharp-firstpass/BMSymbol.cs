// Decompiled with JetBrains decompiler
// Type: BMSymbol
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public class BMSymbol
{
  public string sequence;
  public string spriteName;
  private UISpriteData mSprite;
  private bool mIsValid;
  private int mLength;
  private int mOffsetX;
  private int mOffsetY;
  private int mWidth;
  private int mHeight;
  private int mAdvance;
  private Rect mUV;

  public int length
  {
    get
    {
      if (this.mLength == 0)
        this.mLength = this.sequence.Length;
      return this.mLength;
    }
  }

  public int offsetX => this.mOffsetX;

  public int offsetY => this.mOffsetY;

  public int width => this.mWidth;

  public int height => this.mHeight;

  public int advance => this.mAdvance;

  public Rect uvRect => this.mUV;

  public void MarkAsChanged() => this.mIsValid = false;

  public bool Validate(UIAtlas atlas)
  {
    if (Object.op_Equality((Object) atlas, (Object) null))
      return false;
    if (!this.mIsValid)
    {
      if (string.IsNullOrEmpty(this.spriteName))
        return false;
      this.mSprite = !Object.op_Inequality((Object) atlas, (Object) null) ? (UISpriteData) null : atlas.GetSprite(this.spriteName);
      if (this.mSprite != null)
      {
        Texture texture = atlas.texture;
        if (Object.op_Equality((Object) texture, (Object) null))
        {
          this.mSprite = (UISpriteData) null;
        }
        else
        {
          this.mUV = new Rect((float) this.mSprite.x, (float) this.mSprite.y, (float) this.mSprite.width, (float) this.mSprite.height);
          this.mUV = NGUIMath.ConvertToTexCoords(this.mUV, texture.width, texture.height);
          this.mOffsetX = this.mSprite.paddingLeft;
          this.mOffsetY = this.mSprite.paddingTop;
          this.mWidth = this.mSprite.width;
          this.mHeight = this.mSprite.height;
          this.mAdvance = this.mSprite.width + (this.mSprite.paddingLeft + this.mSprite.paddingRight);
          this.mIsValid = true;
        }
      }
    }
    return this.mSprite != null;
  }
}
