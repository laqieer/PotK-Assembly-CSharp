// Decompiled with JetBrains decompiler
// Type: UnitSortAndFilterTabButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class UnitSortAndFilterTabButton : UnitSortAndFilterButton
{
  [SerializeField]
  private UILabel TextSelect;

  public void SetText(string title) => this.TextSelect.SetTextLocalize(title);

  public void SetTextColor(Color col) => this.TextSelect.color = col;
}
