// Decompiled with JetBrains decompiler
// Type: MypageTransition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class MypageTransition : MonoBehaviour
{
  public int L_id;
  public bool hardmode;
  [SerializeField]
  private MypageMenu menu;

  public void onQuest()
  {
    if (this.menu.IsPushAndSet())
      return;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.playSE("SE_1002");
    Singleton<CommonRoot>.GetInstance().getBackgroundComponent<QuestBG>().CloudAnim(false);
    this.StartCoroutine(((Component) this).GetComponent<BGChange>().asyncBgAnim(QuestBG.AnimApply.MyPage, 1f));
    Quest00240723Scene.ChangeScene0024(true, this.L_id, this.hardmode);
    Singleton<NGBattleManager>.GetInstance().SetBattleType(NGBattleManager.BattleType.BATTLE_STORY);
  }

  public void onEvent()
  {
    if (this.menu.IsPushAndSet())
      return;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.playSE("SE_1002");
    Quest00217Scene.ChangeScene(true);
    Singleton<NGBattleManager>.GetInstance().SetBattleType(NGBattleManager.BattleType.BATTLE_STORY);
  }

  public void onMenu()
  {
    if (this.menu.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story001_9_1", true);
  }

  public void onInfo()
  {
    if (this.menu.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("mypage001_8_1", true);
  }

  public void onMission()
  {
    if (this.menu.IsPushAndSet())
      return;
    if (SMManager.Get<Player>().is_bingo_end)
      Singleton<NGSceneManager>.GetInstance().changeScene("dailymission027_2", true);
    else
      Singleton<NGSceneManager>.GetInstance().changeScene("dailymission027_1", true);
  }

  public void onFAQ()
  {
    if (this.menu.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story001_9_1_FAQ", true);
  }

  public void onActivity()
  {
    if (this.menu.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("activity004_18", true);
  }

  public void onBuyKiseki()
  {
    if (this.menu.IsPushAndSet())
      return;
    this.StartCoroutine(PopupUtility.BuyKiseki());
  }

  public void onPresent()
  {
    if (this.menu.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("mypage001_7", true);
  }

  public void onColosseum()
  {
    if (this.menu.IsPushAndSet())
      return;
    PlayerUnit[] source = SMManager.Get<PlayerUnit[]>();
    if (((IEnumerable<PlayerUnit>) source).Count<PlayerUnit>() < 3)
    {
      this.StartCoroutine(this.openPopup008161UnitInsufficiency());
    }
    else
    {
      Player player = SMManager.Get<Player>();
      PlayerUnit[] array = ((IEnumerable<PlayerUnit>) source).OrderBy<PlayerUnit, int>((Func<PlayerUnit, int>) (x => x.unit.cost)).ToArray<PlayerUnit>();
      int num = 0;
      for (int index = 0; index < 3; ++index)
        num += array[index].unit.cost;
      if (player.max_cost >= num)
        Colosseum0234Scene.ChangeScene(true);
      else
        this.StartCoroutine(this.openPopup008161CostInsufficiency());
    }
    Singleton<NGBattleManager>.GetInstance().SetBattleType(NGBattleManager.BattleType.BATTLE_COLOSEUM);
  }

  public void onCharacter()
  {
    if (this.menu.IsPushAndSet())
      return;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.playSE("SE_1002");
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_14", true);
    Singleton<NGBattleManager>.GetInstance().SetBattleType(NGBattleManager.BattleType.BATTLE_STORY);
  }

  public void onMulti()
  {
    if (this.menu.IsPushAndSet())
      return;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.playSE("SE_1002");
    Versus0261Scene.ChangeScene0261(true);
    Singleton<NGBattleManager>.GetInstance().SetBattleType(NGBattleManager.BattleType.BATTLE_PVP);
  }

  public void onEarth()
  {
    if (this.menu.IsPushAndSet())
      return;
    Singleton<CommonRoot>.GetInstance().isTouchBlock = true;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.playSE("SE_1039");
    this.StartCoroutine(this.menu.CloudAnimationStart());
  }

  [DebuggerHidden]
  private IEnumerator openPopup008161UnitInsufficiency()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    MypageTransition.\u003CopenPopup008161UnitInsufficiency\u003Ec__Iterator913 insufficiencyCIterator913 = new MypageTransition.\u003CopenPopup008161UnitInsufficiency\u003Ec__Iterator913();
    return (IEnumerator) insufficiencyCIterator913;
  }

  [DebuggerHidden]
  private IEnumerator openPopup008161CostInsufficiency()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    MypageTransition.\u003CopenPopup008161CostInsufficiency\u003Ec__Iterator914 insufficiencyCIterator914 = new MypageTransition.\u003CopenPopup008161CostInsufficiency\u003Ec__Iterator914();
    return (IEnumerator) insufficiencyCIterator914;
  }
}
