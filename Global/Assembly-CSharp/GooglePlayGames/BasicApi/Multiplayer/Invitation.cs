// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.Multiplayer.Invitation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace GooglePlayGames.BasicApi.Multiplayer
{
  public class Invitation
  {
    private Invitation.InvType mInvitationType;
    private string mInvitationId;
    private Participant mInviter;
    private int mVariant;

    internal Invitation(
      Invitation.InvType invType,
      string invId,
      Participant inviter,
      int variant)
    {
      this.mInvitationType = invType;
      this.mInvitationId = invId;
      this.mInviter = inviter;
      this.mVariant = variant;
    }

    public Invitation.InvType InvitationType => this.mInvitationType;

    public string InvitationId => this.mInvitationId;

    public Participant Inviter => this.mInviter;

    public int Variant => this.mVariant;

    public override string ToString()
    {
      return string.Format("[Invitation: InvitationType={0}, InvitationId={1}, Inviter={2}, Variant={3}]", (object) this.InvitationType, (object) this.InvitationId, (object) this.Inviter, (object) this.Variant);
    }

    public enum InvType
    {
      RealTime,
      TurnBased,
      Unknown,
    }
  }
}
