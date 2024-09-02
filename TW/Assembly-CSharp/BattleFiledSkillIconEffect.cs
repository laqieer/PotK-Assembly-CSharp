// Decompiled with JetBrains decompiler
// Type: BattleFiledSkillIconEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleFiledSkillIconEffect : MonoBehaviour
{
  [SerializeField]
  private Renderer renderer;
  [SerializeField]
  private Animator animator;
  private Material cpyMaterial;

  public void SetSkillIcon(BattleskillSkill skill) => this.StartCoroutine(this.set(skill));

  [DebuggerHidden]
  private IEnumerator set(BattleskillSkill skill)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleFiledSkillIconEffect.\u003Cset\u003Ec__IteratorA61()
    {
      skill = skill,
      \u003C\u0024\u003Eskill = skill,
      \u003C\u003Ef__this = this
    };
  }
}
