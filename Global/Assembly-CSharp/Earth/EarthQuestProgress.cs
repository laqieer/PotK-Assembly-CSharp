// Decompiled with JetBrains decompiler
// Type: Earth.EarthQuestProgress
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;

#nullable disable
namespace Earth
{
  [Serializable]
  public class EarthQuestProgress : BL.ModelBase
  {
    private int mCurrentStageIndex;
    private bool mIsCleared;
    private bool mIsRead;
    private int mPrologueIndex;
    private static readonly string serverDataFormat = "{{\"current_stage_index\":{0},\"is_clear\":{1},\"is_read\":{2},\"prolouge_index\":{3}}}";

    public EarthQuestEpisode currentEpisode
    {
      get
      {
        return ((IEnumerable<EarthQuestEpisode>) MasterData.EarthQuestEpisodeList).Where<EarthQuestEpisode>((Func<EarthQuestEpisode, bool>) (x => x.stage_index == this.mCurrentStageIndex)).FirstOrDefault<EarthQuestEpisode>();
      }
    }

    public List<EarthForcedSortieCharacter> forcedSortieCharacters
    {
      get
      {
        return ((IEnumerable<EarthForcedSortieCharacter>) MasterData.EarthForcedSortieCharacterList).Where<EarthForcedSortieCharacter>((Func<EarthForcedSortieCharacter, bool>) (x => x.episode.ID == this.currentEpisode.ID)).ToList<EarthForcedSortieCharacter>();
      }
    }

    public int forcedSortieCharacterMaxPosition
    {
      get
      {
        return this.forcedSortieCharacters.Count > 0 ? this.forcedSortieCharacters.Max<EarthForcedSortieCharacter>((Func<EarthForcedSortieCharacter, int>) (x => x.sortie_position)) : 1;
      }
    }

    public List<EarthImpossibleOFSortieCharacter> impossibleOfSortieCharacter
    {
      get
      {
        return ((IEnumerable<EarthImpossibleOFSortieCharacter>) MasterData.EarthImpossibleOFSortieCharacterList).Where<EarthImpossibleOFSortieCharacter>((Func<EarthImpossibleOFSortieCharacter, bool>) (x => x.episode.ID == this.currentEpisode.ID)).ToList<EarthImpossibleOFSortieCharacter>();
      }
    }

    public int MaximumNumberOfSorties => this.currentEpisode.stage.Players.Length;

    public bool isRead
    {
      get => this.mIsRead;
      set => this.mIsRead = value;
    }

    public int prologueIndex
    {
      get => this.mPrologueIndex;
      set
      {
        if (value < 1)
          this.mPrologueIndex = 1;
        else
          this.mPrologueIndex = value;
      }
    }

    public bool isPrologue
    {
      get
      {
        return this.mPrologueIndex <= ((IEnumerable<EarthQuestPologue>) MasterData.EarthQuestPologueList).Max<EarthQuestPologue>((Func<EarthQuestPologue, int>) (x => x.number));
      }
    }

    public bool isCleared => this.mIsCleared;

    public static EarthQuestProgress Create()
    {
      EarthQuestProgress earthQuestProgress = new EarthQuestProgress();
      EarthQuestEpisode earthQuestEpisode = ((IEnumerable<EarthQuestEpisode>) MasterData.EarthQuestEpisodeList).OrderBy<EarthQuestEpisode, int>((Func<EarthQuestEpisode, int>) (x => x.stage_index)).First<EarthQuestEpisode>();
      earthQuestProgress.mCurrentStageIndex = earthQuestEpisode.stage_index;
      earthQuestProgress.LoadMasterData();
      earthQuestProgress.mIsCleared = false;
      earthQuestProgress.mIsRead = false;
      earthQuestProgress.mPrologueIndex = 1;
      earthQuestProgress.commit();
      return earthQuestProgress;
    }

    public EarthQuestPologue GetPrologueData()
    {
      return ((IEnumerable<EarthQuestPologue>) MasterData.EarthQuestPologueList).FirstOrDefault<EarthQuestPologue>((Func<EarthQuestPologue, bool>) (x => x.number == this.mPrologueIndex));
    }

    public void GoPrologueScene(bool isCloudAnime = false)
    {
      EarthQuestPologue prologueData = this.GetPrologueData();
      Singleton<CommonRoot>.GetInstance().isLoading = true;
      string type = prologueData.type;
      if (type == null)
        return;
      // ISSUE: reference to a compiler-generated field
      if (EarthQuestProgress.\u003C\u003Ef__switch\u0024map26 == null)
      {
        // ISSUE: reference to a compiler-generated field
        EarthQuestProgress.\u003C\u003Ef__switch\u0024map26 = new Dictionary<string, int>(2)
        {
          {
            "battle",
            0
          },
          {
            "movie",
            1
          }
        };
      }
      int num;
      // ISSUE: reference to a compiler-generated field
      if (!EarthQuestProgress.\u003C\u003Ef__switch\u0024map26.TryGetValue(type, out num))
        return;
      if (num != 0)
      {
        if (num != 1)
          return;
        Prologue0501Scene.ChangeScene(false, isCloudAnime);
      }
      else
        Singleton<CommonRoot>.GetInstance().StartCoroutine(this.ChangeBattle(isCloudAnime));
    }

    [DebuggerHidden]
    private IEnumerator ChangeBattle(bool isCloudAnime)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new EarthQuestProgress.\u003CChangeBattle\u003Ec__Iterator8C0()
      {
        isCloudAnime = isCloudAnime,
        \u003C\u0024\u003EisCloudAnime = isCloudAnime
      };
    }

    public void CheckNextStage()
    {
      int nextStageIndex = this.mCurrentStageIndex + 1;
      EarthQuestEpisode earthQuestEpisode = ((IEnumerable<EarthQuestEpisode>) MasterData.EarthQuestEpisodeList).Where<EarthQuestEpisode>((Func<EarthQuestEpisode, bool>) (x => nextStageIndex == x.stage_index)).FirstOrDefault<EarthQuestEpisode>();
      if (earthQuestEpisode != null)
      {
        this.mCurrentStageIndex = earthQuestEpisode.stage_index;
        this.LoadMasterData();
        this.mIsRead = false;
        this.mIsCleared = false;
        this.commit();
      }
      else
      {
        if (this.mIsCleared)
          return;
        this.mIsCleared = true;
        this.commit();
      }
    }

    public void QuestClear() => this.CheckNextStage();

    public bool isImpossibleOfSortie(int character_id)
    {
      return this.impossibleOfSortieCharacter.Any<EarthImpossibleOFSortieCharacter>((Func<EarthImpossibleOFSortieCharacter, bool>) (x => x.character_id == character_id));
    }

    public string GetSeverString()
    {
      return string.Format(EarthQuestProgress.serverDataFormat, (object) this.mCurrentStageIndex, (object) (!this.mIsCleared ? 0 : 1), (object) (!this.mIsRead ? 0 : 1), (object) this.mPrologueIndex);
    }

    public static EarthQuestProgress JsonLoad(
      Dictionary<string, object> json,
      System.Action nextStageOpenCallback)
    {
      EarthQuestProgress earthQuestProgress = new EarthQuestProgress();
      earthQuestProgress.mCurrentStageIndex = (int) (long) json["current_stage_index"];
      earthQuestProgress.mIsCleared = (int) (long) json["is_clear"] != 0;
      if (json.ContainsKey("is_read"))
        earthQuestProgress.mIsRead = (int) (long) json["is_read"] != 0;
      earthQuestProgress.mPrologueIndex = !json.ContainsKey("prolouge_index") ? 1 : (int) (long) json["prolouge_index"];
      earthQuestProgress.LoadMasterData();
      if (earthQuestProgress.isCleared)
      {
        earthQuestProgress.CheckNextStage();
        if (!earthQuestProgress.isCleared)
          nextStageOpenCallback();
      }
      return earthQuestProgress;
    }

    private void LoadMasterData()
    {
      if (this.currentEpisode == null)
        return;
      MasterData.LoadBattleStageEnemy(this.currentEpisode.stage);
      MasterData.LoadBattleMapLandform(this.currentEpisode.stage.map);
    }

    public void SetCurrentIndex(int index)
    {
      this.mCurrentStageIndex = index;
      this.LoadMasterData();
      this.mIsCleared = false;
      this.mIsRead = false;
      this.commit();
    }
  }
}
