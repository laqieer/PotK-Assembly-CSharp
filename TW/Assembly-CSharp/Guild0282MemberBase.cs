// Decompiled with JetBrains decompiler
// Type: Guild0282MemberBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Guild0282MemberBase : MonoBehaviour
{
  private const int STAR_LOST_TWEEN = 281220;
  private const int LAMP_LOST_TWEEN = 281220;
  private const int situationMemberBaseDepth = 200;
  [SerializeField]
  private bool isEnemy;
  private GuildMembership member;
  private Guild0282Menu menu;
  [SerializeField]
  private MemberBaseItem memberBaseItem;
  [SerializeField]
  private GameObject townAnimObj;
  [SerializeField]
  private SpreadColorSprite townAnimSprite;
  private List<GameObject> townAnimObjList;
  private GuildImageCache guildImageCache;
  [SerializeField]
  private GameObject dir_lamp_base;
  [SerializeField]
  private GameObject dir_lamp_own;
  [SerializeField]
  private GameObject dir_lamp_enemy;
  [SerializeField]
  private List<GameObject> ownLampList;
  [SerializeField]
  private List<GameObject> enemyLampList;
  [SerializeField]
  private Animator dir_guild_battle_anim;
  [SerializeField]
  private GameObject dir_star;
  [SerializeField]
  private List<GameObject> dir_star_position;
  [SerializeField]
  private Animator DamageAnimator;
  [SerializeField]
  private GameObject whiteFlag;
  private bool endAnimation;
  public int nowstar;
  public int breakstar;
  private bool isInitializePlayrtSituation;

  public bool IsEnemy => this.isEnemy;

  public GuildMembership Member => this.member;

  public void PlayAnim(int nowStar, int breakStar)
  {
    this.endAnimation = false;
    this.SetStar(nowStar);
    this.BreakStarAnimation(nowStar, breakStar);
    this.StartCoroutine(this.DamageAnimation(nowStar, breakStar));
  }

  public void PlayAnim()
  {
    this.endAnimation = false;
    this.SetStar(this.nowstar);
    this.BreakStarAnimation(this.nowstar, this.breakstar);
    this.StartCoroutine(this.DamageAnimation(this.nowstar, this.breakstar));
  }

  private void BreakStarAnimation(int nowStar, int breakStar)
  {
    int index1 = 0;
    string[] strArray = new string[3]
    {
      "star_brake",
      "wait1",
      "wait2"
    };
    int index2 = nowStar - 1;
    while (index1 < breakStar)
    {
      this.dir_star_position[index2].GetComponent<Animator>().SetTrigger(strArray[index1]);
      ++index1;
      --index2;
    }
  }

  public bool EndAnimation() => this.endAnimation;

  [DebuggerHidden]
  private IEnumerator DamageAnimation(int nowStar, int breakStar)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282MemberBase.\u003CDamageAnimation\u003Ec__Iterator762()
    {
      nowStar = nowStar,
      breakStar = breakStar,
      \u003C\u0024\u003EnowStar = nowStar,
      \u003C\u0024\u003EbreakStar = breakStar,
      \u003C\u003Ef__this = this
    };
  }

  private void SetStar(int nowStar)
  {
    for (int index = 0; index < this.dir_star_position.Count; ++index)
    {
      this.dir_star_position[index].SetActive(nowStar > index);
      List<UITweener> list = ((IEnumerable<UITweener>) this.dir_star_position[index].GetComponentsInChildren<UITweener>()).Where<UITweener>((Func<UITweener, bool>) (x => x.tweenGroup == 281220)).ToList<UITweener>();
      if (list.Count != 0)
        list.ForEach((Action<UITweener>) (x => x.ResetToBeginning()));
    }
  }

  private void SetStarAnim(int nowStar)
  {
    for (int index = 0; index < this.dir_star_position.Count; ++index)
      this.dir_star_position[index].SetActive(nowStar > index);
  }

  private void AnimationStar(int nowStar, int breakStar)
  {
    int num = 0;
    int index = nowStar - 1;
    while (num < breakStar)
    {
      ((IEnumerable<UITweener>) this.dir_star_position[index].GetComponentsInChildren<UITweener>()).Where<UITweener>((Func<UITweener, bool>) (x => x.tweenGroup == 281220)).ForEach<UITweener>((Action<UITweener>) (x => x.PlayForward()));
      ++num;
      --index;
    }
  }

  private void SetLamp(List<GameObject> listObj, int num)
  {
    for (int index = 0; index < listObj.Count; ++index)
    {
      listObj[index].SetActive(num > index);
      List<UITweener> list = ((IEnumerable<UITweener>) listObj[index].GetComponentsInChildren<UITweener>()).Where<UITweener>((Func<UITweener, bool>) (x => x.tweenGroup == 281220)).ToList<UITweener>();
      if (list.Count != 0)
        list.ForEach((Action<UITweener>) (x => x.ResetToBeginning()));
    }
  }

  private void AnimationLamp(List<GameObject> listObj, int nowLamp, int lostLamp)
  {
    int num = 0;
    int index = nowLamp - 1;
    while (num < lostLamp)
    {
      ((IEnumerable<UITweener>) listObj[index].GetComponentsInChildren<UITweener>()).Where<UITweener>((Func<UITweener, bool>) (x => x.tweenGroup == 281220)).ForEach<UITweener>((Action<UITweener>) (x => x.PlayForward()));
      ++num;
      --index;
    }
  }

  public void Initialize(
    GuildMembership memberData,
    Guild0282Menu guild0282menu,
    GuildImageCache imageCache,
    bool enemy,
    GvgStatus gvgStatus)
  {
    this.isEnemy = enemy;
    this.member = memberData;
    this.menu = guild0282menu;
    this.memberBaseItem.SetActive(true);
    this.memberBaseItem.Initialize(this.IsEnemy, this.member);
    this.SetSprite(this.member, imageCache);
    this.dir_star.SetActive(this.member.is_defense_membership && GuildUtil.isBattleOrPreparing(gvgStatus));
    this.dir_lamp_base.SetActive(GuildUtil.isBattleOrPreparing(gvgStatus));
    this.SetBattleIcon(this.member.in_battle);
    this.SetWhiteFlag(GuildUtil.isBattleOrPreparing(gvgStatus) && !this.member.is_defense_membership);
    this.SetStar(this.member.own_star);
    if (GuildUtil.isBattleOrPreparing(gvgStatus) && (this.member.own_star == 0 || !this.member.is_defense_membership))
      this.townAnimSprite.color = Color.gray;
    if (this.isEnemy)
    {
      this.dir_lamp_enemy.SetActive(true);
      this.dir_lamp_own.SetActive(false);
      this.SetLamp(this.enemyLampList, this.member.action_point);
      this.townAnimObj.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
    }
    else
    {
      this.dir_lamp_enemy.SetActive(false);
      this.dir_lamp_own.SetActive(true);
      this.SetLamp(this.ownLampList, this.member.action_point);
    }
  }

  public void InitializeUpdate(
    GuildMembership memberData,
    Guild0282Menu guild0282menu,
    GuildImageCache imageCache,
    bool enemy,
    GvgStatus gvgStatus)
  {
    this.isEnemy = enemy;
    this.memberBaseItem.Initialize(this.IsEnemy, memberData);
    this.menu = guild0282menu;
    this.dir_star.SetActive(memberData.is_defense_membership && GuildUtil.isBattleOrPreparing(gvgStatus));
    this.dir_lamp_base.SetActive(GuildUtil.isBattleOrPreparing(gvgStatus));
    this.SetBattleIcon(memberData.in_battle);
    this.SetWhiteFlag(GuildUtil.isBattleOrPreparing(gvgStatus) && !memberData.is_defense_membership);
    if (GuildUtil.isBattleOrPreparing(gvgStatus) && (memberData.own_star == 0 || !memberData.is_defense_membership))
      this.townAnimSprite.color = Color.gray;
    else
      this.townAnimSprite.color = Color.white;
    if (this.member.own_star > memberData.own_star)
      this.AnimationStar(this.member.own_star, this.member.own_star - memberData.own_star);
    else
      this.SetStar(memberData.own_star);
    if (this.member.action_point > memberData.action_point)
    {
      if (this.isEnemy)
        this.AnimationLamp(this.enemyLampList, this.member.action_point, this.member.action_point - memberData.action_point);
      else
        this.AnimationLamp(this.ownLampList, this.member.action_point, this.member.action_point - memberData.action_point);
    }
    else if (this.isEnemy)
      this.SetLamp(this.enemyLampList, memberData.action_point);
    else
      this.SetLamp(this.ownLampList, memberData.action_point);
    this.member = memberData;
  }

  public void Focus()
  {
    if (!Object.op_Inequality((Object) this.menu, (Object) null))
      return;
    this.menu.onButtonMemberBase(this, this.member);
  }

  public void SetSprite(GuildMembership memberData, GuildImageCache imageCache)
  {
    this.guildImageCache = imageCache;
    this.townAnimObjList = this.ClearAnimation(this.townAnimObjList);
    this.SetPattern(1, GuildBaseType.town, this.townAnimObj, this.townAnimObjList);
  }

  private void GetUIWidgetChildren(Transform trans, List<UIWidget> list)
  {
    foreach (Transform child in trans.GetChildren())
    {
      UIWidget component = ((Component) child).GetComponent<UIWidget>();
      if (Object.op_Inequality((Object) component, (Object) null))
        list.Add(component);
      this.GetUIWidgetChildren(child, list);
    }
  }

  public void InitializePlayrtSituation(GuildMembership memberData, GuildImageCache imageCache)
  {
    this.isEnemy = false;
    this.guildImageCache = imageCache;
    this.townAnimObjList = this.ClearAnimation(this.townAnimObjList);
    this.memberBaseItem.SetActive(true);
    this.memberBaseItem.InitializeGB();
    this.dir_star.SetActive(memberData.is_defense_membership);
    this.dir_lamp_base.SetActive(false);
    this.SetBattleIcon(memberData.in_battle);
    this.SetWhiteFlag(!memberData.is_defense_membership);
    this.SetStar(memberData.own_star);
    this.SetPattern(1, GuildBaseType.town, this.townAnimObj, this.townAnimObjList);
    if (memberData.own_star == 0)
      this.townAnimSprite.color = Color.gray;
    if (this.isInitializePlayrtSituation)
      return;
    this.isInitializePlayrtSituation = true;
    List<UIWidget> list = new List<UIWidget>();
    this.GetUIWidgetChildren(((Component) this).transform, list);
    list.ForEach((Action<UIWidget>) (x => x.depth += 200));
  }

  public void InitializeGB(int townLevel, int ownStar, GuildImageCache imageCache)
  {
    this.isEnemy = true;
    this.guildImageCache = imageCache;
    this.townAnimObjList = this.ClearAnimation(this.townAnimObjList);
    this.memberBaseItem.SetActive(true);
    this.memberBaseItem.InitializeGB();
    this.dir_star.SetActive(true);
    this.dir_lamp_base.SetActive(false);
    this.SetBattleIcon(false);
    this.SetWhiteFlag(false);
    this.SetStar(ownStar);
    this.SetPattern(1, GuildBaseType.town, this.townAnimObj, this.townAnimObjList);
    if (ownStar != 0)
      return;
    this.townAnimSprite.color = Color.gray;
  }

  private void SetBattleIcon(bool isBattle)
  {
    if (Object.op_Equality((Object) this.dir_guild_battle_anim, (Object) null))
      return;
    this.dir_guild_battle_anim.SetBool("isAttack", isBattle);
  }

  private void SetWhiteFlag(bool isNotDefense)
  {
    if (!Object.op_Inequality((Object) this.whiteFlag, (Object) null))
      return;
    this.whiteFlag.SetActive(isNotDefense);
  }

  private void SetPattern(
    int level,
    GuildBaseType type,
    GameObject target,
    List<GameObject> animList)
  {
    GuildImagePattern pattern = GuildImagePattern.Find(type, level);
    target.GetComponent<UISprite>().SetSprite(pattern.TownSpriteName());
    target.transform.localPosition = new Vector3(pattern.base_pos.baseXpos, pattern.base_pos.baseYpos);
    GuildBaseAnimation[] array = ((IEnumerable<GuildBaseAnimation>) MasterData.GuildBaseAnimationList).Where<GuildBaseAnimation>((Func<GuildBaseAnimation, bool>) (x => x.anim_group_ID == pattern.base_animation_id)).OrderBy<GuildBaseAnimation, int>((Func<GuildBaseAnimation, int>) (x => x.ID)).ToArray<GuildBaseAnimation>();
    for (int index = 0; index < array.Length; ++index)
      this.SetAnimation(target, animList, array[index].animPrefixSprite, array[index].animframe, array[index].animXpos, array[index].animYpos, index + 1);
    target.SetActive(false);
    target.SetActive(true);
  }

  private void OnPress(bool isDown)
  {
    if (!Object.op_Inequality((Object) this.menu, (Object) null))
      return;
    this.menu.OnPress(isDown);
  }

  private void OnDrag(Vector2 delta)
  {
    if (!Object.op_Inequality((Object) this.menu, (Object) null))
      return;
    this.menu.OnDrag(delta);
  }

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

  private void Update()
  {
    if (!Object.op_Equality((Object) this.dir_guild_battle_anim, (Object) null))
      return;
    this.townAnimSprite.Invalidate(true);
  }
}
