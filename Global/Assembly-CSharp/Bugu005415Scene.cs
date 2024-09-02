// Decompiled with JetBrains decompiler
// Type: Bugu005415Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu005415Scene : NGSceneBase
{
  public List<PlayerItem> gearList;
  private GameObject popUp;
  private GameObject sythesisObj;
  private string nowBgmName;
  [SerializeField]
  private Bugu005415Menu menu;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005415Scene.\u003ConStartSceneAsync\u003Ec__Iterator333()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    List<PlayerItem> thum_list,
    List<WebAPI.Response.ItemGearRepairRepair_results> result_list)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005415Scene.\u003ConStartSceneAsync\u003Ec__Iterator334()
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
    List<PlayerItem> thum_list,
    List<WebAPI.Response.ItemGearPoweredRepairRepair_results> result_list)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005415Scene.\u003ConStartSceneAsync\u003Ec__Iterator335()
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
    List<PlayerItem> thum_list,
    List<WebAPI.Response.ItemGearRepairRepair_results> result_list)
  {
    this.onStartScene();
  }

  public void onStartScene(
    List<PlayerItem> thum_list,
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
    return (IEnumerator) new Bugu005415Scene.\u003ConEndSceneAsync\u003Ec__Iterator336()
    {
      \u003C\u003Ef__this = this
    };
  }
}
