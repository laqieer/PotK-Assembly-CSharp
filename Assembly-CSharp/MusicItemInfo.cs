﻿// Decompiled with JetBrains decompiler
// Type: MusicItemInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;

public class MusicItemInfo
{
  public MusicScrollItem MusicScrollItem;
  public Music Music;
  public bool IsNew;
  public MusitStatus MusitStatus;

  public void Set(Music music, bool isNew, MusitStatus musitStatus)
  {
    this.Music = music;
    this.IsNew = isNew;
    this.MusitStatus = musitStatus;
  }
}
