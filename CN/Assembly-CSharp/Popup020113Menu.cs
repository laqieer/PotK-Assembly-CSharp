// Decompiled with JetBrains decompiler
// Type: Popup020113Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup020113Menu : NGMenuBase
{
  private const float LINK_WIDTH = 136f;
  private const float LINK_DEFWIDTH = 136f;
  private const float scale = 1f;
  private System.Action onCallback;
  private GameObject UnitPrefab;
  [SerializeField]
  protected UILabel[] UnitName;
  [SerializeField]
  protected GameObject[] UnitIconObject;

  [DebuggerHidden]
  public virtual IEnumerator Init(QuestHarmonyS quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup020113Menu.\u003CInit\u003Ec__Iterator93F()
    {
      quest = quest,
      \u003C\u0024\u003Equest = quest,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator LoadUnitPrefab()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup020113Menu.\u003CLoadUnitPrefab\u003Ec__Iterator940()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void PopUpTap()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    if (this.onCallback == null)
      return;
    this.onCallback();
  }

  public void SetCallback(System.Action callback) => this.onCallback = callback;

  [DebuggerHidden]
  protected IEnumerator SetUnitPrefab(GameObject setObject, UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup020113Menu.\u003CSetUnitPrefab\u003Ec__Iterator941()
    {
      setObject = setObject,
      unit = unit,
      \u003C\u0024\u003EsetObject = setObject,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator SetCharaIcon(UnitCharacter unit_1, UnitCharacter unit_2)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup020113Menu.\u003CSetCharaIcon\u003Ec__Iterator942()
    {
      unit_1 = unit_1,
      unit_2 = unit_2,
      \u003C\u0024\u003Eunit_1 = unit_1,
      \u003C\u0024\u003Eunit_2 = unit_2,
      \u003C\u003Ef__this = this
    };
  }
}
