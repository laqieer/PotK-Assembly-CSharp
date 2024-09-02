// Decompiled with JetBrains decompiler
// Type: Bugu0052Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu0052Scene : NGSceneBase
{
  public Bugu0052Menu menu;
  protected static bool isResetParam = true;
  public Bugu0052Scene.MODE sceneMode;
  private bool[] isInit = new bool[10];
  [HideInInspector]
  public int listCount;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0052Scene.\u003ConInitSceneAsync\u003Ec__Iterator310()
    {
      \u003C\u003Ef__this = this
    };
  }

  public static void changeSceneOverView(bool stack)
  {
    Bugu0052Scene.isResetParam = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_2", (stack ? 1 : 0) != 0, (object) Bugu0052Scene.MODE.OVERVIEW);
  }

  public static void changeSceneComposite(bool stack, bool isReset, List<PlayerItem> select)
  {
    Bugu0052Scene.isResetParam = isReset;
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_2", (stack ? 1 : 0) != 0, (object) Bugu0052Scene.MODE.COMPOSITE, (object) select);
  }

  public static void changeScenePakuPakuBase(bool stack, bool isReset)
  {
    Bugu0052Scene.isResetParam = isReset;
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_2", (stack ? 1 : 0) != 0, (object) Bugu0052Scene.MODE.PAKUPAKU_BASE);
  }

  public static void changeScenePakuPakuMaterial(
    bool stack,
    bool isReset,
    List<PlayerItem> select,
    PlayerItem target)
  {
    Bugu0052Scene.isResetParam = isReset;
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_8_2", (stack ? 1 : 0) != 0, (object) Bugu0052Scene.MODE.PAKUPAKU_MATERIAL, (object) select, (object) target);
  }

  public static void changeSceneRepair(bool stack)
  {
    Bugu0052Scene.isResetParam = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_2", (stack ? 1 : 0) != 0, (object) Bugu0052Scene.MODE.REPAIR);
  }

  public static void changeSceneSell(bool stack)
  {
    Bugu0052Scene.isResetParam = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_2", (stack ? 1 : 0) != 0, (object) Bugu0052Scene.MODE.SELL);
  }

  public static void changeSceneDrillingBase(bool stack)
  {
    Bugu0052Scene.isResetParam = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_2", (stack ? 1 : 0) != 0, (object) Bugu0052Scene.MODE.DRILLING_BASE);
  }

  public static void changeSceneDrillingMaterial(
    bool stack,
    bool isReset,
    List<PlayerItem> select,
    PlayerItem target)
  {
    Bugu0052Scene.isResetParam = isReset;
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_9_2", (stack ? 1 : 0) != 0, (object) Bugu0052Scene.MODE.DRILLING_MATERIAL, (object) select, (object) target);
  }

  public static void changeSceneSpecialDrillingMaterial(
    bool stack,
    bool isReset,
    List<PlayerItem> select,
    PlayerItem target)
  {
    Bugu0052Scene.isResetParam = isReset;
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_9_2", (stack ? 1 : 0) != 0, (object) Bugu0052Scene.MODE.SPECIAL_DRILLING_MATERIAL, (object) select, (object) target);
  }

  [DebuggerHidden]
  public virtual IEnumerator onStartSceneAsync(Bugu0052Scene.MODE mode)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0052Scene.\u003ConStartSceneAsync\u003Ec__Iterator311()
    {
      mode = mode,
      \u003C\u0024\u003Emode = mode,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(Bugu0052Scene.MODE mode, List<PlayerItem> select)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0052Scene.\u003ConStartSceneAsync\u003Ec__Iterator312()
    {
      mode = mode,
      select = select,
      \u003C\u0024\u003Emode = mode,
      \u003C\u0024\u003Eselect = select,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    Bugu0052Scene.MODE mode,
    List<PlayerItem> select,
    PlayerItem target)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0052Scene.\u003ConStartSceneAsync\u003Ec__Iterator313()
    {
      mode = mode,
      target = target,
      select = select,
      \u003C\u0024\u003Emode = mode,
      \u003C\u0024\u003Etarget = target,
      \u003C\u0024\u003Eselect = select,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void onStartScene(Bugu0052Scene.MODE mode)
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    Singleton<CommonRoot>.GetInstance().isActiveHeader = true;
    Singleton<CommonRoot>.GetInstance().isActiveFooter = true;
  }

  public void onStartScene(Bugu0052Scene.MODE mode, List<PlayerItem> select)
  {
    this.onStartScene(mode);
  }

  public void onStartScene(Bugu0052Scene.MODE mode, List<PlayerItem> select, PlayerItem target)
  {
    this.onStartScene(mode);
  }

  public override void onEndScene()
  {
    Persist.sortOrder.Flush();
    this.menu.onEndScene(this);
    ItemIcon.ClearCache();
  }

  public void clearInitFlg() => this.isInit[(int) this.sceneMode] = true;

  public enum MODE
  {
    NONE,
    OVERVIEW,
    COMPOSITE,
    PAKUPAKU_BASE,
    PAKUPAKU_MATERIAL,
    REPAIR,
    SELL,
    DRILLING_BASE,
    DRILLING_MATERIAL,
    SPECIAL_DRILLING_MATERIAL,
    MAX,
  }
}
