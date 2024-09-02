// Decompiled with JetBrains decompiler
// Type: Earth.EarthDataManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using MiniJSON;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
namespace Earth
{
  public class EarthDataManager : Singleton<EarthDataManager>
  {
    private bool mIsCreate;
    private bool mInit;
    private bool mIsStoryPlayBackMode;
    private EarthQuestEpisode mDisplayEpsodeData;
    private Dictionary<int, EarthCharacter> mCharacters = new Dictionary<int, EarthCharacter>();
    private Dictionary<int, EarthGear> mGears = new Dictionary<int, EarthGear>();
    private Dictionary<int, EarthItem> mItems = new Dictionary<int, EarthItem>();
    private Dictionary<Tuple<int, int>, EarthCharacterIntimate> mCharacterIntimates = new Dictionary<Tuple<int, int>, EarthCharacterIntimate>();
    private Dictionary<int, int> mShopPurchaseHistory = new Dictionary<int, int>();
    private EarthQuestProgress mQuestProgress;
    public BL.ClassValue<Dictionary<MasterDataTable.CommonRewardType, int>> mUserProperties;
    private static readonly string serverDataFormat = "{{\"characters\":[{0}],\"gears\":[{1}],\"supplies\":[{2}],\"character_intimates\":[{3}],\"quest_progress\":{4},\"user_properties\":[{5}],\"shop_purchase_history\":[{6}]}}";
    private static readonly string serverUserPropertiseFormat = "{{\"type_id\":{0},\"quantity\":{1}}}";
    private static readonly string serverShopPurchaseHistoryFormat = "{{\"article_id\":{0},\"quantity\":{1}}}";

    public static int GetAutoIndex()
    {
      byte[] byteArray = Guid.NewGuid().ToByteArray();
      return (int) byteArray[0] << 24 | (int) byteArray[1] << 16 | (int) byteArray[2] << 8 | (int) byteArray[3];
    }

    public bool isCreate => this.mIsCreate;

    public EarthCharacter[] characters => this.mCharacters.Values.ToArray<EarthCharacter>();

    public bool isStoryPlayBackMode
    {
      get => this.mIsStoryPlayBackMode;
      set => this.mIsStoryPlayBackMode = value;
    }

    public EarthQuestEpisode displayEpsodeData
    {
      get => this.mDisplayEpsodeData;
      set => this.mDisplayEpsodeData = value;
    }

    public Dictionary<int, EarthCharacter> characterDict => this.mCharacters;

    public EarthGear[] gears => this.mGears.Values.ToArray<EarthGear>();

    public EarthItem[] items => this.mItems.Values.ToArray<EarthItem>();

    public bool isPrologue => this.questProgress.isPrologue;

    public EarthQuestProgress questProgress => this.mQuestProgress;

    public static void CreateInstance()
    {
      ((Component) Singleton<NGGameDataManager>.GetInstance()).gameObject.AddComponent<EarthDataManager>().mInit = false;
    }

    public static void DestoryInstance()
    {
      Object.Destroy((Object) Singleton<EarthDataManager>.GetInstanceOrNull());
    }

    protected override void Initialize()
    {
    }

    protected override void Finlaize() => base.Finlaize();

    public void EarthDataRevert()
    {
      if (!this.mInit)
        return;
      this.EarthDataReset();
      this.JsonLoad((Dictionary<string, object>) Json.Deserialize(Persist.earthData.Data.data));
      SMManager.UpdateList<PlayerUnit>(this.GetPlayerUnits(), true);
      SMManager.UpdateList<PlayerItem>(this.GetPlayerItems(), true);
      SMManager.UpdateList<PlayerCharacterIntimate>(this.GetPlayerCharacterIntimates(), true);
      this.mInit = true;
    }

    public void EarthDataReset()
    {
      if (!this.mInit)
        return;
      this.mInit = false;
      this.mCharacters.Clear();
      this.mCharacterIntimates.Clear();
      this.mGears.Clear();
      this.mItems.Clear();
      this.mQuestProgress = (EarthQuestProgress) null;
      this.mUserProperties.value.Clear();
      this.mShopPurchaseHistory.Clear();
    }

    [DebuggerHidden]
    public IEnumerator EarthDataInit(
      Action<WebAPI.Response.UserError> userErrorCallback = null)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new EarthDataManager.\u003CEarthDataInit\u003Ec__Iterator8BC()
      {
        userErrorCallback = userErrorCallback,
        \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    private IEnumerator SendSave()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new EarthDataManager.\u003CSendSave\u003Ec__Iterator8BD()
      {
        \u003C\u003Ef__this = this
      };
    }

    public void Save()
    {
      Persist.earthData.Data.data = this.GetServerString();
      Persist.earthData.Flush();
    }

    [DebuggerHidden]
    public IEnumerator SaveAndSendServer()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new EarthDataManager.\u003CSaveAndSendServer\u003Ec__Iterator8BE()
      {
        \u003C\u003Ef__this = this
      };
    }

    private void Create()
    {
      this.mIsCreate = true;
      foreach (EarthJoinCharacter data in ((IEnumerable<EarthJoinCharacter>) MasterData.EarthJoinCharacterList).Where<EarthJoinCharacter>((Func<EarthJoinCharacter, bool>) (x => x.join_logic == EarthJoinLogicType.none)))
      {
        EarthCharacter earthCharacter = EarthCharacter.Create(data, ((IEnumerable<EarthCharacter>) this.characters).Where<EarthCharacter>((Func<EarthCharacter, bool>) (x => x.unit.IsNormalUnit)).Count<EarthCharacter>());
        this.mCharacters.Add(earthCharacter.ID, earthCharacter);
      }
      foreach (EarthQuestClearReward questClearReward in ((IEnumerable<EarthQuestClearReward>) MasterData.EarthQuestClearRewardList).Where<EarthQuestClearReward>((Func<EarthQuestClearReward, bool>) (x => x.episode == null)))
        this.EarthRewardAdd((int) questClearReward.reward_type, questClearReward.reward_id, questClearReward.quantity);
      this.mQuestProgress = EarthQuestProgress.Create();
      this.mUserProperties = new BL.ClassValue<Dictionary<MasterDataTable.CommonRewardType, int>>(new Dictionary<MasterDataTable.CommonRewardType, int>());
      this.ClearCharacterBattleIndex();
      Persist.earthData.Data.data = this.GetServerString();
      Persist.earthData.Flush();
    }

    private void JsonLoad(Dictionary<string, object> json)
    {
      foreach (Dictionary<string, object> json1 in (List<object>) json["characters"])
      {
        EarthCharacter earthCharacter = EarthCharacter.JsonLoad(json1);
        this.mCharacters.Add(earthCharacter.ID, earthCharacter);
      }
      foreach (Dictionary<string, object> json2 in (List<object>) json["gears"])
      {
        EarthGear earthGear = EarthGear.JsonLoad(json2);
        this.mGears.Add(earthGear.ID, earthGear);
      }
      foreach (Dictionary<string, object> json3 in (List<object>) json["supplies"])
      {
        EarthItem earthItem = EarthItem.JsonLoad(json3);
        this.mItems.Add(earthItem.ID, earthItem);
      }
      foreach (Dictionary<string, object> json4 in (List<object>) json["character_intimates"])
      {
        EarthCharacterIntimate characterIntimate = EarthCharacterIntimate.JsonLoad(json4);
        this.mCharacterIntimates.Add(characterIntimate.key, characterIntimate);
      }
      this.mQuestProgress = EarthQuestProgress.JsonLoad((Dictionary<string, object>) json["quest_progress"], new System.Action(this.ClearCharacterBattleIndex));
      this.mUserProperties = new BL.ClassValue<Dictionary<MasterDataTable.CommonRewardType, int>>(new Dictionary<MasterDataTable.CommonRewardType, int>());
      foreach (Dictionary<string, object> dictionary in (List<object>) json["user_properties"])
        this.mUserProperties.value.Add((MasterDataTable.CommonRewardType) (long) dictionary["type_id"], (int) (long) dictionary["quantity"]);
      this.mUserProperties.commit();
      this.mShopPurchaseHistory = new Dictionary<int, int>();
      if (!json.ContainsKey("shop_purchase_history"))
        return;
      foreach (Dictionary<string, object> dictionary in (List<object>) json["shop_purchase_history"])
        this.mShopPurchaseHistory.Add((int) (long) dictionary["article_id"], (int) (long) dictionary["quantity"]);
    }

    public void CreateIntimate(int characterID)
    {
      foreach (EarthCharacter earthCharacter in this.mCharacters.Values)
      {
        if (characterID != earthCharacter.character.ID)
        {
          Tuple<int, int> key = new Tuple<int, int>(characterID >= earthCharacter.character.ID ? earthCharacter.character.ID : characterID, characterID <= earthCharacter.character.ID ? earthCharacter.character.ID : characterID);
          if (!this.mCharacterIntimates.ContainsKey(key))
            this.mCharacterIntimates.Add(key, EarthCharacterIntimate.Create(key.Item1, key.Item2));
        }
      }
    }

    public void EarthCharacterAdd(EarthJoinCharacter joinData)
    {
      EarthCharacter earthCharacter = EarthCharacter.Create(joinData, ((IEnumerable<EarthCharacter>) this.characters).Where<EarthCharacter>((Func<EarthCharacter, bool>) (x => x.unit.IsNormalUnit)).Count<EarthCharacter>());
      this.mCharacters.Add(earthCharacter.ID, earthCharacter);
      SMManager.UpdateList<PlayerUnit>(new PlayerUnit[1]
      {
        earthCharacter.GetPlayerUnit()
      });
    }

    public void EarthCharacterAdd(int characterID, int unitID)
    {
      EarthCharacter earthCharacter = EarthCharacter.Create(characterID, unitID, -1);
      this.mCharacters.Add(earthCharacter.ID, earthCharacter);
      SMManager.UpdateList<PlayerUnit>(new PlayerUnit[1]
      {
        earthCharacter.GetPlayerUnit()
      });
    }

    public Tuple<bool, int> EarthRewardAdd(int item_type, int? item_id, int quantity)
    {
      int num = 0;
      bool flag = false;
      if (item_id.HasValue)
      {
        switch (item_type)
        {
          case 2:
            flag = !this.mItems.Values.Any<EarthItem>((Func<EarthItem, bool>) (x => x.itemID == item_id.Value));
            this.EarthItemAdd(item_id.Value, quantity);
            num = item_id.Value;
            break;
          case 3:
            flag = !this.mGears.Values.Any<EarthGear>((Func<EarthGear, bool>) (x => x.gearID == item_id.Value));
            for (int index = 0; index < quantity; ++index)
              num = this.EarthGearAdd(item_id.Value).ID;
            break;
        }
      }
      else
      {
        try
        {
          MasterDataTable.CommonRewardType key1 = (MasterDataTable.CommonRewardType) item_type;
          if (this.mUserProperties.value.ContainsKey(key1))
          {
            Dictionary<MasterDataTable.CommonRewardType, int> dictionary;
            MasterDataTable.CommonRewardType key2;
            (dictionary = this.mUserProperties.value)[key2 = key1] = dictionary[key2] + quantity;
          }
          else
            this.mUserProperties.value.Add(key1, quantity);
          this.mUserProperties.commit();
        }
        catch (Exception ex)
        {
          Debug.LogException(ex);
        }
      }
      return new Tuple<bool, int>(flag, num);
    }

    public EarthGear EarthGearAdd(int gearID)
    {
      EarthGear earthGear = EarthGear.Create(gearID);
      this.mGears.Add(earthGear.ID, earthGear);
      SMManager.UpdateList<PlayerItem>(new PlayerItem[1]
      {
        earthGear.GetPlayerItem()
      });
      return earthGear;
    }

    public EarthItem EarthItemAdd(int supplyID, int quantity)
    {
      if (this.mItems.ContainsKey(supplyID))
        this.mItems[supplyID].quantity += quantity;
      else
        this.mItems.Add(supplyID, EarthItem.Create(supplyID, quantity));
      SMManager.UpdateList<PlayerItem>(this.mItems[supplyID].GetPlayerItemList().ToArray());
      return this.mItems[supplyID];
    }

    public void ItemSell(int[] gear_id, int[] item_id, int[] quantity, int addMoney)
    {
      int length1 = gear_id.Length;
      for (int index = 0; index < length1; ++index)
        this.EarthGearSub(gear_id[index]);
      int length2 = item_id.Length;
      for (int index = 0; index < length2; ++index)
        this.EarthItemSub(item_id[index], quantity[index]);
      SMManager.UpdateList<PlayerItem>(this.GetPlayerItems(), true);
      Dictionary<MasterDataTable.CommonRewardType, int> dictionary;
      MasterDataTable.CommonRewardType key;
      (dictionary = this.mUserProperties.value)[key = MasterDataTable.CommonRewardType.money] = dictionary[key] + addMoney;
      this.mUserProperties.commit();
      this.Save();
    }

    private void EarthRewardSub(MasterDataTable.CommonRewardType item_type, int[] item_id, int[] quantity)
    {
      int length = item_id.Length;
      for (int index = 0; index < length; ++index)
      {
        switch (item_type)
        {
          case MasterDataTable.CommonRewardType.supply:
            this.EarthItemSub(item_id[index], quantity[index]);
            break;
          case MasterDataTable.CommonRewardType.gear:
            this.EarthGearSub(item_id[index]);
            break;
        }
      }
    }

    private void EarthGearSub(int gearID)
    {
      if (!this.mGears.ContainsKey(gearID))
        return;
      this.mGears[gearID].SetLost();
    }

    private void EarthItemSub(int supplyID, int quantity)
    {
      if (!this.mItems.ContainsKey(supplyID))
        return;
      this.mItems[supplyID].quantity -= quantity;
      if (this.mItems[supplyID].quantity >= 0)
        return;
      this.mItems[supplyID].quantity = 0;
    }

    public PlayerUnit[] GetPlayerUnits()
    {
      return this.mCharacters.Values.Where<EarthCharacter>((Func<EarthCharacter, bool>) (x => !x.isFall && !x.isDesert)).OrderBy<EarthCharacter, int>((Func<EarthCharacter, int>) (x => x.index)).Select<EarthCharacter, PlayerUnit>((Func<EarthCharacter, PlayerUnit>) (x => x.GetPlayerUnit())).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null)).ToArray<PlayerUnit>();
    }

    public PlayerUnit[] GetEnableSortiePlayerUnits()
    {
      return this.mCharacters.Values.Where<EarthCharacter>((Func<EarthCharacter, bool>) (x => !x.isFall && !x.isDesert && !this.questProgress.isImpossibleOfSortie(x.character.ID) && !x.unit.IsMaterialUnit)).OrderBy<EarthCharacter, int>((Func<EarthCharacter, int>) (x => x.index)).Select<EarthCharacter, PlayerUnit>((Func<EarthCharacter, PlayerUnit>) (x => x.GetPlayerUnit())).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null)).ToArray<PlayerUnit>();
    }

    public PlayerUnit GetPlayerUnit(int id)
    {
      return this.mCharacters.ContainsKey(id) ? this.mCharacters[id].GetPlayerUnit() : (PlayerUnit) null;
    }

    public int SetCharacterIndex(int playerunit_id, int index)
    {
      return index > 1 && this.mCharacters.ContainsKey(playerunit_id) ? this.mCharacters[playerunit_id].SetIndex(index) : -1;
    }

    public void ClearCharacterBattleIndex()
    {
      int num = 0;
      foreach (EarthCharacter earthCharacter in (IEnumerable<EarthCharacter>) ((IEnumerable<EarthCharacter>) this.characters).Where<EarthCharacter>((Func<EarthCharacter, bool>) (x => !x.isFall && !x.isDesert)).OrderBy<EarthCharacter, int>((Func<EarthCharacter, int>) (x => x.index)))
        earthCharacter.SetIndex(num++);
      ((IEnumerable<EarthCharacter>) this.characters).ForEach<EarthCharacter>((Action<EarthCharacter>) (x => x.SetBattleIndex(0)));
      int maxCount = this.questProgress.MaximumNumberOfSorties;
      int count = 1;
      foreach (EarthForcedSortieCharacter forcedSortieCharacter1 in this.questProgress.forcedSortieCharacters)
      {
        EarthForcedSortieCharacter forcedSortieCharacter = forcedSortieCharacter1;
        if (((IEnumerable<EarthCharacter>) this.characters).Any<EarthCharacter>((Func<EarthCharacter, bool>) (x => x.character.ID == forcedSortieCharacter.character_id)))
        {
          EarthCharacter earthCharacter = ((IEnumerable<EarthCharacter>) this.characters).Where<EarthCharacter>((Func<EarthCharacter, bool>) (x => x.character.ID == forcedSortieCharacter.character_id)).FirstOrDefault<EarthCharacter>();
          if (earthCharacter != null && !earthCharacter.isFall && !earthCharacter.isDesert)
            earthCharacter.SetBattleIndex(forcedSortieCharacter.sortie_position);
        }
      }
      ((IEnumerable<EarthCharacter>) this.characters).OrderBy<EarthCharacter, int>((Func<EarthCharacter, int>) (x => x.index)).ForEach<EarthCharacter>((Action<EarthCharacter>) (x =>
      {
        if (x.index < 0 || x.battleIndex != 0 || count > maxCount || this.questProgress.isImpossibleOfSortie(x.character.ID))
          return;
        x.SetBattleIndex(count);
        do
        {
          ++count;
        }
        while (this.questProgress.forcedSortieCharacters.Any<EarthForcedSortieCharacter>((Func<EarthForcedSortieCharacter, bool>) (condition => condition.sortie_position == count)));
      }));
    }

    public int SetCharacterBattleIndex(int playerunit_id, int index)
    {
      return index > 1 && this.mCharacters.ContainsKey(playerunit_id) ? this.mCharacters[playerunit_id].SetBattleIndex(index) : -1;
    }

    public bool EquipGear(int playerUnitID, int playerItemID)
    {
      if (!this.mCharacters.ContainsKey(playerUnitID))
        return false;
      List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
      EarthCharacter earthCharacter = this.mCharacters.Values.FirstOrDefault<EarthCharacter>((Func<EarthCharacter, bool>) (x => x.equipeGearID == playerItemID));
      if (earthCharacter != null)
      {
        earthCharacter.EquipGear(0);
        playerUnitList.Add(earthCharacter.GetPlayerUnit());
      }
      this.mCharacters[playerUnitID].EquipGear(playerItemID);
      playerUnitList.Add(this.mCharacters[playerUnitID].GetPlayerUnit());
      SMManager.UpdateList<PlayerUnit>(playerUnitList.ToArray());
      return true;
    }

    public PlayerUnit[] GetEvolutionPattern(int playerUnitID, int[] patternIDs)
    {
      return this.mCharacters.ContainsKey(playerUnitID) ? this.mCharacters[playerUnitID].GetEvolutionPlayerUnits(patternIDs).ToArray() : (PlayerUnit[]) null;
    }

    public Tuple<PlayerUnit, PlayerUnit> EvolutionUnit(
      int playerUnitID,
      int patternID,
      List<int> materailUnitIDs)
    {
      if (this.mCharacters.ContainsKey(playerUnitID))
      {
        if (!materailUnitIDs.All<int>((Func<int, bool>) (x => ((IEnumerable<EarthCharacter>) this.characters).Any<EarthCharacter>((Func<EarthCharacter, bool>) (y => !y.isFall && y.ID == x)))))
          return (Tuple<PlayerUnit, PlayerUnit>) null;
        materailUnitIDs.ForEach((Action<int>) (x => this.mCharacters[x].SetDeath()));
        PlayerUnit playerUnit = CopyUtil.DeepCopy<PlayerUnit>(this.mCharacters[playerUnitID].GetPlayerUnit());
        if (this.mCharacters[playerUnitID].Evolution(patternID))
        {
          SMManager.UpdateList<PlayerUnit>(new PlayerUnit[1]
          {
            this.mCharacters[playerUnitID].GetPlayerUnit()
          });
          SMManager.DeleteList<PlayerUnit>(materailUnitIDs.Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
          return new Tuple<PlayerUnit, PlayerUnit>(playerUnit, this.mCharacters[playerUnitID].GetPlayerUnit());
        }
      }
      return (Tuple<PlayerUnit, PlayerUnit>) null;
    }

    public PlayerItem[] GetPlayerItems()
    {
      return this.mItems.Values.SelectMany<EarthItem, PlayerItem>((Func<EarthItem, IEnumerable<PlayerItem>>) (x => (IEnumerable<PlayerItem>) x.GetPlayerItemList())).Concat<PlayerItem>(this.mGears.Values.Where<EarthGear>((Func<EarthGear, bool>) (x => !x.isLost)).Select<EarthGear, PlayerItem>((Func<EarthGear, PlayerItem>) (x => x.GetPlayerItem()))).ToArray<PlayerItem>();
    }

    public PlayerCharacterIntimate[] GetPlayerCharacterIntimates()
    {
      return this.mCharacterIntimates.Values.Select<EarthCharacterIntimate, PlayerCharacterIntimate>((Func<EarthCharacterIntimate, PlayerCharacterIntimate>) (x => x.GetPlayerCharacterIntimate())).ToArray<PlayerCharacterIntimate>();
    }

    public PlayerCharacterIntimate GetPlayerCharacterIntimate(int characterID1, int characterID2)
    {
      if (characterID1 == characterID2)
        return (PlayerCharacterIntimate) null;
      Tuple<int, int> key = new Tuple<int, int>(characterID1 >= characterID2 ? characterID2 : characterID1, characterID1 <= characterID2 ? characterID2 : characterID1);
      return this.mCharacterIntimates.ContainsKey(key) ? this.mCharacterIntimates[key].GetPlayerCharacterIntimate() : (PlayerCharacterIntimate) null;
    }

    public void SetFavoriteGear(int playeritem_id, bool favorite)
    {
      if (!this.mGears.ContainsKey(playeritem_id))
        return;
      this.mGears[playeritem_id].favorite = favorite;
      SMManager.UpdateList<PlayerItem>(new PlayerItem[1]
      {
        this.mGears[playeritem_id].GetPlayerItem()
      });
    }

    public void SetLostGear(int playeritem_id)
    {
      if (!this.mGears.ContainsKey(playeritem_id))
        return;
      this.mGears[playeritem_id].SetLost();
      SMManager.DeleteList<PlayerItem>(new object[1]
      {
        (object) playeritem_id
      });
    }

    public void SetSupplyBox(Tuple<int, int>[] supplySetDataList)
    {
      IEnumerable<object> first = ((IEnumerable<PlayerItem>) this.GetPlayerItems()).Select<PlayerItem, object>((Func<PlayerItem, object>) (x => (object) x.id));
      IEnumerable<int> source = ((IEnumerable<Tuple<int, int>>) supplySetDataList).Select<Tuple<int, int>, int>((Func<Tuple<int, int>, int>) (x => x.Item1));
      foreach (EarthItem earthItem in this.mItems.Values.Where<EarthItem>((Func<EarthItem, bool>) (x => x.battleSetCount > 0)))
      {
        if (!source.Contains<int>(earthItem.ID))
          earthItem.battleSetCount = 0;
      }
      foreach (Tuple<int, int> supplySetData in supplySetDataList)
      {
        if (this.mItems.ContainsKey(supplySetData.Item1))
          this.mItems[supplySetData.Item1].battleSetCount = supplySetData.Item2;
      }
      PlayerItem[] playerItems = this.GetPlayerItems();
      IEnumerable<object> second = ((IEnumerable<PlayerItem>) playerItems).Select<PlayerItem, object>((Func<PlayerItem, object>) (x => (object) x.id));
      SMManager.UpdateList<PlayerItem>(((IEnumerable<PlayerItem>) playerItems).ToArray<PlayerItem>());
      SMManager.DeleteList<PlayerItem>(first.Except<object>(second).ToArray<object>());
    }

    public int GetProperty(MasterDataTable.CommonRewardType type)
    {
      return this.mUserProperties.value.ContainsKey(type) ? this.mUserProperties.value[type] : 0;
    }

    private string GetServerString()
    {
      return string.Format(EarthDataManager.serverDataFormat, (object) string.Join(",", this.mCharacters.Values.Select<EarthCharacter, string>((Func<EarthCharacter, string>) (x => x.GetSeverString())).ToArray<string>()), (object) string.Join(",", this.mGears.Values.Select<EarthGear, string>((Func<EarthGear, string>) (x => x.GetSeverString())).ToArray<string>()), (object) string.Join(",", this.mItems.Values.Select<EarthItem, string>((Func<EarthItem, string>) (x => x.GetSeverString())).ToArray<string>()), (object) string.Join(",", this.mCharacterIntimates.Values.Select<EarthCharacterIntimate, string>((Func<EarthCharacterIntimate, string>) (x => x.GetSeverString())).ToArray<string>()), (object) this.mQuestProgress.GetSeverString(), (object) string.Join(",", this.mUserProperties.value.Select<KeyValuePair<MasterDataTable.CommonRewardType, int>, string>((Func<KeyValuePair<MasterDataTable.CommonRewardType, int>, string>) (x => string.Format(EarthDataManager.serverUserPropertiseFormat, (object) (int) x.Key, (object) x.Value))).ToArray<string>()), (object) string.Join(",", this.mShopPurchaseHistory.Select<KeyValuePair<int, int>, string>((Func<KeyValuePair<int, int>, string>) (x => string.Format(EarthDataManager.serverShopPurchaseHistoryFormat, (object) x.Key, (object) x.Value))).ToArray<string>()));
    }

    public void GoPrologueScene(bool isCloudAnime = false)
    {
      this.questProgress.GoPrologueScene(isCloudAnime);
    }

    public void PrevPrologueScene()
    {
      --this.questProgress.prologueIndex;
      this.Save();
      if (this.questProgress.isPrologue)
        this.questProgress.GoPrologueScene();
      else
        Mypage051Scene.ChangeScene(false, false);
    }

    public void NextPrologueScene()
    {
      ++this.questProgress.prologueIndex;
      this.Save();
      if (this.questProgress.isPrologue)
      {
        this.questProgress.GoPrologueScene();
      }
      else
      {
        Singleton<CommonRoot>.GetInstance().isLoading = true;
        this.StartCoroutine(this.SaveEndTutorial());
      }
    }

    [DebuggerHidden]
    private IEnumerator SaveEndTutorial()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new EarthDataManager.\u003CSaveEndTutorial\u003Ec__Iterator8BF()
      {
        \u003C\u003Ef__this = this
      };
    }

    public void ShopBuy(EarthShopArticle article, int buyNum)
    {
      if (buyNum < 1)
        return;
      Dictionary<MasterDataTable.CommonRewardType, int> dictionary;
      MasterDataTable.CommonRewardType key;
      (dictionary = this.mUserProperties.value)[key = MasterDataTable.CommonRewardType.money] = dictionary[key] - article.price * buyNum;
      this.mUserProperties.commit();
      this.EarthRewardAdd((int) article.ShopContents.entity_type, new int?(article.ShopContents.entity_id), article.ShopContents.quantity * buyNum);
      if (this.mShopPurchaseHistory.ContainsKey(article.ID))
      {
        Dictionary<int, int> shopPurchaseHistory;
        int id;
        (shopPurchaseHistory = this.mShopPurchaseHistory)[id = article.ID] = shopPurchaseHistory[id] + buyNum;
      }
      else
        this.mShopPurchaseHistory[article.ID] = buyNum;
      this.Save();
    }

    public int GetShopPurchaseCount(int id)
    {
      return this.mShopPurchaseHistory.ContainsKey(id) ? this.mShopPurchaseHistory[id] : 0;
    }

    public void BattleInit(bool isRetreatEnable = true, bool isCloudAnime = false)
    {
      this.Save();
      PlayerDeck playerDeck = new PlayerDeck();
      playerDeck.member_limit = this.questProgress.MaximumNumberOfSorties;
      playerDeck.cost_limit = 999;
      playerDeck.deck_number = 0;
      playerDeck.deck_type_id = 0;
      int?[] nullableArray = new int?[playerDeck.member_limit];
      for (int i = 0; i < playerDeck.member_limit; ++i)
      {
        int num = ((IEnumerable<EarthCharacter>) this.characters).Where<EarthCharacter>((Func<EarthCharacter, bool>) (x => x.battleIndex == i + 1 && !x.isFall)).Select<EarthCharacter, int>((Func<EarthCharacter, int>) (x => x.ID)).FirstOrDefault<int>();
        nullableArray[i] = num != 0 ? new int?(num) : new int?();
      }
      playerDeck.player_unit_ids = nullableArray;
      SMManager.UpdateList<PlayerDeck>(new PlayerDeck[1]
      {
        playerDeck
      });
      List<int> intList = new List<int>();
      foreach (IGrouping<int, EarthBattleStagePanelEvent> source in ((IEnumerable<EarthBattleStagePanelEvent>) MasterData.EarthBattleStagePanelEventList).Where<EarthBattleStagePanelEvent>((Func<EarthBattleStagePanelEvent, bool>) (x => x.stage_id == this.questProgress.currentEpisode.stage.ID)).GroupBy<EarthBattleStagePanelEvent, int>((Func<EarthBattleStagePanelEvent, int>) (x => x.set_group)))
      {
        if (source.Key == 0)
        {
          intList.AddRange(source.Select<EarthBattleStagePanelEvent, int>((Func<EarthBattleStagePanelEvent, int>) (x => x.ID)));
        }
        else
        {
          List<EarthBattleStagePanelEvent> list = source.ToList<EarthBattleStagePanelEvent>();
          int index = NC.Lot(list.Select<EarthBattleStagePanelEvent, int>((Func<EarthBattleStagePanelEvent, int>) (x => x.group_appearance)).ToArray<int>());
          intList.Add(list[index].ID);
        }
      }
      List<Tuple<int, int, int, int>> tupleList1 = new List<Tuple<int, int, int, int>>();
      foreach (int key in intList)
      {
        BattleEarthItemDropTable dropItem = BattleEarthItemDropTable.RandomGetDropItem(MasterData.EarthBattleStagePanelEvent[key].drop_table_id);
        if (dropItem != null)
          tupleList1.Add(new Tuple<int, int, int, int>(key, (int) dropItem.reward_type, !dropItem.reward_id.HasValue ? 0 : dropItem.reward_id.Value, dropItem.quantity));
      }
      List<Tuple<int, int, int, int>> tupleList2 = new List<Tuple<int, int, int, int>>();
      foreach (BattleStageEnemy enemy in this.questProgress.currentEpisode.stage.Enemies)
      {
        if (MasterData.BattleStageEnemyReward[enemy.ID].drop_id > 0)
        {
          BattleEarthItemDropTable dropItem = BattleEarthItemDropTable.RandomGetDropItem(MasterData.BattleStageEnemyReward[enemy.ID].drop_id);
          if (dropItem != null)
            tupleList2.Add(new Tuple<int, int, int, int>(enemy.ID, (int) dropItem.reward_type, !dropItem.reward_id.HasValue ? 0 : dropItem.reward_id.Value, dropItem.quantity));
        }
      }
      BattleInfo info = BattleInfo.MakeBattleInfo(Guid.NewGuid().ToString(), CommonQuestType.Earth, this.questProgress.currentEpisode.ID, 0, 0, 0, (PlayerHelper) null, ((IEnumerable<BattleStageEnemy>) this.questProgress.currentEpisode.stage.Enemies).Select<BattleStageEnemy, int>((Func<BattleStageEnemy, int>) (x => x.ID)).ToArray<int>(), tupleList2.ToArray(), new PlayerUnit[0], new PlayerItem[0], new int[0], new Tuple<int, int, int, int>[0], intList.ToArray(), tupleList1.ToArray(), ((IEnumerable<BattleEarthStageGuest>) this.questProgress.currentEpisode.stage.Guests).Select<BattleEarthStageGuest, int>((Func<BattleEarthStageGuest, int>) (x => x.ID)).ToArray<int>());
      info.isRetreatEnable = isRetreatEnable;
      if (isCloudAnime)
      {
        Singleton<CommonRoot>.GetInstance().isLoading = true;
        Singleton<CommonRoot>.GetInstance().StartCloudAnimEnd((System.Action) (() => Singleton<NGBattleManager>.GetInstance().startBattle(info)));
      }
      else
        Singleton<NGBattleManager>.GetInstance().startBattle(info);
    }

    public Future<BattleEnd> BattleFinish(WebAPI.Request.BattleFinish request, BE be)
    {
      BattleEnd battleEnd = new BattleEnd();
      if (!request.win)
        return Future.Single<BattleEnd>(battleEnd);
      battleEnd.battle_helpers = new PlayerHelper[0];
      battleEnd.boost_stage_clear_rewards = new BattleEndBoost_stage_clear_rewards[0];
      battleEnd.disappeared_player_gears = new int[0];
      battleEnd.drop_unit_entities = new BattleEndDrop_unit_entities[0];
      battleEnd.incr_friend_point = 0;
      battleEnd.mission_complete_rewards = new BattleEndMission_complete_rewards[0];
      battleEnd.player_incr_exp = 0;
      battleEnd.player_mission_results = new PlayerMissionHistory[0];
      battleEnd.player_review = (BattleEndPlayer_review) null;
      battleEnd.score_campaigns = new QuestScoreBattleFinishContext[0];
      battleEnd.stage_clear_rewards = new BattleEndStage_clear_rewards[0];
      battleEnd.unlock_messages = new BattleEndUnlock_messages[0];
      battleEnd.unlock_quests = new UnlockQuest[0];
      battleEnd.before_player_gears = ((IEnumerable<PlayerUnit>) SMManager.Get<PlayerDeck[]>()[0].player_units).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null)).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x.equip_gear_ids[0].HasValue)).Select<PlayerUnit, PlayerItem>((Func<PlayerUnit, PlayerItem>) (x => this.mGears[x.equip_gear_ids[0].Value].GetPlayerItem(true))).ToArray<PlayerItem>();
      battleEnd.before_player_units = ((IEnumerable<PlayerUnit>) SMManager.Get<PlayerDeck[]>()[0].player_units).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null)).Select<PlayerUnit, PlayerUnit>((Func<PlayerUnit, PlayerUnit>) (x => this.mCharacters[x.id].GetPlayerUnit(true))).ToArray<PlayerUnit>();
      Dictionary<int, int> dictionary1 = new Dictionary<int, int>();
      int num1 = 0;
      foreach (BL.Unit unit1 in be.core.playerUnits.value)
      {
        int num2 = 0;
        if (unit1.duelHistory != null)
        {
          foreach (BL.DuelHistory duelHistory in unit1.duelHistory)
          {
            if (duelHistory.inflictTotalDamage > 0)
            {
              int enemy_id = duelHistory.targetUnitID;
              BL.Unit unit2 = be.core.enemyUnits.value.FirstOrDefault<BL.Unit>((Func<BL.Unit, bool>) (x => x.playerUnit.id == enemy_id));
              if (unit2 != null)
              {
                BattleStageEnemyReward stageEnemyReward = MasterData.BattleStageEnemyReward[enemy_id];
                Decimal num3 = (Decimal) duelHistory.inflictTotalDamage / (Decimal) unit2.parameter.Hp;
                num2 += Mathf.Max(1, (int) Decimal.Round((Decimal) stageEnemyReward.exp * num3));
              }
            }
          }
        }
        dictionary1.Add(unit1.playerUnit.id, num2);
      }
      foreach (WebAPI.Request.BattleFinish.EnemyResult enemy in request.enemies)
      {
        if (enemy.dead_count > 0)
        {
          BattleStageEnemyReward stageEnemyReward = MasterData.BattleStageEnemyReward[enemy.enemy_id];
          num1 += stageEnemyReward.money;
        }
      }
      if (!this.mUserProperties.value.ContainsKey(MasterDataTable.CommonRewardType.money))
        this.mUserProperties.value[MasterDataTable.CommonRewardType.money] = 0;
      Dictionary<MasterDataTable.CommonRewardType, int> dictionary2;
      MasterDataTable.CommonRewardType key1;
      (dictionary2 = this.mUserProperties.value)[key1 = MasterDataTable.CommonRewardType.money] = dictionary2[key1] + num1;
      this.mUserProperties.commit();
      foreach (WebAPI.Request.BattleFinish.UnitResult unit3 in request.units)
      {
        WebAPI.Request.BattleFinish.UnitResult unit = unit3;
        if (this.mCharacters.ContainsKey(unit.player_unit_id))
        {
          if (unit.remaining_hp == 0)
          {
            if (this.mCharacters[unit.player_unit_id].equipeGearID != 0)
              this.mGears[this.mCharacters[unit.player_unit_id].equipeGearID].SetLost();
            this.mCharacters[unit.player_unit_id].SetDeath();
          }
          else
          {
            Dictionary<int, int> gearProficiencyExperiences = new Dictionary<int, int>();
            PlayerUnit playerUnit = ((IEnumerable<PlayerUnit>) SMManager.Get<PlayerUnit[]>()).FirstOrDefault<PlayerUnit>((Func<PlayerUnit, bool>) (x => x.id == unit.player_unit_id));
            if (playerUnit.equippedGear != (PlayerItem) null)
            {
              gearProficiencyExperiences.Add(playerUnit.equippedGear.gear.kind.ID, unit.total_damage_count);
              this.mGears[playerUnit.equippedGear.id].AddExperience(unit.total_kill_count);
            }
            this.mCharacters[unit.player_unit_id].AddExperience(!dictionary1.ContainsKey(unit.player_unit_id) ? 0 : dictionary1[unit.player_unit_id], gearProficiencyExperiences);
          }
        }
      }
      List<BattleEndPlayer_character_intimates_in_battle> intimatesInBattleList = new List<BattleEndPlayer_character_intimates_in_battle>();
      foreach (WebAPI.Request.BattleFinish.IntimateResult intimate in request.intimates)
      {
        WebAPI.Request.BattleFinish.IntimateResult intimateResult = intimate;
        Tuple<int, int> key2 = new Tuple<int, int>(intimateResult.character_id >= intimateResult.target_character_id ? intimateResult.target_character_id : intimateResult.character_id, intimateResult.character_id <= intimateResult.target_character_id ? intimateResult.target_character_id : intimateResult.character_id);
        EarthCharacter earthCharacter1 = this.mCharacters.Values.FirstOrDefault<EarthCharacter>((Func<EarthCharacter, bool>) (x => x.character.ID == intimateResult.character_id));
        EarthCharacter earthCharacter2 = this.mCharacters.Values.FirstOrDefault<EarthCharacter>((Func<EarthCharacter, bool>) (x => x.character.ID == intimateResult.target_character_id));
        if (earthCharacter1 != null && earthCharacter2 != null && this.mCharacterIntimates.ContainsKey(key2) && !earthCharacter1.isFall && !earthCharacter2.isFall)
        {
          int experience = this.mCharacterIntimates[key2].experience;
          Tuple<int, int> tuple = this.mCharacterIntimates[key2].AddExperience(intimateResult.exp);
          intimatesInBattleList.Add(new BattleEndPlayer_character_intimates_in_battle()
          {
            target_character_id = intimateResult.target_character_id,
            character_id = intimateResult.character_id,
            before_total_exp = experience,
            after_total_exp = this.mCharacterIntimates[key2].experience,
            after_level = tuple.Item2,
            before_level = tuple.Item1
          });
        }
      }
      battleEnd.player_character_intimates_in_battle = intimatesInBattleList.ToArray();
      foreach (WebAPI.Request.BattleFinish.SupplyResult supply in request.supplies)
      {
        if (this.mItems.ContainsKey(supply.supply_id))
          this.mItems[supply.supply_id].UseItem(supply.use_quantity);
      }
      List<BattleEndDrop_unit_entities> dropUnitEntitiesList = new List<BattleEndDrop_unit_entities>();
      List<BattleEndDrop_gear_entities> dropGearEntitiesList = new List<BattleEndDrop_gear_entities>();
      List<BattleEndDrop_supply_entities> dropSupplyEntitiesList = new List<BattleEndDrop_supply_entities>();
      foreach (GameCore.Reward reward in request.drop_reward.Concat<GameCore.Reward>((IEnumerable<GameCore.Reward>) request.panel_reward))
      {
        Tuple<bool, int> tuple = this.EarthRewardAdd((int) reward.Type, reward.Id <= 0 ? new int?() : new int?(reward.Id), reward.Quantity);
        switch (reward.Type)
        {
          case MasterDataTable.CommonRewardType.unit:
            dropUnitEntitiesList.Add(new BattleEndDrop_unit_entities()
            {
              reward_quantity = reward.Quantity,
              is_new = tuple.Item1,
              reward_id = tuple.Item2 == 0 ? new int?() : new int?(tuple.Item2),
              reward_type_id = (int) reward.Type
            });
            continue;
          case MasterDataTable.CommonRewardType.supply:
            dropSupplyEntitiesList.Add(new BattleEndDrop_supply_entities()
            {
              reward_quantity = reward.Quantity,
              is_new = tuple.Item1,
              reward_id = tuple.Item2 == 0 ? new int?() : new int?(tuple.Item2),
              reward_type_id = (int) reward.Type
            });
            continue;
          case MasterDataTable.CommonRewardType.gear:
            dropGearEntitiesList.Add(new BattleEndDrop_gear_entities()
            {
              reward_quantity = reward.Quantity,
              is_new = tuple.Item1,
              reward_id = tuple.Item2 == 0 ? new int?() : new int?(tuple.Item2),
              reward_type_id = (int) reward.Type
            });
            continue;
          default:
            continue;
        }
      }
      battleEnd.after_player_gears = ((IEnumerable<PlayerUnit>) SMManager.Get<PlayerDeck[]>()[0].player_units).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null)).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x.equip_gear_ids[0].HasValue)).Select<PlayerUnit, PlayerItem>((Func<PlayerUnit, PlayerItem>) (x => this.mGears[x.equip_gear_ids[0].Value].GetPlayerItem())).ToArray<PlayerItem>();
      battleEnd.after_player_units = ((IEnumerable<PlayerUnit>) SMManager.Get<PlayerDeck[]>()[0].player_units).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null)).Select<PlayerUnit, PlayerUnit>((Func<PlayerUnit, PlayerUnit>) (x => this.mCharacters[x.id].GetPlayerUnit())).ToArray<PlayerUnit>();
      battleEnd.drop_unit_entities = dropUnitEntitiesList.ToArray();
      battleEnd.drop_gear_entities = dropGearEntitiesList.ToArray();
      battleEnd.drop_supply_entities = dropSupplyEntitiesList.ToArray();
      foreach (EarthDesertCharacter earthDesertCharacter in ((IEnumerable<EarthDesertCharacter>) MasterData.EarthDesertCharacterList).Where<EarthDesertCharacter>((Func<EarthDesertCharacter, bool>) (x =>
      {
        if (x.desert_logic == EarthJoinLogicType.quest_clear)
        {
          double result = 0.0;
          if (double.TryParse(x.desert_logic_arg, out result))
            return (int) result == this.questProgress.currentEpisode.ID;
        }
        return false;
      })))
      {
        EarthDesertCharacter desertCharactor = earthDesertCharacter;
        if (((IEnumerable<EarthCharacter>) this.characters).Any<EarthCharacter>((Func<EarthCharacter, bool>) (x => x.character.ID == desertCharactor.character_id)))
          ((IEnumerable<EarthCharacter>) this.characters).Where<EarthCharacter>((Func<EarthCharacter, bool>) (x => x.character.ID == desertCharactor.character_id)).FirstOrDefault<EarthCharacter>()?.SetDesert(true);
      }
      foreach (EarthJoinCharacter earthJoinCharacter in ((IEnumerable<EarthJoinCharacter>) MasterData.EarthJoinCharacterList).Where<EarthJoinCharacter>((Func<EarthJoinCharacter, bool>) (x =>
      {
        if (x.join_logic == EarthJoinLogicType.quest_clear)
        {
          double result = 0.0;
          if (double.TryParse(x.join_logic_arg, out result))
            return (int) result == this.questProgress.currentEpisode.ID;
        }
        return false;
      })))
      {
        EarthJoinCharacter joinCharactor = earthJoinCharacter;
        if (joinCharactor.unit.IsNormalUnit && ((IEnumerable<EarthCharacter>) this.characters).Any<EarthCharacter>((Func<EarthCharacter, bool>) (x => x.character.ID == joinCharactor.charctor.ID)))
        {
          EarthCharacter earthCharacter = ((IEnumerable<EarthCharacter>) this.characters).Where<EarthCharacter>((Func<EarthCharacter, bool>) (x => x.character.ID == joinCharactor.charctor.ID)).FirstOrDefault<EarthCharacter>();
          if (earthCharacter != null)
          {
            earthCharacter.AddExperience(joinCharactor.experience, new Dictionary<int, int>());
            earthCharacter.SetDesert(false);
            earthCharacter.SetIndex(((IEnumerable<EarthCharacter>) this.characters).Where<EarthCharacter>((Func<EarthCharacter, bool>) (x => x.unit.IsNormalUnit && !x.isFall && !x.isDesert)).Count<EarthCharacter>());
          }
        }
        else
        {
          EarthCharacter earthCharacter = EarthCharacter.Create(joinCharactor, ((IEnumerable<EarthCharacter>) this.characters).Where<EarthCharacter>((Func<EarthCharacter, bool>) (x => x.unit.IsNormalUnit && !x.isFall && !x.isDesert)).Count<EarthCharacter>());
          this.mCharacters.Add(earthCharacter.ID, earthCharacter);
        }
      }
      foreach (EarthQuestClearReward questClearReward in ((IEnumerable<EarthQuestClearReward>) MasterData.EarthQuestClearRewardList).Where<EarthQuestClearReward>((Func<EarthQuestClearReward, bool>) (x => x.episode != null && x.episode.ID == this.questProgress.currentEpisode.ID)))
        this.EarthRewardAdd((int) questClearReward.reward_type, questClearReward.reward_id, questClearReward.quantity);
      SMManager.UpdateList<PlayerUnit>(this.GetPlayerUnits(), true);
      SMManager.UpdateList<PlayerItem>(this.GetPlayerItems(), true);
      SMManager.UpdateList<PlayerCharacterIntimate>(this.GetPlayerCharacterIntimates(), true);
      this.questProgress.QuestClear();
      this.ClearCharacterBattleIndex();
      return Future.Single<BattleEnd>(battleEnd);
    }

    public List<string> createResourceLoadList()
    {
      List<string> resourceLoadList = new List<string>();
      ResourceManager instance = Singleton<ResourceManager>.GetInstance();
      foreach (EarthCharacter earthCharacter in this.mCharacters.Values)
        resourceLoadList.AddRange((IEnumerable<string>) instance.PathsFromUnit(earthCharacter.unit));
      return resourceLoadList;
    }

    public void SuspendEarthMode()
    {
      Singleton<CommonRoot>.GetInstance().isLoading = true;
      Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
      Singleton<NGSceneManager>.GetInstance().clearStack();
      MypageScene.ChangeScene(false, isEarthSuspend: true);
    }

    [Serializable]
    public class EarthData
    {
      public string data;
    }
  }
}
