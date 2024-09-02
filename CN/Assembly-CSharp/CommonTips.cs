// Decompiled with JetBrains decompiler
// Type: CommonTips
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
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
  }

  private void Update()
  {
    if (!Object.op_Equality((Object) this.tips_txt, (Object) null))
      return;
    this.tips_txt = ((Component) this.words_txt).gameObject;
    this.words_txt.SetTextLocalize(NC.Lot<TipsTips>(MasterData.TipsTipsList, (Func<TipsTips, int>) (x => x.weight)).description);
  }

  public void setTipsTxtIsShow(bool isShow = false)
  {
  }
}
