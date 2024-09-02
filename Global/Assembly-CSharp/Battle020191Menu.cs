// Decompiled with JetBrains decompiler
// Type: Battle020191Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle020191Menu : NGMenuBase
{
  [SerializeField]
  protected UILabel TxtCharacterName30;
  [SerializeField]
  protected UILabel TxtLvAfter30;
  [SerializeField]
  protected UILabel TxtLvBefore30;
  [SerializeField]
  protected UILabel TxtSkillName26;
  [SerializeField]
  protected UILabel TxtSkilleffect0124;
  private bool isSkip;
  private bool isRunning = true;
  private System.Action onCallback;
  private bool skillLearn;
  public GameObject SkillBox;
  public GameObject GearIncrementalIcon;
  [SerializeField]
  private GameObject CharaSprite;
  [SerializeField]
  private UI2DSprite UnitSkillSprite;
  [SerializeField]
  private UILabel princessTypeLabel;
  [SerializeField]
  private UILabel[] parameterLabels;
  [SerializeField]
  private GameObject[] parameterMaxStar;
  [SerializeField]
  private GameObject[] parameterGauges;
  [SerializeField]
  private Battle020191Menu.GaugeObject[] gaugeObjectList;
  private List<Battle020191Menu.PlayData> PlayList = new List<Battle020191Menu.PlayData>();
  private float[] gearIncrementals = new float[8];

  private void Start() => Singleton<NGSoundManager>.GetInstance().playSE("SE_1023");

  [DebuggerHidden]
  public IEnumerator Init(
    PlayerUnit before,
    PlayerUnit after,
    Dictionary<int, PlayerItem> beforeGears,
    bool fromEarth = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle020191Menu.\u003CInit\u003Ec__Iterator6E9()
    {
      before = before,
      beforeGears = beforeGears,
      after = after,
      fromEarth = fromEarth,
      \u003C\u0024\u003Ebefore = before,
      \u003C\u0024\u003EbeforeGears = beforeGears,
      \u003C\u0024\u003Eafter = after,
      \u003C\u0024\u003EfromEarth = fromEarth,
      \u003C\u003Ef__this = this
    };
  }

  private void SetParam(Battle020191Menu.ParameterType type, int beforeState, int afterState)
  {
    UILabel parameterLabel = this.parameterLabels[(int) type];
    if (beforeState < afterState)
      parameterLabel.color = Color.yellow;
    parameterLabel.SetTextLocalize(afterState);
    this.PlayList.Add(new Battle020191Menu.PlayData()
    {
      type = type,
      before = beforeState,
      after = afterState
    });
  }

  private float GetGaugeRatio(Battle020191Menu.ParameterType type, int value)
  {
    float num = 99f;
    if (type == Battle020191Menu.ParameterType.HP)
      num *= 2f;
    return (float) value / num;
  }

  [DebuggerHidden]
  private IEnumerator Play()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle020191Menu.\u003CPlay\u003Ec__Iterator6EA()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnScreen()
  {
    if (this.isRunning && !this.isSkip)
      this.isSkip = true;
    else
      this.StartCoroutine(this.toClose());
  }

  [DebuggerHidden]
  private IEnumerator toClose()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle020191Menu.\u003CtoClose\u003Ec__Iterator6EB()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void SetCallback(System.Action callback) => this.onCallback = callback;

  [DebuggerHidden]
  private IEnumerator SetCharacterViewUnit(UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle020191Menu.\u003CSetCharacterViewUnit\u003Ec__Iterator6EC()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  private void SetPrincessType(PlayerUnit unit)
  {
    this.princessTypeLabel.SetText(Consts.Lookup(unit.unit_type.Enum.TypeNameKey()));
  }

  [Serializable]
  private struct GaugeObject
  {
    public GameObject BlueGauge;
    public GameObject YellowGauge;
    public GameObject DirUpper;
    public UILabel TxtUppt;
    public GameObject GearIncrementalUp;
    public GameObject GearIncrementalDown;
  }

  private enum ParameterType
  {
    HP,
    STR,
    INT,
    VIT,
    MND,
    AGI,
    DEX,
    LUK,
    SIZE,
  }

  private class PlayData
  {
    public Battle020191Menu.ParameterType type;
    public int before;
    public int after;
  }
}
