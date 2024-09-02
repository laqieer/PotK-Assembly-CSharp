// Decompiled with JetBrains decompiler
// Type: Startup00014Renzoku
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Startup00014Renzoku : Startup00014Menu
{
  private int loginTotalDay = 5;
  [SerializeField]
  private UITweener fade;
  [SerializeField]
  private GameObject get;
  [SerializeField]
  private GameObject next;
  [SerializeField]
  private UITexture back;
  [SerializeField]
  private UITexture title;
  private Texture frame;
  private GameObject loginAnime;
  private GameObject finishStamp;
  private GameObject todayStamp;
  [SerializeField]
  private GameObject stampFrame;
  private Sprite mainSprite;
  private Texture2D maskTexture;
  private int unitID = 100611;
  private UnitUnit unitData;
  private int charaID;
  private bool story;
  [SerializeField]
  private Transform charaContainer;
  public float scale = 1.5f;
  public int depth = 300;
  private Startup00014BonusIcon itemList = new Startup00014BonusIcon();
  private GameObject getItem;
  private Startup00014BonusIcon newItemList = new Startup00014BonusIcon();
  private GameObject nextItem;
  [SerializeField]
  private GameObject GetNextMaskTop;
  [SerializeField]
  private GameObject GetNextMaskLeft;
  private List<GameObject> stampList = new List<GameObject>();
  private List<Startup00014StampFrame> stampFrameList = new List<Startup00014StampFrame>();
  [SerializeField]
  private GameObject mainItemBaseObj;
  private int pageCount;
  private GameObject naviChara;
  [SerializeField]
  private string faceName = "happy";
  private int maxRewardValue;
  private int drawIconValue = 10;
  private PlayerLoginBonus loginBonus;
  private int stampValue;
  private List<LoginbonusReward> loginBonusRewardList;
  private LoginbonusReward loginBonusReward;
  private bool rewardReset;
  private bool rewardLast;

  public void onNextButton()
  {
    Singleton<NGSoundManager>.GetInstance().stopSE();
    if (this.pageCount == 0)
      this.NowStamp();
    else if (this.pageCount == 1)
    {
      this.PlayVoiceAndFaceChange();
      this.RewardChange();
    }
    else if (this.pageCount == 2)
      this.SceneEnd();
    ++this.pageCount;
  }

  private void PlayVoiceAndFaceChange()
  {
    this.changeFace(this.faceName);
    Singleton<NGSoundManager>.GetInstance().stopVoice();
    if (this.charaID == 0)
      Singleton<NGSoundManager>.GetInstance().playVoiceByStringID("VO_9999", "durin_0005");
    else if (this.loginBonusReward.que_name2 != null)
    {
      string[] strArray = this.loginBonusReward.que_name2.Split(',');
      if (strArray.Length > 1)
        Singleton<NGSoundManager>.GetInstance().playVoiceByStringID(strArray[1], strArray[0]);
      else if (this.story)
        Singleton<NGSoundManager>.GetInstance().playVoiceByStringID("VO_" + (object) this.charaID, this.loginBonusReward.que_name2);
      else if (this.unitData.unitVoicePattern != null)
        Singleton<NGSoundManager>.GetInstance().playVoiceByStringID(this.unitData.unitVoicePattern.file_name, this.loginBonusReward.que_name2);
    }
    Singleton<NGSoundManager>.GetInstance().playSE("SE_1002");
  }

  private void RewardReset()
  {
    this.itemList.ListEnable(false);
    this.newItemList.ListEnable(true);
    foreach (Object stamp in this.stampList)
      Object.Destroy(stamp);
  }

  private void SceneEnd()
  {
    Singleton<NGSoundManager>.GetInstance().playSE("SE_1002");
    this.fade.onFinished = new List<EventDelegate>();
    this.fade.PlayReverse();
    this.fade.AddOnFinished(new EventDelegate.Callback(this.AnimationEnd));
    ((Behaviour) ((Component) this.fade).gameObject.GetComponent<UIButton>()).enabled = false;
  }

  private void RewardChange()
  {
    this.TxtNavi.SetTextLocalize(this.loginBonusReward.next_reward_message);
    if (this.rewardLast)
      return;
    this.get.SetActive(false);
    this.next.SetActive(true);
    this.Play(this.next.transform);
    this.nextItem.SetActive(true);
    this.getItem.SetActive(false);
    if (!this.rewardReset)
      return;
    this.RewardReset();
  }

  private void DestroyTrash()
  {
    foreach (Component stampFrame in this.stampFrameList)
      Object.Destroy((Object) stampFrame.gameObject);
    foreach (Object stamp in this.stampList)
      Object.Destroy(stamp);
    Object.Destroy((Object) this.getItem);
    Object.Destroy((Object) this.nextItem);
    Object.Destroy((Object) this.naviChara);
    this.itemList.Clear();
    this.newItemList.Clear();
    this.stampList.Clear();
    this.stampFrameList.Clear();
  }

  private void Init()
  {
    this.DestroyTrash();
    this.rewardReset = false;
    this.rewardLast = false;
    this.loginTotalDay = this.loginBonus.login_days;
    this.loginBonusRewardList = ((IEnumerable<LoginbonusReward>) MasterData.LoginbonusRewardList).Where<LoginbonusReward>((Func<LoginbonusReward, bool>) (x => x.loginbonus == this.loginBonus.loginbonus)).OrderBy<LoginbonusReward, int>((Func<LoginbonusReward, int>) (x => x.number)).ToList<LoginbonusReward>();
    this.loginBonusReward = this.loginBonusRewardList.Where<LoginbonusReward>((Func<LoginbonusReward, bool>) (x => x.number == this.loginTotalDay)).First<LoginbonusReward>();
    this.maxRewardValue = this.loginBonusRewardList.Count;
    this.unitID = this.loginBonusReward.character_id;
    this.story = this.unitID < 100000;
    if (this.story)
    {
      this.charaID = this.unitID;
    }
    else
    {
      this.unitData = ((IEnumerable<UnitUnit>) MasterData.UnitUnitList).Where<UnitUnit>((Func<UnitUnit, bool>) (x => x.ID == this.unitID)).First<UnitUnit>();
      this.charaID = this.unitData.character.ID;
    }
    this.drawIconValue = this.loginBonus.loginbonus.draw_reward_num;
    this.listIcons = this.positionList[this.drawIconValue - 1].positionList;
    this.stampValue = this.loginTotalDay % this.drawIconValue;
    if (this.stampValue == 0)
      this.stampValue = this.drawIconValue;
    if (this.stampValue != 0)
      return;
    this.stampValue = 1;
  }

  [DebuggerHidden]
  private IEnumerator LoadResource()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00014Renzoku.\u003CLoadResource\u003Ec__Iterator139()
    {
      \u003C\u003Ef__this = this
    };
  }

  public string LoadString(int number, string name)
  {
    return string.Format("Prefabs/startup000_14/image/{0}/{1}", (object) number, (object) name);
  }

  private void InitNaviChara()
  {
    NGxMaskSpriteWithScale component = this.naviChara.GetComponent<NGxMaskSpriteWithScale>();
    if (this.charaID == 0)
    {
      this.naviChara.transform.localScale = new Vector3(this.scale, this.scale, 1f);
    }
    else
    {
      component.SetMaskEnable(false);
      component.MainUI2DSprite.sprite2D = this.mainSprite;
      this.naviChara.transform.localScale = new Vector3(this.loginBonusReward.character_scale, this.loginBonusReward.character_scale, 1f);
      this.naviChara.transform.localPosition = new Vector3(this.loginBonusReward.character_x, this.loginBonusReward.character_y, 0.0f);
    }
    component.maskTexture = this.maskTexture;
    component.FitMask();
  }

  [DebuggerHidden]
  public override IEnumerator InitSceneAsync(PlayerLoginBonus lB)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00014Renzoku.\u003CInitSceneAsync\u003Ec__Iterator13A()
    {
      lB = lB,
      \u003C\u0024\u003ElB = lB,
      \u003C\u003Ef__this = this
    };
  }

  public void AnimationStart()
  {
    Object.Instantiate<GameObject>(this.loginAnime).transform.parent = ((Component) this).transform;
    this.get.SetActive(true);
    this.Play(this.get.transform);
    if (this.charaID == 0)
      Singleton<NGSoundManager>.GetInstance().playVoiceByStringID("VO_9999", "durin_navi_0062");
    else if (this.loginBonusReward.que_name1 != null)
    {
      string[] strArray = this.loginBonusReward.que_name1.Split(',');
      if (strArray.Length > 1)
        Singleton<NGSoundManager>.GetInstance().playVoiceByStringID(strArray[1], strArray[0]);
      else if (this.story)
        Singleton<NGSoundManager>.GetInstance().playVoiceByStringID("VO_" + (object) this.charaID, this.loginBonusReward.que_name1);
      else if (this.unitData.unitVoicePattern != null)
        Singleton<NGSoundManager>.GetInstance().playVoiceByStringID(this.unitData.unitVoicePattern.file_name, this.loginBonusReward.que_name1);
    }
    Singleton<NGSoundManager>.GetInstance().playSE("SE_1032");
  }

  public void AnimationEnd() => Object.Destroy((Object) ((Component) this).gameObject);

  public void SetRewardObject(int receiveCount)
  {
    int index1 = (receiveCount - 1) % this.drawIconValue;
    int index2 = (index1 + 1) % this.drawIconValue;
    this.getItem = this.itemList.IconList[index1].Clone(this.mainItemBaseObj.transform);
    this.nextItem = !this.rewardReset || this.newItemList.IconList.Count <= index2 ? this.itemList.IconList[index2].Clone(this.mainItemBaseObj.transform) : this.newItemList.IconList[index2].Clone(this.mainItemBaseObj.transform);
    this.nextItem.SetActive(false);
  }

  private void changeFace(string name)
  {
    NGxFaceSprite component = this.naviChara.GetComponent<NGxFaceSprite>();
    component.UnitID = this.unitID;
    if (Object.op_Equality((Object) component, (Object) null))
      return;
    this.StartCoroutine(component.ChangeFace(name));
  }

  private void onStampSE()
  {
    Singleton<NGSoundManager>.GetInstance().stopSE();
    Singleton<NGSoundManager>.GetInstance().playSE("SE_1033");
  }

  private void SetStampFrame()
  {
    for (int index = 0; index < this.drawIconValue; ++index)
    {
      Startup00014StampFrame component = this.stampFrame.Clone(((Component) this.listIcons[index]).transform).GetComponent<Startup00014StampFrame>();
      component.ChangeFrame(this.frame);
      component.ArrowPosition(this.drawIconValue - 1);
      this.stampFrameList.Add(component);
    }
    this.stampFrameList[this.drawIconValue - 1].ArrowEnable(false);
  }

  private void OldStamp()
  {
    for (int index = 0; index < this.stampValue - 1; ++index)
    {
      GameObject gameObject = this.finishStamp.Clone(((Component) this.listIcons[index]).transform);
      gameObject.transform.localPosition = new Vector3(0.0f, 5f, 0.0f);
      this.stampList.Add(gameObject);
    }
  }

  private void NowStamp()
  {
    this.onStampSE();
    GameObject gameObject = this.todayStamp.Clone(((Component) this.listIcons[this.stampValue - 1]).transform);
    gameObject.transform.localPosition = new Vector3(0.0f, 5f, 0.0f);
    this.stampList.Add(gameObject);
  }
}
