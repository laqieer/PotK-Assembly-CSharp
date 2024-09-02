// Decompiled with JetBrains decompiler
// Type: Battle020191Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
  private UISprite princessTypeSprite;
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
  public Touch2NextAuto touchScript;

  private void Awake()
  {
    this.touchScript = ((Component) this).gameObject.AddComponent<Touch2NextAuto>();
  }

  private void Start()
  {
    Singleton<NGSoundManager>.GetInstance().playSE("SE_1023");
    if (!Object.op_Implicit((Object) this.touchScript))
      return;
    this.touchScript.touch2Next.SetActive(false);
    this.Invoke("ShowTouchToNext", 1.5f);
  }

  private void ShowTouchToNext()
  {
    if (!Object.op_Implicit((Object) this.touchScript))
      return;
    this.touchScript.touch2Next.SetActive(true);
  }

  [DebuggerHidden]
  public IEnumerator Init(
    PlayerUnit before,
    PlayerUnit after,
    Dictionary<int, PlayerItem> beforeGears,
    bool fromEarth = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle020191Menu.\u003CInit\u003Ec__Iterator8FA()
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
    return (IEnumerator) new Battle020191Menu.\u003CPlay\u003Ec__Iterator8FB()
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
    return (IEnumerator) new Battle020191Menu.\u003CtoClose\u003Ec__Iterator8FC()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void SetCallback(System.Action callback) => this.onCallback = callback;

  [DebuggerHidden]
  private IEnumerator SetCharacterViewUnit(UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle020191Menu.\u003CSetCharacterViewUnit\u003Ec__Iterator8FD()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  private void SetPrincessType(PlayerUnit unit)
  {
    string str1 = "slc_Princess_";
    string str2;
    switch (unit.unit_type.Enum)
    {
      case UnitTypeEnum.ouki:
        str2 = str1 + "King";
        break;
      case UnitTypeEnum.meiki:
        str2 = str1 + "Life";
        break;
      case UnitTypeEnum.kouki:
        str2 = str1 + "Attack";
        break;
      case UnitTypeEnum.maki:
        str2 = str1 + "Magic";
        break;
      case UnitTypeEnum.syuki:
        str2 = str1 + "Defense";
        break;
      case UnitTypeEnum.syouki:
        str2 = str1 + "Technical";
        break;
      default:
        Debug.LogWarning((object) "�^�C�v�s���v");
        return;
    }
    ((Component) this.princessTypeSprite).gameObject.SetActive(true);
    this.princessTypeSprite.spriteName = str2 + ".png__GUI__princess_type__princess_type_prefab";
    this.princessTypeSprite.width = this.princessTypeSprite.GetAtlasSprite().width;
    this.princessTypeSprite.height = this.princessTypeSprite.GetAtlasSprite().height;
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
