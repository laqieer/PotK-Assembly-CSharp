// Decompiled with JetBrains decompiler
// Type: Mypage00171Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Mypage00171Scroll : MonoBehaviour
{
  public UILabel PresentName;
  public GameObject[] BtnObject;
  private Consts.GachaType gachaType;
  private bool isApiUpdate;

  private string GetPresentName(PlayerPresent present)
  {
    return CommonRewardType.GetRewardName((MasterDataTable.CommonRewardType) present.reward_type_id.Value, !present.reward_id.HasValue ? 0 : present.reward_id.Value, !present.reward_quantity.HasValue ? 0 : present.reward_quantity.Value);
  }

  [DebuggerHidden]
  public IEnumerator Init(PlayerPresent present)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage00171Scroll.\u003CInit\u003Ec__Iterator1CF()
    {
      present = present,
      \u003C\u0024\u003Epresent = present,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnShop()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    Shop0071Scene.changeScene(true, false);
  }

  public void IbtnGacha()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    CommonRoot instance = Singleton<CommonRoot>.GetInstance();
    instance.isLoading = ((instance.isLoading ? 1 : 0) | (Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_3", true, (object) (int) this.gachaType, (object) this.isApiUpdate) ? 1 : 0)) != 0;
  }

  public void IbtnBugu()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    Bugu0052Scene.ChangeScene(true);
  }

  public void IbtnUnit()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    Unit00468Scene.changeScene00411(true);
  }

  public void IbtnEnblem()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    Title0241Scene.ChangeScene00241(true);
  }

  public void IbtnQuestkey()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    Quest00217Scene.ChangeScene(true);
  }

  public void IbtnSeasonTicket()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    Versus0261Scene.ChangeScene0261(true);
  }
}
