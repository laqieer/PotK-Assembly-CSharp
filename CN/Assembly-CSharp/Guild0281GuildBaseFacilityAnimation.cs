// Decompiled with JetBrains decompiler
// Type: Guild0281GuildBaseFacilityAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using UnityEngine;

#nullable disable
public class Guild0281GuildBaseFacilityAnimation : MonoBehaviour
{
  [SerializeField]
  private GameObject dir_guild_l_tower;
  [SerializeField]
  private UI2DSprite tower;
  [SerializeField]
  private GameObject dir_guild_wall;
  [SerializeField]
  private UI2DSprite wall;
  [SerializeField]
  private GameObject dir_guild_s_tower;
  [SerializeField]
  private UI2DSprite scaffold;
  [SerializeField]
  private Animator animator;

  public void Initialize(GuildBaseType type, GuildImageCache guildImageCache)
  {
    GameObject gameObject = (GameObject) null;
    UI2DSprite ui2Dsprite = (UI2DSprite) null;
    int level = 0;
    switch (type)
    {
      case GuildBaseType.walls:
        gameObject = this.dir_guild_wall;
        ui2Dsprite = this.wall;
        level = PlayerAffiliation.Current.guild.appearance.walls_rank;
        break;
      case GuildBaseType.tower:
        gameObject = this.dir_guild_l_tower;
        ui2Dsprite = this.tower;
        level = PlayerAffiliation.Current.guild.appearance.tower_rank;
        break;
      case GuildBaseType.scaffold:
        gameObject = this.dir_guild_s_tower;
        ui2Dsprite = this.scaffold;
        level = PlayerAffiliation.Current.guild.appearance.scaffold_rank;
        break;
    }
    GuildImagePattern guildImagePattern = GuildImagePattern.Find(type, level);
    if (guildImagePattern == null)
      return;
    Sprite facilitySprite = guildImageCache.GetFacilitySprite(type);
    if (!Object.op_Inequality((Object) facilitySprite, (Object) null))
      return;
    ((Component) ui2Dsprite).GetComponent<UI2DSprite>().SetDimensions(((Texture) facilitySprite.texture).width, ((Texture) facilitySprite.texture).height);
    ((Component) ui2Dsprite).GetComponent<UI2DSprite>().sprite2D = facilitySprite;
    gameObject.transform.localPosition = new Vector3(guildImagePattern.baseXpos, guildImagePattern.baseYpos);
    this.SetAnimation(((Component) ui2Dsprite).gameObject, guildImagePattern.anim1PrefixSprite, guildImagePattern.anim1frame, guildImagePattern.anim1Xpos, guildImagePattern.anim1Ypos, 1, guildImageCache);
    this.SetAnimation(((Component) ui2Dsprite).gameObject, guildImagePattern.anim2PrefixSprite, guildImagePattern.anim2frame, guildImagePattern.anim2Xpos, guildImagePattern.anim2Ypos, 2, guildImageCache);
    this.SetAnimation(((Component) ui2Dsprite).gameObject, guildImagePattern.anim3PrefixSprite, guildImagePattern.anim3frame, guildImagePattern.anim3Xpos, guildImagePattern.anim3Ypos, 3, guildImageCache);
    this.SetAnimation(((Component) ui2Dsprite).gameObject, guildImagePattern.anim4PrefixSprite, guildImagePattern.anim4frame, guildImagePattern.anim4Xpos, guildImagePattern.anim4Ypos, 4, guildImageCache);
  }

  public void LevelUp(GuildBaseType type)
  {
    switch (type)
    {
      case GuildBaseType.walls:
        this.animator.SetTrigger("wall");
        break;
      case GuildBaseType.tower:
        this.animator.SetTrigger("tower");
        break;
      case GuildBaseType.scaffold:
        this.animator.SetTrigger("scaffold");
        break;
    }
  }

  public void PlaySound(string clip) => Singleton<NGSoundManager>.GetInstance().PlaySe(clip);

  private void SetAnimation(
    GameObject target,
    string prefix,
    int frame,
    float x,
    float y,
    int addDepth,
    GuildImageCache guildImageCache)
  {
    if (prefix == string.Empty)
      return;
    GameObject gameObject = guildImageCache.guildFrameAnim.Clone(target.transform);
    UISpriteAnimation component1 = gameObject.GetComponent<UISpriteAnimation>();
    if (Object.op_Equality((Object) component1, (Object) null))
      return;
    component1.namePrefix = prefix;
    component1.framesPerSecond = frame;
    component1.Reset();
    gameObject.transform.localPosition = new Vector3(x, y);
    UIWidget component2 = target.GetComponent<UIWidget>();
    if (!Object.op_Inequality((Object) component2, (Object) null))
      return;
    gameObject.GetComponent<UIWidget>().depth = component2.depth + addDepth;
  }
}
