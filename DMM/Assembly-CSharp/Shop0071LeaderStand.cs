// Decompiled with JetBrains decompiler
// Type: Shop0071LeaderStand
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class Shop0071LeaderStand : MonoBehaviour
{
  public void SetLeaderCharacter()
  {
    UnitUnit unitUnit = ShopTopUnit.GetShopTopUnit();
    int job_id;
    if (unitUnit == null)
    {
      PlayerUnit displayPlayerUnit = this.GetDisplayPlayerUnit();
      unitUnit = displayPlayerUnit.unit;
      job_id = displayPlayerUnit.job_id;
    }
    else
      job_id = unitUnit.job_UnitJob;
    this.StartCoroutine(this.SetLeaderCharacter(unitUnit.ID, job_id));
  }

  private IEnumerator SetLeaderCharacter(int id, int job_id)
  {
    Shop0071LeaderStand shop0071LeaderStand = this;
    UnitUnit unitdata = MasterData.UnitUnit[id];
    Future<UnityEngine.Sprite> CharacterF = unitdata.LoadSpriteLarge(job_id, 1f);
    IEnumerator e = CharacterF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    UnityEngine.Sprite result = CharacterF.Result;
    shop0071LeaderStand.GetComponent<NGxMaskSprite>().sprite2D = result;
    yield return (object) shop0071LeaderStand.DownloadVoice(unitdata.unitVoicePattern.file_name);
    Singleton<NGSoundManager>.GetInstance().stopVoice();
    Singleton<NGSoundManager>.GetInstance().playVoiceByID(unitdata.unitVoicePattern, 62);
  }

  private IEnumerator DownloadVoice(string vo_number)
  {
    List<string> stringList = new List<string>();
    string platform = Singleton<NGSoundManager>.GetInstance().platform;
    stringList.Add(platform + "/" + vo_number + "_acb");
    stringList.Add(platform + "/" + vo_number + "_awb");
    yield return (object) OnDemandDownload.waitLoadSomethingResource((IEnumerable<string>) stringList, false);
  }

  private PlayerUnit GetDisplayPlayerUnit()
  {
    int mypage_unit_id = MypageUnitUtil.getUnitId();
    if (mypage_unit_id == 0)
      return this.GetDeckLeaderPlayerUnit();
    PlayerUnit playerUnit = ((IEnumerable<PlayerUnit>) SMManager.Get<PlayerUnit[]>()).FirstOrDefault<PlayerUnit>((Func<PlayerUnit, bool>) (x => x.id == mypage_unit_id));
    if (!(playerUnit == (PlayerUnit) null))
      return playerUnit;
    MypageUnitUtil.setDefaultUnitNotFound();
    return this.GetDeckLeaderPlayerUnit();
  }

  private PlayerUnit GetDeckLeaderPlayerUnit()
  {
    PlayerDeck[] playerDeckArray = SMManager.Get<PlayerDeck[]>();
    PlayerUnit playerUnit = ((IEnumerable<PlayerUnit>) playerDeckArray[Persist.deckOrganized.Data.number].player_units).FirstOrDefault<PlayerUnit>();
    if (playerUnit == (PlayerUnit) null)
      playerUnit = ((IEnumerable<PlayerUnit>) playerDeckArray[0].player_units).First<PlayerUnit>();
    return playerUnit;
  }
}
