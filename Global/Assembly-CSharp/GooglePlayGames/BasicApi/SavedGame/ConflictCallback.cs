// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.SavedGame.ConflictCallback
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace GooglePlayGames.BasicApi.SavedGame
{
  public delegate void ConflictCallback(
    IConflictResolver resolver,
    ISavedGameMetadata original,
    byte[] originalData,
    ISavedGameMetadata unmerged,
    byte[] unmergedData);
}
