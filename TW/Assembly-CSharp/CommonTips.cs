// Decompiled with JetBrains decompiler
// Type: CommonTips
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class CommonTips : MonoBehaviour
{
  [SerializeField]
  private UILabel words_txt;
  [SerializeField]
  private GameObject tips_txt;

  private void Awake()
  {
    this.setWords(NC.Lot<TipsTips>(MasterData.TipsTipsList, (Func<TipsTips, int>) (x => x.weight)).description);
  }

  public void setWords(string text)
  {
    ((Component) this.words_txt).gameObject.SetActive(false);
    this.words_txt.SetTextLocalize(text);
    this.StartCoroutine(this.WaitActive());
  }

  [DebuggerHidden]
  private IEnumerator WaitActive()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CommonTips.\u003CWaitActive\u003Ec__IteratorB43()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void setTipsTxtIsShow(bool isShow = false)
  {
    if (Object.op_Equality((Object) this.tips_txt, (Object) null))
      return;
    this.tips_txt.SetActive(isShow);
  }
}
