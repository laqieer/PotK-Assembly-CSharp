// Decompiled with JetBrains decompiler
// Type: Battle020221Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle020221Menu : NGMenuBase
{
  private const float LINK_WIDTH = 136f;
  private const float LINK_DEFWIDTH = 136f;
  private const float scale = 1f;
  [SerializeField]
  protected UILabel TxtCharaname22;
  [SerializeField]
  protected UILabel TxtCharaname222;
  [SerializeField]
  protected UILabel TxtDescription24;
  [SerializeField]
  protected UILabel TxtLvAfter26;
  [SerializeField]
  protected UILabel TxtLvbefore26;
  [SerializeField]
  protected UILabel TxtPopuptitle26;
  private GameObject UnitPrefab;
  public GameObject chara1;
  public GameObject chara2;
  private System.Action onCallback;

  public void Init(int id1, int id2, string name1, string name2, int beforeLv, int afterLv)
  {
    this.TxtLvbefore26.SetTextLocalize(beforeLv);
    this.TxtLvAfter26.SetTextLocalize(afterLv);
    this.TxtCharaname22.SetTextLocalize(name1);
    this.TxtCharaname222.SetTextLocalize(name2);
    this.StartCoroutine(this.SetCharaIcon(id1, id2));
  }

  [DebuggerHidden]
  private IEnumerator LoadUnitPrefab()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle020221Menu.\u003CLoadUnitPrefab\u003Ec__Iterator833()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetUnitPrefab(GameObject setObject, UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle020221Menu.\u003CSetUnitPrefab\u003Ec__Iterator834()
    {
      setObject = setObject,
      unit = unit,
      \u003C\u0024\u003EsetObject = setObject,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetCharaIcon(int id1, int id2)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle020221Menu.\u003CSetCharaIcon\u003Ec__Iterator835()
    {
      id1 = id1,
      id2 = id2,
      \u003C\u0024\u003Eid1 = id1,
      \u003C\u0024\u003Eid2 = id2,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnScreen()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    if (this.onCallback == null)
      return;
    this.onCallback();
  }

  public void SetCallback(System.Action callback) => this.onCallback = callback;
}
