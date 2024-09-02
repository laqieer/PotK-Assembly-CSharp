// Decompiled with JetBrains decompiler
// Type: PopupMypageBattleSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class PopupMypageBattleSelect : BackButtonMonoBehaiviour
{
  private string ANIM_BATTLE_SELECT_OUT = "BattleSelect_Out";
  [SerializeField]
  private UIButton _btn_colosseum;
  [SerializeField]
  private UIButton _btn_multi;
  private bool isPush;
  private System.Action<PopupMypageBattleSelect.Selection> onSceneChange;
  private Animator animator;
  private PopupMypageBattleSelect.Selection selection;
  private bool closeOnly;

  private bool isPushAndSet()
  {
    if (this.isPush)
      return true;
    this.isPush = true;
    return false;
  }

  private void StartOutAnim(bool closeOnly = false)
  {
    this.animator.Play(this.ANIM_BATTLE_SELECT_OUT);
    this.closeOnly = closeOnly;
  }

  private IEnumerator procDismissPopup()
  {
    PopupMypageBattleSelect mypageBattleSelect = this;
    int outName = Animator.StringToHash(mypageBattleSelect.ANIM_BATTLE_SELECT_OUT);
    while (true)
    {
      AnimatorStateInfo animatorStateInfo = mypageBattleSelect.animator.GetCurrentAnimatorStateInfo(0);
      if (!animatorStateInfo.shortNameHash.Equals(outName) || (double) animatorStateInfo.normalizedTime < 1.0)
        yield return (object) null;
      else
        break;
    }
    foreach (Behaviour componentsInChild in mypageBattleSelect.GetComponentsInChildren<SpriteTransitionController>())
      componentsInChild.enabled = false;
    Singleton<PopupManager>.GetInstance().dismiss();
    if (!mypageBattleSelect._is_selected_scene_change() && mypageBattleSelect.onSceneChange != null)
      mypageBattleSelect.onSceneChange(mypageBattleSelect.selection);
  }

  public IEnumerator Initialize(
    System.Action<PopupMypageBattleSelect.Selection> onSceneChange)
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    PopupMypageBattleSelect mypageBattleSelect = this;
    if (num != 0)
      return false;
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = -1;
    mypageBattleSelect._btn_colosseum.enabled = true;
    mypageBattleSelect._btn_multi.enabled = true;
    mypageBattleSelect.onSceneChange = onSceneChange;
    mypageBattleSelect.animator = mypageBattleSelect.GetComponent<Animator>();
    return false;
  }

  public void onColosseum()
  {
    if (this.isPushAndSet())
      return;
    this.selection = PopupMypageBattleSelect.Selection.COLOSSEUM;
    this.StartOutAnim();
    if (!this._is_selected_scene_change() || this.onSceneChange == null)
      return;
    Singleton<CommonRoot>.GetInstance().isTouchBlock = true;
  }

  public void onMulti()
  {
    if (this.isPushAndSet())
      return;
    this.selection = PopupMypageBattleSelect.Selection.MULTI;
    this.StartOutAnim();
    if (this.onSceneChange == null)
      return;
    Singleton<CommonRoot>.GetInstance().isTouchBlock = true;
  }

  private bool _is_selected_scene_change() => this.selection != PopupMypageBattleSelect.Selection.COLOSSEUM || MypageTransition.getColosseumStatus() == MypageTransition.ColosseumStatus.OK;

  public override void onBackButton()
  {
    if (this.isPushAndSet())
      return;
    this.StartOutAnim(true);
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  public void ChangeScene()
  {
    this.StartCoroutine(this.procDismissPopup());
    if (this.closeOnly || !this._is_selected_scene_change() || this.onSceneChange == null)
      return;
    this.onSceneChange(this.selection);
  }

  public enum Selection
  {
    NONE,
    COLOSSEUM,
    MULTI,
  }
}
