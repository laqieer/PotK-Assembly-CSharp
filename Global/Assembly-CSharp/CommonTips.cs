// Decompiled with JetBrains decompiler
// Type: CommonTips
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using UnityEngine;

#nullable disable
public class CommonTips : MonoBehaviour
{
  [SerializeField]
  private UILabel words_txt;

  private void Awake()
  {
    this.words_txt.SetTextLocalize(NC.Lot<TipsTips>(MasterData.TipsTipsList, (Func<TipsTips, int>) (x => x.weight)).description);
  }
}
