// Decompiled with JetBrains decompiler
// Type: Unit00468Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit00468Scene : NGSceneBase
{
  private readonly int SELL_SCROLLPANEL_BOTTOMANCHOR = 100;
  private readonly int SELL_SCROLLBAR_BOTTOMANCHOR = 162;
  private readonly int FORMATION_SCROLLPANEL_BOTTOMANCHOR = 120;
  private readonly int FORMATION_SCROLLBAR_BOTTOMANCHOR = 140;
  private readonly int POSSESION_SCROLLPANEL_BOTTOMANCHOR;
  private readonly int POSSESION_SCROLLBAR_BOTTOMANCHOR = 60;
  public Unit00468Menu menu00468;
  public Unit004682Menu menu004682;
  public Unit0048Menu menu0048;
  public Unit00481Menu menu00481;
  public Unit00491Menu menu00491;
  public Unit00492Menu menu00492;
  public Unit00410Menu menu00410;
  public Unit00411Menu menu00411;
  public Unit00412Menu menu00412;
  public Unit004431Menu menu004431;
  public Unit00414Menu menu00414;
  public Unit00468GvgMenu menu00468Gvg;
  public GameObject bottomFromation;
  public GameObject bottomPossesion;
  public GameObject bottomSell;
  public GameObject sortAndFilertObject;
  public UIPanel scrollPanel;
  public UIWidget scrollBarWidget;
  public UIWidget bottomWidget;
  [SerializeField]
  private UIScrollView ScrollView;
  public Unit00468Scene.Mode debugInitialMode = Unit00468Scene.Mode.Unit00411;
  [SerializeField]
  private UILabel textTitle;
  private UnitMenuBase currentMenu;
  private bool[] isInit = new bool[17];

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00468Scene.\u003ConInitSceneAsync\u003Ec__Iterator356()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00468Scene.\u003CStart\u003Ec__Iterator357()
    {
      \u003C\u003Ef__this = this
    };
  }

  public static void changeScene00468(
    bool stack,
    PlayerDeck playerDeck,
    Promise<int?[]> player_unit_ids)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_6_8", (stack ? 1 : 0) != 0, (object) Unit00468Scene.Mode.Unit00468, (object) playerDeck, (object) player_unit_ids);
  }

  public static void changeScene00468GvgAtk(
    bool stack,
    GvgDeck gvgDeck,
    Promise<int?[]> player_unit_ids)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_6_8", (stack ? 1 : 0) != 0, (object) Unit00468Scene.Mode.Unit00468GvgAtk, (object) gvgDeck, (object) player_unit_ids);
  }

  public static void changeScene00468GvgDef(
    bool stack,
    GvgDeck gvgDeck,
    Promise<int?[]> player_unit_ids)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_6_8", (stack ? 1 : 0) != 0, (object) Unit00468Scene.Mode.Unit00468GvgDef, (object) gvgDeck, (object) player_unit_ids);
  }

  public static void changeScene004682(bool stack, Unit0046Menu.OneFormationInfo info)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_6_8", (stack ? 1 : 0) != 0, (object) Unit00468Scene.Mode.Unit004682, (object) info);
  }

  public static void changeScene0048(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_6_8", (stack ? 1 : 0) != 0, (object) Unit00468Scene.Mode.Unit0048);
  }

  public static void changeScene00481Reinforce(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_6_8", (stack ? 1 : 0) != 0, (object) Unit00468Scene.Mode.Unit00481);
  }

  public static void changeScene00491Evolution(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_6_8", (stack ? 1 : 0) != 0, (object) Unit00468Scene.Mode.Unit00491Evo);
  }

  public static void changeScene00492EvolutionMaterial(bool stack, Unit00492Menu.Param param)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_6_8_2", (stack ? 1 : 0) != 0, (object) Unit00468Scene.Mode.Unit00492EvoMaterial, (object) param);
  }

  public static void changeScene00491Trans(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_6_8", (stack ? 1 : 0) != 0, (object) Unit00468Scene.Mode.Unit00491Trans);
  }

  public static void changeScene00410(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_6_8", (stack ? 1 : 0) != 0, (object) Unit00468Scene.Mode.Unit00410);
  }

  public static void changeScene00411(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_6_8", (stack ? 1 : 0) != 0, (object) Unit00468Scene.Mode.Unit00411);
  }

  public static void changeScene00412(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_6_8", (stack ? 1 : 0) != 0, (object) Unit00468Scene.Mode.Unit00412);
  }

  public static void changeScene00412Gvg(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_6_8", (stack ? 1 : 0) != 0, (object) Unit00468Scene.Mode.Unit00412Gvg);
  }

  public static void changeScene004431(bool stack, Unit004431Menu.Param sendParam)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_6_8", (stack ? 1 : 0) != 0, (object) Unit00468Scene.Mode.Unit004431, (object) sendParam);
  }

  public static void changeScene00414(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_6_8", (stack ? 1 : 0) != 0, (object) Unit00468Scene.Mode.Unit00414);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00468Scene.\u003ConStartSceneAsync\u003Ec__Iterator358()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    Unit00468Scene.Mode mode,
    PlayerDeck playerDeck,
    Promise<int?[]> player_unit_ids)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00468Scene.\u003ConStartSceneAsync\u003Ec__Iterator359()
    {
      mode = mode,
      playerDeck = playerDeck,
      player_unit_ids = player_unit_ids,
      \u003C\u0024\u003Emode = mode,
      \u003C\u0024\u003EplayerDeck = playerDeck,
      \u003C\u0024\u003Eplayer_unit_ids = player_unit_ids,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    Unit00468Scene.Mode mode,
    GvgDeck gvgDeck,
    Promise<int?[]> player_unit_ids)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00468Scene.\u003ConStartSceneAsync\u003Ec__Iterator35A()
    {
      mode = mode,
      gvgDeck = gvgDeck,
      player_unit_ids = player_unit_ids,
      \u003C\u0024\u003Emode = mode,
      \u003C\u0024\u003EgvgDeck = gvgDeck,
      \u003C\u0024\u003Eplayer_unit_ids = player_unit_ids,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(Unit00468Scene.Mode mode, Unit0046Menu.OneFormationInfo info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00468Scene.\u003ConStartSceneAsync\u003Ec__Iterator35B()
    {
      mode = mode,
      info = info,
      \u003C\u0024\u003Emode = mode,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(Unit00468Scene.Mode mode, Unit004431Menu.Param sendParam)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00468Scene.\u003ConStartSceneAsync\u003Ec__Iterator35C()
    {
      mode = mode,
      sendParam = sendParam,
      \u003C\u0024\u003Emode = mode,
      \u003C\u0024\u003EsendParam = sendParam,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(Unit00468Scene.Mode mode, Unit00492Menu.Param param)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00468Scene.\u003ConStartSceneAsync\u003Ec__Iterator35D()
    {
      mode = mode,
      param = param,
      \u003C\u0024\u003Emode = mode,
      \u003C\u0024\u003Eparam = param,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(Unit00468Scene.Mode mode)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00468Scene.\u003ConStartSceneAsync\u003Ec__Iterator35E()
    {
      mode = mode,
      \u003C\u0024\u003Emode = mode,
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene()
  {
    Persist.sortOrder.Flush();
    UnitIcon.ClearCache();
  }

  public void IbtnSort()
  {
    if (!Object.op_Inequality((Object) this.currentMenu, (Object) null))
      return;
    this.currentMenu.IbtnSort();
  }

  public void IbtnBack()
  {
    if (!Object.op_Inequality((Object) this.currentMenu, (Object) null))
      return;
    this.currentMenu.IbtnBack();
  }

  public void IbtnYes()
  {
    if (!Object.op_Inequality((Object) this.currentMenu, (Object) null))
      return;
    this.currentMenu.IbtnYes();
  }

  public void IbtnClearS()
  {
    if (!Object.op_Inequality((Object) this.currentMenu, (Object) null))
      return;
    this.currentMenu.IbtnClearS();
  }

  [DebuggerHidden]
  private IEnumerator changeMenu(UnitMenuBase menu, string title = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00468Scene.\u003CchangeMenu\u003Ec__Iterator35F()
    {
      menu = menu,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u003Ef__this = this
    };
  }

  private void SetTitle(Unit00468Scene.Mode mode)
  {
    switch (mode)
    {
      case Unit00468Scene.Mode.Unit00468:
      case Unit00468Scene.Mode.Unit00468GvgAtk:
      case Unit00468Scene.Mode.Unit00468GvgDef:
        this.textTitle.SetTextLocalize(Consts.GetInstance().TitleUnitEdit);
        break;
      case Unit00468Scene.Mode.Unit004682:
        this.textTitle.SetTextLocalize(Consts.GetInstance().TitleUnitEdit);
        break;
      case Unit00468Scene.Mode.Unit0048:
        this.textTitle.SetTextLocalize(Consts.GetInstance().TitleComposeBaseSelect);
        break;
      case Unit00468Scene.Mode.Unit00481:
        this.textTitle.SetTextLocalize(Consts.GetInstance().unit_004_8_4_reinforce_title);
        break;
      case Unit00468Scene.Mode.Unit00491Evo:
        this.textTitle.SetTextLocalize(Consts.GetInstance().TitleEvolutionSelect);
        break;
      case Unit00468Scene.Mode.Unit00491Trans:
        this.textTitle.SetTextLocalize(Consts.GetInstance().unit_004_9_9_evolution_title);
        break;
      case Unit00468Scene.Mode.Unit00410:
        this.textTitle.SetTextLocalize(Consts.GetInstance().TitleUnitBuy);
        break;
      case Unit00468Scene.Mode.Unit00411:
        this.textTitle.SetTextLocalize(Consts.GetInstance().TitleUnitList);
        break;
      case Unit00468Scene.Mode.Unit00412:
      case Unit00468Scene.Mode.Unit00412Gvg:
        this.textTitle.SetTextLocalize(Consts.GetInstance().TitleEquipGear);
        break;
      case Unit00468Scene.Mode.Unit004431:
        this.textTitle.SetTextLocalize(Consts.GetInstance().TitleEquipGear);
        break;
      case Unit00468Scene.Mode.Unit00486:
        this.textTitle.SetTextLocalize(Consts.GetInstance().TitleComposeMaterialSelect);
        break;
      case Unit00468Scene.Mode.Unit00414:
        this.textTitle.SetTextLocalize(Consts.GetInstance().TitleMaterialUnitList);
        break;
      case Unit00468Scene.Mode.Unit00492EvoMaterial:
        this.textTitle.SetTextLocalize(Consts.GetInstance().TitleEvolutionMaterialSelect);
        break;
    }
  }

  public enum Mode
  {
    Unit00468,
    Unit00468GvgAtk,
    Unit00468GvgDef,
    Unit004682,
    Unit0048,
    Unit00481,
    Unit00491Evo,
    Unit00491Trans,
    Unit00410,
    Unit00411,
    Unit00412,
    Unit00412Gvg,
    Unit004431,
    Unit00486,
    Unit00414,
    Unit00492EvoMaterial,
    Unit00420,
    Max,
  }
}
