// Decompiled with JetBrains decompiler
// Type: Popup02646Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup02646Menu : MonoBehaviour
{
  [SerializeField]
  private UILabel txtName;
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtDescription;
  [SerializeField]
  private UILabel txtLevel;
  [SerializeField]
  private UILabel txtTimeLimit;
  [SerializeField]
  private UI2DSprite linkTitle;
  [SerializeField]
  private GameObject slcFriend;
  [SerializeField]
  private GameObject slcNotFriend;
  [SerializeField]
  private GameObject slcFirstBattle;
  [SerializeField]
  private GameObject linkUnitThum;
  private System.Action actionOk;
  private System.Action actionNo;
  private System.Action actionMatchingCancel;
  private int timeSeconds = 15;
  private float nowTime;
  private bool isTimeOut;
  private bool isIbtnNo;

  [DebuggerHidden]
  public IEnumerator Init(
    System.Action actionOk,
    System.Action actionNo,
    System.Action actionMatchingCancel,
    WebAPI.Response.PvpFriend fData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02646Menu.\u003CInit\u003Ec__IteratorA31()
    {
      fData = fData,
      actionOk = actionOk,
      actionNo = actionNo,
      actionMatchingCancel = actionMatchingCancel,
      \u003C\u0024\u003EfData = fData,
      \u003C\u0024\u003EactionOk = actionOk,
      \u003C\u0024\u003EactionNo = actionNo,
      \u003C\u0024\u003EactionMatchingCancel = actionMatchingCancel,
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    if (!this.isTimeOut && (double) this.nowTime + 1.0 <= (double) Time.time)
    {
      --this.timeSeconds;
      this.nowTime = Time.time;
      if (this.timeSeconds < 0)
      {
        this.isTimeOut = true;
        this.TimeOutProc();
      }
      else
        this.txtTimeLimit.SetTextLocalize(this.timeSeconds);
    }
    if (Singleton<CommonRoot>.GetInstance().isInputBlock || !Input.GetKeyUp((KeyCode) 27))
      return;
    this.IbtnNo();
  }

  private void TimeOutProc()
  {
    this.IbtnNo();
    Singleton<PopupManager>.GetInstance().onDismiss();
    Consts instance = Consts.GetInstance();
    ModalWindow.Show(instance.VERSUS_002645POPUP_TITLE, instance.VERSUS_002645POPUP_DESCRIPTION, (System.Action) (() => { }));
  }

  public void IbtnOk()
  {
    if (this.isTimeOut)
      return;
    this.StartCoroutine(this.CreatePopupWait());
    this.actionOk();
  }

  public void IbtnNo()
  {
    if (this.isIbtnNo)
      return;
    this.isIbtnNo = true;
    this.actionNo();
  }

  [DebuggerHidden]
  private IEnumerator CreatePopupWait()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02646Menu.\u003CCreatePopupWait\u003Ec__IteratorA32()
    {
      \u003C\u003Ef__this = this
    };
  }
}
