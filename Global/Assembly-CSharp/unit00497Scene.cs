// Decompiled with JetBrains decompiler
// Type: unit00497Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class unit00497Scene : NGSceneBase
{
  public List<PlayerUnit> unitList;
  public List<PlayerUnit> evolutionUnit;
  public bool is_new_;
  public bool fromEarth;
  private GameObject princessEvolutionPrefab;
  private string nowBgmName;
  [SerializeField]
  private unit00497Menu menu;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new unit00497Scene.\u003ConStartSceneAsync\u003Ec__Iterator2E8()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(ChangeSceneParam param)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new unit00497Scene.\u003ConStartSceneAsync\u003Ec__Iterator2E9()
    {
      param = param,
      \u003C\u0024\u003Eparam = param,
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

  public void onStartScene(ChangeSceneParam param) => this.onStartScene();

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
    return (IEnumerator) new unit00497Scene.\u003ConEndSceneAsync\u003Ec__Iterator2EA()
    {
      \u003C\u003Ef__this = this
    };
  }
}
