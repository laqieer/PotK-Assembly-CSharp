// Decompiled with JetBrains decompiler
// Type: unit004812Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class unit004812Scene : NGSceneBase
{
  public List<PlayerUnit> unitList;
  public List<PlayerUnit> resultList;
  public bool is_success_;
  private GameObject princessSynthesisPrefab;
  private string nowBgmName;
  [SerializeField]
  private unit004812Menu menu;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new unit004812Scene.\u003ConStartSceneAsync\u003Ec__Iterator36B()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    List<PlayerUnit> num_list,
    List<PlayerUnit> result_list,
    List<int> other_list,
    Dictionary<string, object> showPopupData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new unit004812Scene.\u003ConStartSceneAsync\u003Ec__Iterator36C()
    {
      num_list = num_list,
      result_list = result_list,
      showPopupData = showPopupData,
      other_list = other_list,
      \u003C\u0024\u003Enum_list = num_list,
      \u003C\u0024\u003Eresult_list = result_list,
      \u003C\u0024\u003EshowPopupData = showPopupData,
      \u003C\u0024\u003Eother_list = other_list,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    List<PlayerUnit> num_list,
    List<PlayerUnit> result_list,
    List<int> other_list,
    Dictionary<string, object> showPopupData,
    Unit00468Scene.Mode mode)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new unit004812Scene.\u003ConStartSceneAsync\u003Ec__Iterator36D()
    {
      mode = mode,
      num_list = num_list,
      result_list = result_list,
      other_list = other_list,
      showPopupData = showPopupData,
      \u003C\u0024\u003Emode = mode,
      \u003C\u0024\u003Enum_list = num_list,
      \u003C\u0024\u003Eresult_list = result_list,
      \u003C\u0024\u003Eother_list = other_list,
      \u003C\u0024\u003EshowPopupData = showPopupData,
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
    List<PlayerUnit> num_list,
    List<PlayerUnit> result_list,
    List<int> other_list,
    Dictionary<string, object> showPopupData)
  {
    this.onStartScene();
  }

  public void onStartScene(
    List<PlayerUnit> num_list,
    List<PlayerUnit> result_list,
    List<int> other_list,
    Dictionary<string, object> showPopupData,
    Unit00468Scene.Mode mode)
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
    return (IEnumerator) new unit004812Scene.\u003ConEndSceneAsync\u003Ec__Iterator36E()
    {
      \u003C\u003Ef__this = this
    };
  }
}
