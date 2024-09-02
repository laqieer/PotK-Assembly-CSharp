// Decompiled with JetBrains decompiler
// Type: BattleUI55ResultMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI55ResultMenu : ResultMenuBase
{
  private const float LINK_WIDTH = 120f;
  private const float LINK_DEFWIDTH = 136f;
  private const float scale = 0.882352948f;
  private const int cell6Width = 104;
  private const int cell6Height = 274;
  private const int cell6 = 6;
  private const int cell5Width = 122;
  private const int cell5Height = 316;
  private const int cell5 = 5;
  [SerializeField]
  protected UILabel TxtSubTitle24;
  [SerializeField]
  protected UILabel TxtGetZenie28;
  [SerializeField]
  private GameObject Title;
  [SerializeField]
  private GameObject Scene_Result;
  [SerializeField]
  private UIGrid grid;
  private BattleInfo info;
  private BattleEnd result;
  private List<GameObject> mResultUnitPanels = new List<GameObject>();
  private static readonly Vector3 cell6Scale = new Vector3(0.85f, 0.85f, 1f);
  private static readonly Vector3 cell5Scale = new Vector3(1f, 1f, 1f);

  public override void OnDestroy()
  {
    this.mResultUnitPanels.Clear();
    base.OnDestroy();
  }

  private void Awake() => this.mResultUnitPanels.Clear();

  [DebuggerHidden]
  public override IEnumerator Init(BattleInfo info, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI55ResultMenu.\u003CInit\u003Ec__Iterator77E()
    {
      info = info,
      result = result,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  public void SetZenie(int zenie) => this.TxtGetZenie28.SetTextLocalize(zenie);

  public void SetQuestName(string txt) => this.TxtSubTitle24.SetTextLocalize(txt);

  [DebuggerHidden]
  public override IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI55ResultMenu.\u003CRun\u003Ec__Iterator77F()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator OnFinish()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI55ResultMenu.\u003COnFinish\u003Ec__Iterator780()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitObjects()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI55ResultMenu.\u003CInitObjects\u003Ec__Iterator781()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator ShowUnitEXPForEarth()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI55ResultMenu.\u003CShowUnitEXPForEarth\u003Ec__Iterator782()
    {
      \u003C\u003Ef__this = this
    };
  }

  private delegate IEnumerator Runner();
}
