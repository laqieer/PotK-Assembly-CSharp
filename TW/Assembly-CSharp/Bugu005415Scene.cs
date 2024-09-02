// Decompiled with JetBrains decompiler
// Type: Bugu005415Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu005415Scene : NGSceneBase
{
  [SerializeField]
  private Bugu005415Menu menu;
  private GameObject popUp;
  private string nowBgmName;

  public static void ChangeScene(
    bool stack,
    List<ItemInfo> thum_list,
    List<WebAPI.Response.ItemGearRepairRepair_results> result_list)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_4_15", (stack ? 1 : 0) != 0, (object) thum_list, (object) result_list);
  }

  public static void ChangeScene(
    bool stack,
    List<ItemInfo> thum_list,
    List<WebAPI.Response.ItemGearPoweredRepairRepair_results> result_list)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_4_15", (stack ? 1 : 0) != 0, (object) thum_list, (object) result_list);
  }

  [DebuggerHidden]
  private IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005415Scene.\u003ConStartSceneAsync\u003Ec__Iterator3D6()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    List<ItemInfo> thum_list,
    List<WebAPI.Response.ItemGearRepairRepair_results> result_list)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005415Scene.\u003ConStartSceneAsync\u003Ec__Iterator3D7()
    {
      thum_list = thum_list,
      result_list = result_list,
      \u003C\u0024\u003Ethum_list = thum_list,
      \u003C\u0024\u003Eresult_list = result_list,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    List<ItemInfo> thum_list,
    List<WebAPI.Response.ItemGearPoweredRepairRepair_results> result_list)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005415Scene.\u003ConStartSceneAsync\u003Ec__Iterator3D8()
    {
      thum_list = thum_list,
      result_list = result_list,
      \u003C\u0024\u003Ethum_list = thum_list,
      \u003C\u0024\u003Eresult_list = result_list,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    Singleton<PopupManager>.GetInstance().closeAll();
    this.nowBgmName = Singleton<NGSoundManager>.GetInstance().GetBgmName();
    Singleton<NGSoundManager>.GetInstance().StopBgm();
  }

  public void onStartScene(
    List<ItemInfo> thum_list,
    List<WebAPI.Response.ItemGearRepairRepair_results> result_list)
  {
    this.onStartScene();
  }

  public void onStartScene(
    List<ItemInfo> thum_list,
    List<WebAPI.Response.ItemGearPoweredRepairRepair_results> result_list)
  {
    this.onStartScene();
  }

  public override void onEndScene()
  {
    base.onEndScene();
    Singleton<PopupManager>.GetInstance().open((GameObject) null);
    Singleton<NGSoundManager>.GetInstance().PlayBgm(this.nowBgmName);
  }

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005415Scene.\u003ConEndSceneAsync\u003Ec__Iterator3D9()
    {
      \u003C\u003Ef__this = this
    };
  }
}
