// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Example.MainMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
namespace Facebook.Unity.Example
{
  internal sealed class MainMenu : MenuBase
  {
    private const int MAX_INFO_COUNT = 3;
    private MainMenu.FEED_LINK_INFO[] linkInfo = new MainMenu.FEED_LINK_INFO[3];
    public string FeedToId = string.Empty;
    public string FeedLink = "https://www.facebook.com/denapok/home";
    public string FeedLinkName = "punk";
    public string FeedLinkCaption = "caption";
    public string FeedLinkDescription = "this is a desc";
    public string FeedPicture = "http://chuantu.biz/t5/22/1469532523x1822614232.jpg";
    public string FeedMediaSource = string.Empty;
    public string FeedActionName = string.Empty;
    public string FeedActionLink = string.Empty;
    public string FeedReference = string.Empty;
    public bool IncludeFeedProperties;
    private Dictionary<string, string[]> FeedProperties = new Dictionary<string, string[]>();
    private int nStatus;
    public string FriendSelectorTitle = "邀请好友一起游戏.";
    public string FriendSelectorMessage = "加入我们，我的游戏好友id是 123456789.";
    private string[] FriendFilterTypes = new string[3]
    {
      "None (default)",
      "app_users",
      "app_non_users"
    };
    private int FriendFilterSelection;
    private List<string> FriendFilterGroupNames = new List<string>();
    private List<string> FriendFilterGroupIDs = new List<string>();
    private int NumFriendFilterGroups;
    public string FriendSelectorData = "{some data to resp.}";
    public string FriendSelectorExcludeIds = string.Empty;
    public string FriendSelectorMax = string.Empty;
    public string DirectRequestTitle = "Invite Facebook friends.";
    public string DirectRequestMessage = "Herp";
    private string DirectRequestTo = string.Empty;
    private string[] strTo;

    protected override bool ShowBackButton() => false;

    protected override void GetGui()
    {
    }

    public new void Awake()
    {
      this.CheckFbInit();
      this.InitLinkInfo();
    }

    public void CheckFbInit()
    {
      if (FB.IsInitialized && false)
        return;
      this.CallFBInitLogic();
    }

    private void CallFBInitLogic()
    {
      try
      {
        FB.Init(new InitDelegate(this.OnInitComplete), new HideUnityDelegate(this.OnHideUnity));
      }
      catch (Exception ex)
      {
        this.Status = ex.Message;
        if (this.nStatus < 2)
          return;
        FB.LogInWithReadPermissions((IEnumerable<string>) new List<string>()
        {
          "public_profile",
          "email",
          "user_friends"
        }, new FacebookDelegate<ILoginResult>(this.HandleLoginResult));
      }
    }

    protected void HandleLoginResult(IResult result)
    {
      if (result == null)
      {
        this.LastResponse = "Null Response\n";
        LogView.AddLog(this.LastResponse);
      }
      else
      {
        this.LastResponseTexture = (Texture2D) null;
        if (!string.IsNullOrEmpty(result.Error))
        {
          this.Status = "Error - Check log for details";
          this.LastResponse = "Error Response:\n" + result.Error;
          LogView.AddLog(result.Error);
        }
        else if (result.Cancelled)
        {
          this.Status = "Cancelled - Check log for details";
          this.LastResponse = "Cancelled Response:\n" + result.RawResult;
          LogView.AddLog(result.RawResult);
        }
        else if (!FB.IsLoggedIn)
          this.LastResponse = "Login cancelled by Player";
        else if (!string.IsNullOrEmpty(result.RawResult))
        {
          this.Status = "Success - Check log for details";
          this.LastResponse = "Success Response:\n" + result.RawResult;
          LogView.AddLog(result.RawResult);
          if (this.nStatus == 2)
          {
            this.CallFBFeed();
          }
          else
          {
            if (this.nStatus != 3)
              return;
            this.CallAppRequestAsFriendSelector();
          }
        }
        else
        {
          this.LastResponse = "Empty Response\n";
          LogView.AddLog(this.LastResponse);
        }
      }
    }

    public void InitLinkInfo()
    {
      Player player = SMManager.Get<Player>();
      for (int index = 0; index < 3; ++index)
      {
        this.linkInfo[index].FeedToId = string.Empty;
        this.linkInfo[index].FeedLink = "https://www.facebook.com/denapok/home";
        this.linkInfo[index].FeedLinkName = "《殺戮魅影》";
        this.linkInfo[index].FeedLinkCaption = "殺戮魅影 Phantom of kill";
        this.linkInfo[index].FeedLinkDescription = "這是我的好友ID：" + player.short_id + "，快到遊戲裏和我一起開啟美少女們的冒險之旅吧！";
        this.linkInfo[index].FeedPicture = "http://official.punktw.91dena.cn/punk-officialinfo/facebook/gonggao6.png";
        if (index == 1)
          this.linkInfo[index].FeedPicture = "http://official.punktw.91dena.cn/punk-officialinfo/facebook/gonggao7.png";
        else if (index == 2)
          this.linkInfo[index].FeedPicture = "http://official.punktw.91dena.cn/punk-officialinfo/facebook/gonggao8.png";
        this.linkInfo[index].FeedMediaSource = string.Empty;
        this.linkInfo[index].FeedActionName = string.Empty;
        this.linkInfo[index].FeedActionLink = string.Empty;
        this.linkInfo[index].FeedReference = string.Empty;
      }
    }

    public void CheckFeed()
    {
      this.nStatus = 2;
      if (FB.IsLoggedIn)
        this.CallFBFeed();
      else
        this.CallFBLogin();
    }

    private void CallFBFeed()
    {
      int index = Random.Range(0, 2);
      if (index >= 3)
        index = 0;
      this.FeedLink = this.linkInfo[index].FeedLink;
      this.FeedLinkName = this.linkInfo[index].FeedLinkName;
      this.FeedLinkCaption = this.linkInfo[index].FeedLinkCaption;
      this.FeedLinkDescription = this.linkInfo[index].FeedLinkDescription;
      this.FeedPicture = this.linkInfo[index].FeedPicture;
      FB.ShareLink(new Uri(this.FeedLink), this.FeedLinkName, this.FeedLinkDescription, new Uri(this.FeedPicture), new FacebookDelegate<IShareResult>(this.HandleShareResult));
    }

    protected void HandleShareResult(IResult result)
    {
      string strTitle = "提醒";
      string empty = string.Empty;
      if (result == null)
      {
        this.LastResponse = "Null Response\n";
        LogView.AddLog(this.LastResponse);
      }
      else
      {
        this.LastResponseTexture = (Texture2D) null;
        if (!string.IsNullOrEmpty(result.Error))
        {
          string strContent = "Fb分享失敗:\n" + result.Error;
          Debug.LogError((object) strContent);
          Singleton<PopupManager>.GetInstance().OpenConfirmWindow(strTitle, strContent, string.Empty);
        }
        else if (result.Cancelled)
        {
          this.Status = "Cancelled - Check log for details";
          this.LastResponse = "Cancelled Response:\n" + result.RawResult;
          LogView.AddLog(result.RawResult);
        }
        else if (!FB.IsLoggedIn)
          this.LastResponse = "Login cancelled by Player";
        else if (!string.IsNullOrEmpty(result.RawResult))
        {
          this.Status = "Success - Check log for details";
          this.LastResponse = "Success Response:\n" + result.RawResult;
          LogView.AddLog(result.RawResult);
        }
        else
        {
          this.LastResponse = "Empty Response\n";
          LogView.AddLog(this.LastResponse);
        }
      }
    }

    public void AppInviteNewApi()
    {
      FB.Mobile.AppInvite(new Uri("https://fb.me/892708710750483"), new Uri("https://scontent-nrt1-1.xx.fbcdn.net/t31.0-8/13698283_851499378319981_8876053449029755810_o.jpg"), new FacebookDelegate<IAppInviteResult>(this.HandleAppInviteResult));
    }

    public void HandleAppInviteResult(IResult result)
    {
      string empty = string.Empty;
      if (!string.IsNullOrEmpty(result.Error) || string.IsNullOrEmpty(result.RawResult))
        return;
      string rawResult = result.RawResult;
      if (!rawResult.Contains("to") || !rawResult.Contains("request"))
        return;
      int startIndex = rawResult.LastIndexOf("\"to\":[");
      int num = rawResult.LastIndexOf("]}");
      rawResult.Substring(startIndex, num - startIndex);
      string str = rawResult.Substring(startIndex + 6, num - startIndex - 6);
      this.DirectRequestTo = str;
      string[] invitations = str.Replace("\"", string.Empty).Split(',');
      int length = invitations.Length;
      this.StartCoroutine(this.RequestFbInviteSuccess(invitations));
    }

    private void CallAppRequestAsFriendSelector()
    {
      int? maxRecipients = new int?();
      if (this.FriendSelectorMax != string.Empty)
      {
        try
        {
          maxRecipients = new int?(int.Parse(this.FriendSelectorMax));
        }
        catch (Exception ex)
        {
          this.Status = ex.Message;
        }
      }
      string[] strArray;
      if (this.FriendSelectorExcludeIds == string.Empty)
        strArray = (string[]) null;
      else
        strArray = this.FriendSelectorExcludeIds.Split(',');
      string[] excludeIds = strArray;
      this.FriendSelectorMessage = "加入我们，我的游戏好友id是 123456789.";
      this.FriendSelectorTitle = "Play with me in a new games.";
      this.FriendSelectorData = "{some data to resp.}";
      FB.AppRequest(this.FriendSelectorMessage, excludeIds: (IEnumerable<string>) excludeIds, maxRecipients: maxRecipients, data: this.FriendSelectorData, title: this.FriendSelectorTitle, callback: new FacebookDelegate<IAppRequestResult>(this.CallbackAppRequestFriendSelector));
    }

    public void CallbackAppRequestFriendSelector(IResult result)
    {
      string strTitle = "提醒";
      if (!string.IsNullOrEmpty(result.Error))
      {
        Singleton<PopupManager>.GetInstance().OpenConfirmWindow(strTitle, result.Error, string.Empty);
      }
      else
      {
        if (string.IsNullOrEmpty(result.RawResult))
          return;
        string rawResult = result.RawResult;
        if (!rawResult.Contains("to") || !rawResult.Contains("request"))
          return;
        int startIndex = rawResult.LastIndexOf("\"to\":\"");
        int num = rawResult.IndexOf("\",");
        rawResult.Substring(startIndex, num - startIndex);
        this.DirectRequestTo = rawResult.Substring(startIndex + 6, num - startIndex - 6);
        try
        {
          this.CallAppRequestAsDirectRequest();
        }
        catch (Exception ex)
        {
        }
      }
    }

    private void CallAppRequestAsDirectRequest()
    {
      this.DirectRequestMessage = "這是我的好友ID：" + SMManager.Get<Player>().short_id + "，快到遊戲裏和我一起開啟美少女們的冒險之旅吧！";
      this.DirectRequestTitle = "Invite Facebook friends.";
      if (this.DirectRequestTo == string.Empty)
        throw new ArgumentException("\"To Comma Ids\" must be specificed", "to");
      FB.AppRequest(this.DirectRequestMessage, (IEnumerable<string>) this.DirectRequestTo.Split(','), data: this.FriendSelectorData, title: this.DirectRequestTitle, callback: new FacebookDelegate<IAppRequestResult>(this.CallbackAppRequestDirectInvite));
    }

    public void CallbackAppRequestDirectInvite(IResult result)
    {
      string strTitle = "提醒";
      if (!string.IsNullOrEmpty(result.Error))
      {
        Singleton<PopupManager>.GetInstance().OpenConfirmWindow(strTitle, result.Error, string.Empty);
      }
      else
      {
        if (string.IsNullOrEmpty(result.RawResult))
          return;
        string rawResult = result.RawResult;
        if (!rawResult.Contains("to") || !rawResult.Contains("request"))
          return;
        int startIndex = rawResult.LastIndexOf("\"to\":\"");
        int num = rawResult.IndexOf("\",");
        rawResult.Substring(startIndex, num - startIndex);
        string str = rawResult.Substring(startIndex + 6, num - startIndex - 6);
        this.DirectRequestTo = str;
        string[] invitations = str.Replace("\"", string.Empty).Split(',');
        int length = invitations.Length;
        this.StartCoroutine(this.RequestFbInviteSuccess(invitations));
      }
    }

    [DebuggerHidden]
    public IEnumerator RequestFbInviteSuccess(string[] invitations)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new MainMenu.\u003CRequestFbInviteSuccess\u003Ec__Iterator4()
      {
        invitations = invitations,
        \u003C\u0024\u003Einvitations = invitations
      };
    }

    public void FbInviteFriend()
    {
      PopupManager.ShowYesNo("提醒", "要發送遊戲邀請到FaceBook嗎？", new System.Action(this.FbConfirmInviteFriend));
    }

    public void FbConfirmInviteFriend()
    {
      this.nStatus = 3;
      if (FB.IsLoggedIn)
        this.CallAppRequestAsFriendSelector();
      else
        this.CallFBLogin();
    }

    private void CallFBLogin()
    {
      FB.LogInWithReadPermissions((IEnumerable<string>) new List<string>()
      {
        "public_profile",
        "email",
        "user_friends"
      }, new FacebookDelegate<ILoginResult>(this.HandleLoginResult));
    }

    private void CallFBLoginForPublish()
    {
      FB.LogInWithPublishPermissions((IEnumerable<string>) new List<string>()
      {
        "publish_actions"
      }, new FacebookDelegate<ILoginResult>(((MenuBase) this).HandleResult));
    }

    private void CallFBLogout() => FB.LogOut();

    private void OnInitComplete()
    {
      this.Status = "Success - Check logk for details";
      this.LastResponse = "Success Response: OnInitComplete Called\n";
      LogView.AddLog("OnInitComplete Called");
    }

    private void OnHideUnity(bool isGameShown)
    {
      this.Status = "Success - Check logk for details";
      this.LastResponse = string.Format("Success Response: OnHideUnity Called {0}\n", (object) isGameShown);
      LogView.AddLog("Is game shown: " + (object) isGameShown);
    }

    public struct FEED_LINK_INFO
    {
      public string FeedToId;
      public string FeedLink;
      public string FeedLinkName;
      public string FeedLinkCaption;
      public string FeedLinkDescription;
      public string FeedPicture;
      public string FeedMediaSource;
      public string FeedActionName;
      public string FeedActionLink;
      public string FeedReference;
    }
  }
}
