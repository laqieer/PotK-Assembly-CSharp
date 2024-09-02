// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.SavedGame.ISavedGameClient
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace GooglePlayGames.BasicApi.SavedGame
{
  public interface ISavedGameClient
  {
    void OpenWithAutomaticConflictResolution(
      string filename,
      DataSource source,
      ConflictResolutionStrategy resolutionStrategy,
      Action<SavedGameRequestStatus, ISavedGameMetadata> callback);

    void OpenWithManualConflictResolution(
      string filename,
      DataSource source,
      bool prefetchDataOnConflict,
      ConflictCallback conflictCallback,
      Action<SavedGameRequestStatus, ISavedGameMetadata> completedCallback);

    void ReadBinaryData(
      ISavedGameMetadata metadata,
      Action<SavedGameRequestStatus, byte[]> completedCallback);

    void ShowSelectSavedGameUI(
      string uiTitle,
      uint maxDisplayedSavedGames,
      bool showCreateSaveUI,
      bool showDeleteSaveUI,
      Action<SelectUIStatus, ISavedGameMetadata> callback);

    void CommitUpdate(
      ISavedGameMetadata metadata,
      SavedGameMetadataUpdate updateForMetadata,
      byte[] updatedBinaryData,
      Action<SavedGameRequestStatus, ISavedGameMetadata> callback);

    void FetchAllSavedGames(
      DataSource source,
      Action<SavedGameRequestStatus, List<ISavedGameMetadata>> callback);

    void Delete(ISavedGameMetadata metadata);
  }
}
