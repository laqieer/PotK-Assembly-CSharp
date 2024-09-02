// Decompiled with JetBrains decompiler
// Type: Bugu00539Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu00539Scene : NGSceneBase
{
  public List<ItemInfo> gearIdList;
  public bool is_new_;
  private GameObject armorSythesisAnimationPrefab;
  private GameObject sythesisObj;
  private string nowBgmName;
  [SerializeField]
  private Bugu00539Menu menu;

  public ItemInfo sythesisItem { get; set; }

  public ItemInfo baseItem { get; set; }

  public static void ChangeScene(bool stack, Bugu00539ChangeSceneParam param)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_3_9", (stack ? 1 : 0) != 0, (object) param);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(Bugu00539ChangeSceneParam param)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00539Scene.\u003ConStartSceneAsync\u003Ec__Iterator3D1()
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

  public void onStartScene(Bugu00539ChangeSceneParam param) => this.onStartScene();

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
    return (IEnumerator) new Bugu00539Scene.\u003ConEndSceneAsync\u003Ec__Iterator3D2()
    {
      \u003C\u003Ef__this = this
    };
  }
}
