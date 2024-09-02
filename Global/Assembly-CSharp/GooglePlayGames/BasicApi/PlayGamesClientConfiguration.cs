// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.PlayGamesClientConfiguration
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.OurUtils;
using System.Collections.Generic;

#nullable disable
namespace GooglePlayGames.BasicApi
{
  public struct PlayGamesClientConfiguration
  {
    public static readonly PlayGamesClientConfiguration DefaultConfiguration = new PlayGamesClientConfiguration.Builder().WithPermissionRationale("Select email address to send to this game or hit cancel to not share.").Build();
    private readonly bool mEnableSavedGames;
    private readonly bool mRequireGooglePlus;
    private readonly string[] mScopes;
    private readonly InvitationReceivedDelegate mInvitationDelegate;
    private readonly MatchDelegate mMatchDelegate;
    private readonly string mPermissionRationale;

    private PlayGamesClientConfiguration(PlayGamesClientConfiguration.Builder builder)
    {
      this.mEnableSavedGames = builder.HasEnableSaveGames();
      this.mInvitationDelegate = builder.GetInvitationDelegate();
      this.mMatchDelegate = builder.GetMatchDelegate();
      this.mPermissionRationale = builder.GetPermissionRationale();
      this.mRequireGooglePlus = builder.HasRequireGooglePlus();
      this.mScopes = builder.getScopes();
    }

    public bool EnableSavedGames => this.mEnableSavedGames;

    public bool RequireGooglePlus => this.mRequireGooglePlus;

    public string[] Scopes => this.mScopes;

    public InvitationReceivedDelegate InvitationDelegate => this.mInvitationDelegate;

    public MatchDelegate MatchDelegate => this.mMatchDelegate;

    public string PermissionRationale => this.mPermissionRationale;

    public class Builder
    {
      private bool mEnableSaveGames;
      private bool mRequireGooglePlus;
      private List<string> mScopes;
      private InvitationReceivedDelegate mInvitationDelegate = (InvitationReceivedDelegate) ((_param0, _param1) => { });
      private MatchDelegate mMatchDelegate = (MatchDelegate) ((_param0, _param1) => { });
      private string mRationale;

      public PlayGamesClientConfiguration.Builder EnableSavedGames()
      {
        this.mEnableSaveGames = true;
        return this;
      }

      public PlayGamesClientConfiguration.Builder RequireGooglePlus()
      {
        this.mRequireGooglePlus = true;
        return this;
      }

      public PlayGamesClientConfiguration.Builder AddOauthScope(string scope)
      {
        if (this.mScopes == null)
          this.mScopes = new List<string>();
        this.mScopes.Add(scope);
        return this;
      }

      public PlayGamesClientConfiguration.Builder WithInvitationDelegate(
        InvitationReceivedDelegate invitationDelegate)
      {
        this.mInvitationDelegate = Misc.CheckNotNull<InvitationReceivedDelegate>(invitationDelegate);
        return this;
      }

      public PlayGamesClientConfiguration.Builder WithMatchDelegate(MatchDelegate matchDelegate)
      {
        this.mMatchDelegate = Misc.CheckNotNull<MatchDelegate>(matchDelegate);
        return this;
      }

      public PlayGamesClientConfiguration.Builder WithPermissionRationale(string rationale)
      {
        this.mRationale = rationale;
        return this;
      }

      public PlayGamesClientConfiguration Build()
      {
        this.mRequireGooglePlus = GameInfo.RequireGooglePlus();
        return new PlayGamesClientConfiguration(this);
      }

      internal bool HasEnableSaveGames() => this.mEnableSaveGames;

      internal bool HasRequireGooglePlus() => this.mRequireGooglePlus;

      internal string[] getScopes()
      {
        return this.mScopes == null ? new string[0] : this.mScopes.ToArray();
      }

      internal MatchDelegate GetMatchDelegate() => this.mMatchDelegate;

      internal InvitationReceivedDelegate GetInvitationDelegate() => this.mInvitationDelegate;

      internal string GetPermissionRationale() => this.mRationale;
    }
  }
}
