// Decompiled with JetBrains decompiler
// Type: BattleUI04CommandPrefab
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI04CommandPrefab : MonoBehaviour
{
  [SerializeField]
  private UILabel label;
  [SerializeField]
  private UI2DSprite icon;
  [SerializeField]
  private UILabel decHP;
  private GameObject elementIcon;
  private CommonElementIcon elementKind;

  private void Awake() => ((Behaviour) this.icon).enabled = false;

  public void Init(AttackStatus attack)
  {
    this.label.SetTextLocalize(attack.magicBullet.name);
    this.decHP.SetTextLocalize(attack.magicBullet.cost);
    this.StartCoroutine(this.loadElementIcon(attack.magicBullet.element));
  }

  [DebuggerHidden]
  private IEnumerator loadElementIcon(CommonElement element)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI04CommandPrefab.\u003CloadElementIcon\u003Ec__Iterator95F()
    {
      element = element,
      \u003C\u0024\u003Eelement = element,
      \u003C\u003Ef__this = this
    };
  }
}
