// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.PlayGamesUserProfile
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GooglePlayGames.OurUtils;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SocialPlatforms;

#nullable disable
namespace GooglePlayGames
{
  public class PlayGamesUserProfile : IUserProfile
  {
    private string mDisplayName;
    private string mPlayerId;
    private string mAvatarUrl;
    private volatile bool mImageLoading;
    private Texture2D mImage;

    internal PlayGamesUserProfile(string displayName, string playerId, string avatarUrl)
    {
      this.mDisplayName = displayName;
      this.mPlayerId = playerId;
      this.mAvatarUrl = avatarUrl;
      this.mImageLoading = false;
    }

    protected void ResetIdentity(string displayName, string playerId, string avatarUrl)
    {
      this.mDisplayName = displayName;
      this.mPlayerId = playerId;
      if (this.mAvatarUrl != avatarUrl)
      {
        this.mImage = (Texture2D) null;
        this.mAvatarUrl = avatarUrl;
      }
      this.mImageLoading = false;
    }

    public string userName => this.mDisplayName;

    public string id => this.mPlayerId;

    public bool isFriend => true;

    public UserState state => (UserState) 0;

    public Texture2D image
    {
      get
      {
        if (!this.mImageLoading && Object.op_Equality((Object) this.mImage, (Object) null) && !string.IsNullOrEmpty(this.AvatarURL))
        {
          Debug.Log((object) ("Starting to load image: " + this.AvatarURL));
          this.mImageLoading = true;
          PlayGamesHelperObject.RunCoroutine(this.LoadImage());
        }
        return this.mImage;
      }
    }

    public string AvatarURL => this.mAvatarUrl;

    [DebuggerHidden]
    internal IEnumerator LoadImage()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new PlayGamesUserProfile.\u003CLoadImage\u003Ec__Iterator10D()
      {
        \u003C\u003Ef__this = this
      };
    }

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if (object.ReferenceEquals((object) this, obj))
        return true;
      return obj is PlayGamesUserProfile gamesUserProfile && StringComparer.Ordinal.Equals(this.mPlayerId, gamesUserProfile.mPlayerId);
    }

    public override int GetHashCode()
    {
      return typeof (PlayGamesUserProfile).GetHashCode() ^ this.mPlayerId.GetHashCode();
    }

    public override string ToString()
    {
      return string.Format("[Player: '{0}' (id {1})]", (object) this.mDisplayName, (object) this.mPlayerId);
    }
  }
}
