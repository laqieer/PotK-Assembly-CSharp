// Decompiled with JetBrains decompiler
// Type: GuildImageCache
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildImageCache
{
  private UnityEngine.Sprite fortress;
  private UnityEngine.Sprite walls;
  private UnityEngine.Sprite scaffold;
  private UnityEngine.Sprite tower;
  public GameObject guildFrameAnim;

  public List<UnityEngine.Sprite> GuildBankLevelupFotressSpriteList { get; set; }

  public static UnityEngine.Sprite AlphaSprite()
  {
    SpriteMeshType meshType = SpriteMeshType.FullRect;
    uint num = 1;
    uint extrude = 100;
    Texture2D texture = Resources.Load<Texture2D>("Sprites/1x1_alpha0");
    UnityEngine.Sprite sprite = UnityEngine.Sprite.Create(texture, new Rect(0.0f, 0.0f, (float) texture.width, (float) texture.height), new Vector2(0.5f, 0.5f), (float) num, extrude, meshType);
    sprite.name = texture.name;
    return sprite;
  }

  public IEnumerator FacilitiResourceLoad(GuildAppearance guildData)
  {
    UnityEngine.Sprite alpha = GuildImageCache.AlphaSprite();
    IEnumerator e = this.SetSprite(GuildBaseType.scaffold, guildData.scaffold_rank, alpha);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = this.SetSprite(GuildBaseType.tower, guildData.tower_rank, alpha);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = this.SetSprite(GuildBaseType.walls, guildData.walls_rank, alpha);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public IEnumerator GuildBankLevelUpResourceLoad(int levelUpCount)
  {
    GuildRegistration guildData = PlayerAffiliation.Current.guild;
    UnityEngine.Sprite alpha = GuildImageCache.AlphaSprite();
    if (this.GuildBankLevelupFotressSpriteList == null)
      this.GuildBankLevelupFotressSpriteList = new List<UnityEngine.Sprite>();
    this.GuildBankLevelupFotressSpriteList.Clear();
    IEnumerator e;
    for (int i = guildData.appearance.level - levelUpCount; i <= guildData.appearance.level; ++i)
    {
      GuildImagePattern guildImagePattern = GuildImagePattern.Find(GuildBaseType.fortress, i);
      if (guildImagePattern == null)
      {
        this.GuildBankLevelupFotressSpriteList.Add(alpha);
      }
      else
      {
        Future<UnityEngine.Sprite> sprite = guildImagePattern.LoadSpriteFortress();
        if (sprite == null)
        {
          this.GuildBankLevelupFotressSpriteList.Add(alpha);
        }
        else
        {
          e = sprite.Wait();
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
          this.GuildBankLevelupFotressSpriteList.Add(sprite.Result);
        }
        sprite = (Future<UnityEngine.Sprite>) null;
      }
    }
    e = this.FacilitiResourceLoad(guildData.appearance);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = this.GuildFrameAnimResourceLoad();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public IEnumerator ResourceLoad(GuildAppearance guildData)
  {
    UnityEngine.Sprite alpha = GuildImageCache.AlphaSprite();
    IEnumerator e = this.SetSprite(GuildBaseType.fortress, guildData.level, alpha);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = this.FacilitiResourceLoad(guildData);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = this.GuildFrameAnimResourceLoad();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public IEnumerator GuildFrameAnimResourceLoad()
  {
    if ((Object) this.guildFrameAnim == (Object) null)
    {
      Future<GameObject> f = Res.Prefabs.guild028_2.guild_frame_anim.Load<GameObject>();
      IEnumerator e = f.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.guildFrameAnim = f.Result;
      f = (Future<GameObject>) null;
    }
  }

  private IEnumerator SetSprite(GuildBaseType type, int rank, UnityEngine.Sprite alpha)
  {
    GuildImagePattern guildImagePattern = GuildImagePattern.Find(type, rank);
    if (guildImagePattern == null)
    {
      this.SetFacilitySprite(type, alpha);
    }
    else
    {
      Future<UnityEngine.Sprite> sprite = guildImagePattern.LoadSpriteFacility(type);
      if (sprite == null)
      {
        this.SetFacilitySprite(type, alpha);
      }
      else
      {
        IEnumerator e = sprite.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        this.SetFacilitySprite(type, sprite.Result);
      }
      sprite = (Future<UnityEngine.Sprite>) null;
    }
  }

  private void SetFacilitySprite(GuildBaseType type, UnityEngine.Sprite sprite)
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

  public UnityEngine.Sprite GetFacilitySprite(GuildBaseType type)
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
        return (UnityEngine.Sprite) null;
    }
  }
}
