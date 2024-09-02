// Decompiled with JetBrains decompiler
// Type: MypageTransition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
  }

  public void onEvent()
  {
    if (this.menu.IsPushAndSet())
      return;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.playSE("SE_1002");
    Quest00217Scene.ChangeScene(true);
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

  public void onBingo()
  {
    if (this.menu.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("dailymission027_1_2", true);
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
    List<PlayerUnit> list = ((IEnumerable<PlayerUnit>) SMManager.Get<PlayerUnit[]>()).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x.unit.IsNormalUnit)).ToList<PlayerUnit>();
    if (list.Count<PlayerUnit>() < 3)
    {
      this.StartCoroutine(this.openPopup008161UnitInsufficiency());
    }
    else
    {
      Player player = SMManager.Get<Player>();
      PlayerUnit[] array = list.OrderBy<PlayerUnit, int>((Func<PlayerUnit, int>) (x => x.unit.cost)).ToArray<PlayerUnit>();
      int num = 0;
      for (int index = 0; index < 3; ++index)
        num += array[index].unit.cost;
      if (player.max_cost >= num)
        Colosseum0234Scene.ChangeScene(true);
      else
        this.StartCoroutine(this.openPopup008161CostInsufficiency());
    }
  }

  public void onCharacter()
  {
    if (this.menu.IsPushAndSet())
      return;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.playSE("SE_1002");
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_14", true);
  }

  public void onMulti()
  {
    if (this.menu.IsPushAndSet())
      return;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.playSE("SE_1002");
    Versus0261Scene.ChangeScene0261(true);
  }

  public void onEarth()
  {
    if (this.menu.IsPushAndSet())
      return;
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
    MypageTransition.\u003CopenPopup008161UnitInsufficiency\u003Ec__Iterator7A8 insufficiencyCIterator7A8 = new MypageTransition.\u003CopenPopup008161UnitInsufficiency\u003Ec__Iterator7A8();
    return (IEnumerator) insufficiencyCIterator7A8;
  }

  [DebuggerHidden]
  private IEnumerator openPopup008161CostInsufficiency()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    MypageTransition.\u003CopenPopup008161CostInsufficiency\u003Ec__Iterator7A9 insufficiencyCIterator7A9 = new MypageTransition.\u003CopenPopup008161CostInsufficiency\u003Ec__Iterator7A9();
    return (IEnumerator) insufficiencyCIterator7A9;
  }
}
