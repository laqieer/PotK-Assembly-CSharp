// Decompiled with JetBrains decompiler
// Type: gu3.SocialKit
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
namespace gu3
{
  public class SocialKit : MonoBehaviour
  {
    private const string LIBNAME = "UnitySocialKit";

    private void Awake()
    {
    }

    private void __SocialKit_Share_OnSucceeded(string ptr)
    {
    }

    private void __SocialKit_Share_NotInstalled(string ptr)
    {
    }

    public enum Platform
    {
      Facebook,
      Twitter,
      Line,
      GoogleX,
      Lobi,
    }

    public static class Share
    {
      public static SocialKit.Share.IShareListener Listener { get; set; }

      public static void Send(SocialKit.Platform platform, string message)
      {
      }

      public interface IShareListener
      {
        void OnSucceeded(SocialKit.Platform platform);

        void NotInstalled(SocialKit.Platform platform);
      }
    }
  }
}
