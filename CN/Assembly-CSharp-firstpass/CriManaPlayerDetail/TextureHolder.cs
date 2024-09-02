// Decompiled with JetBrains decompiler
// Type: CriManaPlayerDetail.TextureHolder
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System.Collections;
using UnityEngine;

#nullable disable
namespace CriManaPlayerDetail
{
  public abstract class TextureHolder
  {
    public readonly int width;
    public readonly int height;
    public readonly bool isAlphaMode;
    private float offsetTexels;
    protected readonly uint texNumber;
    protected uint texIndex;

    protected TextureHolder(
      int argWidth,
      int argHeight,
      uint argTexNumber,
      bool alphaMode,
      float argOffsetTexels)
    {
      this.width = TextureHolder.next_pot_size(TextureHolder.ceiling64(argWidth));
      this.height = TextureHolder.next_pot_size(TextureHolder.ceiling16(argHeight));
      this.texNumber = argTexNumber;
      this.isAlphaMode = alphaMode;
      this.offsetTexels = argOffsetTexels;
    }

    public bool IsAvailable(int argWidth, int argHeight, uint argTexNumber, bool alphaMode)
    {
      return this.width >= argWidth && this.height >= argHeight && (int) this.texNumber == (int) argTexNumber && this.isAlphaMode == alphaMode;
    }

    public void SetTextureConfig(
      Material material,
      int argWidth,
      int argHeight,
      bool flipTopBottom,
      bool flipLeftRight)
    {
      float num1 = this.offsetTexels / (float) this.width;
      float num2 = this.offsetTexels / (float) this.height;
      float num3 = (float) argWidth / (float) this.width;
      float num4 = (float) argHeight / (float) this.height;
      float num5;
      float num6;
      if (flipLeftRight)
      {
        num5 = num3 - num1;
        num6 = -num3 + num1;
      }
      else
      {
        num5 = 0.0f;
        num6 = num3 - num1;
      }
      float num7;
      float num8;
      if (flipTopBottom)
      {
        num7 = 0.0f;
        num8 = num4 - num2;
      }
      else
      {
        num7 = num4 - num2;
        num8 = -num4 + num2;
      }
      material.mainTextureScale = new Vector2(num6, num8);
      material.mainTextureOffset = new Vector2(num5, num7);
    }

    public abstract IEnumerator CreateTexture();

    public abstract bool UpdateTexture(
      Material material,
      int playerId,
      CriManaPlayer.FrameInfo frameInfo);

    public abstract void DestroyTexture();

    private static uint next_pot_size(uint x)
    {
      --x;
      x |= x >> 1;
      x |= x >> 2;
      x |= x >> 4;
      x |= x >> 8;
      x |= x >> 16;
      return x + 1U;
    }

    private static int next_pot_size(int x) => (int) TextureHolder.next_pot_size((uint) x);

    private static int ceiling8(int x) => x + 7 & -8;

    private static int ceiling16(int x) => x + 15 & -16;

    private static int ceiling64(int x) => x + 63 & -64;

    private static int ceiling256(int x) => x + (int) byte.MaxValue & -256;

    public static TextureHolder Create(
      int reservedWidth,
      int reservedHeight,
      uint texNumber,
      bool alphaMode)
    {
      return alphaMode ? (TextureHolder) new TextureHolderByTexPtrWithAlpha(reservedWidth, reservedHeight, texNumber, alphaMode) : (TextureHolder) new TextureHolderByTexPtr(reservedWidth, reservedHeight, texNumber, alphaMode);
    }
  }
}
