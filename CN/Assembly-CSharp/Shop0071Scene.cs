// Decompiled with JetBrains decompiler
// Type: Shop0071Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop0071Scene : NGSceneBase
{
  public BoxCollider BETA_LIMIT_HIMEISHI_BUTTON;
  private WebAPI.Response.ShopStatus ShopStatus;

  public static void changeScene(bool stack, bool isUpdate, bool specialShopError = false)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("shop007_1", (stack ? 1 : 0) != 0, (object) isUpdate, (object) specialShopError);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0071Scene.\u003ConInitSceneAsync\u003Ec__Iterator447()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool isUpdate, bool specialShopError)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0071Scene.\u003ConStartSceneAsync\u003Ec__Iterator448()
    {
      isUpdate = isUpdate,
      specialShopError = specialShopError,
      \u003C\u0024\u003EisUpdate = isUpdate,
      \u003C\u0024\u003EspecialShopError = specialShopError,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0071Scene.\u003ConStartSceneAsync\u003Ec__Iterator449()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene(bool isUpdate, bool specialShopError) => this.onStartScene();

  public void onStartScene()
  {
    Player player = SMManager.Get<Player>();
    Debug.Log((object) "007-1商店TOP页面开始");
    string stone = player.coin.ToString();
    string apString = CommonHeaderAP.GetApString(player.ap + player.ap_overflow, player.ap_max);
    string unit = player.max_units.ToString();
    string str = player.max_items.ToString();
    ((Component) this).GetComponent<Shop0071Menu>().SetInitalView(stone, apString, unit, str);
    ((Component) this).GetComponent<Shop0071Menu>().onStartScene();
  }

  private void Update()
  {
    Player player = SMManager.Get<Player>();
    if (player == null)
      return;
    string stone = player.coin.ToString();
    string apString = CommonHeaderAP.GetApString(player.ap + player.ap_overflow, player.ap_max);
    string unit = player.max_units.ToString();
    string str = player.max_items.ToString();
    ((Component) this).GetComponent<Shop0071Menu>().SetTextData(stone, apString, unit, str);
  }
}
