// Decompiled with JetBrains decompiler
// Type: IBattlePreparationPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;

public interface IBattlePreparationPopup
{
  DeckInfo[] GetPopupDecks();

  PlayerUnit GetPopupFriend();

  PlayerItem[] GetPopupSupply();

  int[] GetPopupGrayUnitIds();

  void OnChangeDeckMode(bool bCustom);

  void OnPopupClose();

  void OnPopupSortie(DeckInfo deck);

  void OnPopupUnitDetailOpen(PlayerUnit unit, PlayerUnit[] units, bool isFriend);

  void OnPopupDeckEditOpen(DeckInfo deck);

  void OnPopupAutoDeckEdit();

  void OnPopupGearEquipOpen();

  void OnPopupGearRepairOpen();

  void OnPopupSupplyEquipOpen();

  void OnPopupBattleConfigOpen();
}
