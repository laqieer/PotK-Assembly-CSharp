// Decompiled with JetBrains decompiler
// Type: Guild0282MemberBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Guild0282MemberBase : MonoBehaviour
{
  [SerializeField]
  private bool isEnemy;
  [SerializeField]
  private List<GameObject> effectLevelList;
  private GuildMembership member;
  private Guild0282Menu menu;
  [SerializeField]
  private MemberBaseItem memberBaseItem;
  [SerializeField]
  private GameObject townAnimObj;
  private List<GameObject> townAnimObjList;
  private GuildImageCache guildImageCache;

  public bool IsEnemy => this.isEnemy;

  public GuildMembership Member => this.member;

  public void Initialize(
    GuildMembership memberData,
    Guild0282Menu guild0282menu,
    GuildImageCache imageCache,
    bool enemy = false)
  {
    this.member = memberData;
    this.menu = guild0282menu;
    this.isEnemy = enemy;
    this.memberBaseItem.SetActive(true);
    this.memberBaseItem.Initialize(this.IsEnemy, memberData);
    this.SetSprite(memberData, imageCache);
  }

  public void Focus() => this.menu.onButtonMemberBase(this, this.member);

  public void SetSprite(GuildMembership memberData, GuildImageCache imageCache)
  {
    this.guildImageCache = imageCache;
    this.townAnimObjList = this.ClearAnimation(this.townAnimObjList);
    this.SetPattern(1, GuildBaseType.town, this.townAnimObj, this.townAnimObjList);
  }

  private void SetPattern(
    int level,
    GuildBaseType type,
    GameObject target,
    List<GameObject> animList)
  {
    GuildImagePattern guildImagePattern = GuildImagePattern.Find(type, level);
    target.GetComponent<UISprite>().SetSprite(guildImagePattern.TownSpriteName());
    target.transform.localPosition = new Vector3(guildImagePattern.baseXpos, guildImagePattern.baseYpos);
    this.SetAnimation(target, animList, guildImagePattern.anim1PrefixSprite, guildImagePattern.anim1frame, guildImagePattern.anim1Xpos, guildImagePattern.anim1Ypos, 1);
    this.SetAnimation(target, animList, guildImagePattern.anim2PrefixSprite, guildImagePattern.anim2frame, guildImagePattern.anim2Xpos, guildImagePattern.anim2Ypos, 2);
    this.SetAnimation(target, animList, guildImagePattern.anim3PrefixSprite, guildImagePattern.anim3frame, guildImagePattern.anim3Xpos, guildImagePattern.anim3Ypos, 3);
    this.SetAnimation(target, animList, guildImagePattern.anim4PrefixSprite, guildImagePattern.anim4frame, guildImagePattern.anim4Xpos, guildImagePattern.anim4Ypos, 4);
  }

  private void OnPress(bool isDown) => this.menu.OnPress(isDown);

  private void OnDrag(Vector2 delta) => this.menu.OnDrag(delta);

  private List<GameObject> ClearAnimation(List<GameObject> objList)
  {
    if (objList == null)
      objList = new List<GameObject>();
    if (objList.Count > 0)
    {
      objList.ForEach((Action<GameObject>) (x => Object.Destroy((Object) x)));
      objList.Clear();
    }
    return objList;
  }

  private void SetAnimation(
    GameObject target,
    List<GameObject> objList,
    string prefix,
    int frame,
    float x,
    float y,
    int addDepth)
  {
    if (prefix == string.Empty)
      return;
    GameObject gameObject = this.guildImageCache.guildFrameAnim.Clone(target.transform);
    objList.Add(gameObject);
    UISpriteAnimation component1 = gameObject.GetComponent<UISpriteAnimation>();
    if (Object.op_Equality((Object) component1, (Object) null))
      return;
    if (this.IsEnemy)
      prefix = prefix.Replace("own", "enemy");
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
