// Decompiled with JetBrains decompiler
// Type: Bugu00539Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu00539Scene : NGSceneBase
{
  public List<PlayerItem> gearIdList;
  public bool is_new_;
  private GameObject armorSythesisAnimationPrefab;
  private GameObject sythesisObj;
  private string nowBgmName;
  [SerializeField]
  private Bugu00539Menu menu;

  public PlayerItem sythesisItem { get; set; }

  public PlayerItem baseItem { get; set; }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00539Scene.\u003ConStartSceneAsync\u003Ec__Iterator32C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    List<PlayerItem> num_list,
    bool is_new,
    string[] anim_pattern)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00539Scene.\u003ConStartSceneAsync\u003Ec__Iterator32D()
    {
      num_list = num_list,
      is_new = is_new,
      anim_pattern = anim_pattern,
      \u003C\u0024\u003Enum_list = num_list,
      \u003C\u0024\u003Eis_new = is_new,
      \u003C\u0024\u003Eanim_pattern = anim_pattern,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    List<PlayerItem> num_list,
    bool is_new,
    string[] anim_pattern,
    PlayerItem baseItem)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00539Scene.\u003ConStartSceneAsync\u003Ec__Iterator32E()
    {
      num_list = num_list,
      baseItem = baseItem,
      is_new = is_new,
      anim_pattern = anim_pattern,
      \u003C\u0024\u003Enum_list = num_list,
      \u003C\u0024\u003EbaseItem = baseItem,
      \u003C\u0024\u003Eis_new = is_new,
      \u003C\u0024\u003Eanim_pattern = anim_pattern,
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

  public void onStartScene(List<PlayerItem> num_list, bool is_new, string[] anim_pattern)
  {
    this.onStartScene();
  }

  public void onStartScene(
    List<PlayerItem> num_list,
    bool is_new,
    string[] anim_pattern,
    PlayerItem baseItem)
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
    return (IEnumerator) new Bugu00539Scene.\u003ConEndSceneAsync\u003Ec__Iterator32F()
    {
      \u003C\u003Ef__this = this
    };
  }
}
