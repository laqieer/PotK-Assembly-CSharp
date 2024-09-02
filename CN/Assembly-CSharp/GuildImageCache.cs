// Decompiled with JetBrains decompiler
// Type: GuildImageCache
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildImageCache
{
  private Sprite fortress;
  private Sprite walls;
  private Sprite scaffold;
  private Sprite tower;
  public GameObject guildFrameAnim;

  public List<Sprite> GuildBankLevelupFotressSpriteList { get; set; }

  public static Sprite AlphaSprite()
  {
    SpriteMeshType spriteMeshType = (SpriteMeshType) 0;
    uint num1 = 1;
    uint num2 = 100;
    Texture2D texture2D = Resources.Load<Texture2D>("Sprites/1x1_alpha0");
    Sprite sprite = Sprite.Create(texture2D, new Rect(0.0f, 0.0f, (float) ((Texture) texture2D).width, (float) ((Texture) texture2D).height), new Vector2(0.5f, 0.5f), (float) num1, num2, spriteMeshType);
    ((Object) sprite).name = ((Object) texture2D).name;
    return sprite;
  }

  [DebuggerHidden]
  public IEnumerator FacilitiResourceLoad(GuildAppearance guildData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildImageCache.\u003CFacilitiResourceLoad\u003Ec__IteratorAA0()
    {
      guildData = guildData,
      \u003C\u0024\u003EguildData = guildData,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator GuildBankLevelUpResourceLoad(int levelUpCount)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildImageCache.\u003CGuildBankLevelUpResourceLoad\u003Ec__IteratorAA1()
    {
      levelUpCount = levelUpCount,
      \u003C\u0024\u003ElevelUpCount = levelUpCount,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator ResourceLoad(GuildAppearance guildData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildImageCache.\u003CResourceLoad\u003Ec__IteratorAA2()
    {
      guildData = guildData,
      \u003C\u0024\u003EguildData = guildData,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator GuildFrameAnimResourceLoad()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildImageCache.\u003CGuildFrameAnimResourceLoad\u003Ec__IteratorAA3()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetSprite(GuildBaseType type, int rank, Sprite alpha)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildImageCache.\u003CSetSprite\u003Ec__IteratorAA4()
    {
      type = type,
      rank = rank,
      alpha = alpha,
      \u003C\u0024\u003Etype = type,
      \u003C\u0024\u003Erank = rank,
      \u003C\u0024\u003Ealpha = alpha,
      \u003C\u003Ef__this = this
    };
  }

  private void SetFacilitySprite(GuildBaseType type, Sprite sprite)
  {
    switch (type)
    {
      case GuildBaseType.walls:
        this.walls = sprite;
        break;
      case GuildBaseType.tower:
        this.tower = sprite;
        break;
      case GuildBaseType.scaffold:
        this.scaffold = sprite;
        break;
      case GuildBaseType.fortress:
        this.fortress = sprite;
        break;
    }
  }

  public Sprite GetFacilitySprite(GuildBaseType type)
  {
    switch (type)
    {
      case GuildBaseType.walls:
        return this.walls;
      case GuildBaseType.tower:
        return this.tower;
      case GuildBaseType.scaffold:
        return this.scaffold;
      case GuildBaseType.fortress:
        return this.fortress;
      default:
        return (Sprite) null;
    }
  }
}
