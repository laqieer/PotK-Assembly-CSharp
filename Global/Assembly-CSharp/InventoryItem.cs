// Decompiled with JetBrains decompiler
// Type: InventoryItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;

#nullable disable
public class InventoryItem
{
  public PlayerItem Item;
  public ItemIcon icon;
  public bool select;
  public int index;
  public int selectCount;
  public bool Gray;
  public bool removeButton;

  public InventoryItem(PlayerItem item) => this.Item = item;

  public InventoryItem Copy()
  {
    return new InventoryItem(this.Item)
    {
      select = this.select
    };
  }
}
