// Decompiled with JetBrains decompiler
// Type: gacha006_effectScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class gacha006_effectScene : NGSceneBase
{
  public GachaResultData.ResultData gachaData;
  private GameObject popUp;
  private GameObject sythesisObj;
  private string nowBgmName;
  [SerializeField]
  private gacha006_effectMenu menu;
  private Color oldAmbient = new Color();

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool special)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new gacha006_effectScene.\u003ConStartSceneAsync\u003Ec__Iterator432()
    {
      special = special,
      \u003C\u0024\u003Especial = special,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new gacha006_effectScene.\u003ConStartSceneAsync\u003Ec__Iterator433()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    bool special,
    string gachaModuleName,
    Consts.GachaType gachaType,
    int gachaModuleGachaId)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new gacha006_effectScene.\u003ConStartSceneAsync\u003Ec__Iterator434()
    {
      gachaType = gachaType,
      gachaModuleName = gachaModuleName,
      gachaModuleGachaId = gachaModuleGachaId,
      special = special,
      \u003C\u0024\u003EgachaType = gachaType,
      \u003C\u0024\u003EgachaModuleName = gachaModuleName,
      \u003C\u0024\u003EgachaModuleGachaId = gachaModuleGachaId,
      \u003C\u0024\u003Especial = special,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    string gachaModuleName,
    Consts.GachaType gachaType,
    int gachaModuleGachaId)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new gacha006_effectScene.\u003ConStartSceneAsync\u003Ec__Iterator435()
    {
      gachaModuleName = gachaModuleName,
      gachaType = gachaType,
      gachaModuleGachaId = gachaModuleGachaId,
      \u003C\u0024\u003EgachaModuleName = gachaModuleName,
      \u003C\u0024\u003EgachaType = gachaType,
      \u003C\u0024\u003EgachaModuleGachaId = gachaModuleGachaId,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(GachaResultData.ResultData gacha_data, bool special = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new gacha006_effectScene.\u003ConStartSceneAsync\u003Ec__Iterator436()
    {
      gacha_data = gacha_data,
      special = special,
      \u003C\u0024\u003Egacha_data = gacha_data,
      \u003C\u0024\u003Especial = special,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    this.nowBgmName = Singleton<NGSoundManager>.GetInstance().GetBgmName();
    Singleton<NGSoundManager>.GetInstance().StopBgm();
    Singleton<CommonRoot>.GetInstance().isWebRunning = false;
    Singleton<CommonRoot>.GetInstance().isLoading = false;
  }

  public void onStartScene(GachaResultData.ResultData gacha_data) => this.onStartScene();

  public void onStartScene(bool special) => this.onStartScene();

  public void onStartScene(
    bool special,
    string gachaModuleName,
    Consts.GachaType gachaType,
    int gachaModuleGachaId)
  {
    this.onStartScene(special);
  }

  public void onStartScene(
    string gachaModuleName,
    Consts.GachaType gachaType,
    int gachaModuleGachaId)
  {
    this.onStartScene();
  }

  public override void onEndScene()
  {
    RenderSettings.ambientLight = this.oldAmbient;
    Time.timeScale = 1f;
    base.onEndScene();
    Singleton<PopupManager>.GetInstance().open((GameObject) null);
    Singleton<NGSoundManager>.GetInstance().PlayBgm(this.nowBgmName);
  }

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new gacha006_effectScene.\u003ConEndSceneAsync\u003Ec__Iterator437()
    {
      \u003C\u003Ef__this = this
    };
  }
}
