// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Example.DialogShare
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace Facebook.Unity.Example
{
  internal class DialogShare : MenuBase
  {
    private string shareLink = "https://developers.facebook.com/";
    private string shareTitle = "Link Title";
    private string shareDescription = "Link Description";
    private string shareImage = "http://i.imgur.com/j4M7vCO.jpg";
    private string feedTo = string.Empty;
    private string feedLink = "https://developers.facebook.com/";
    private string feedTitle = "Test Title";
    private string feedCaption = "Test Caption";
    private string feedDescription = "Test Description";
    private string feedImage = "http://i.imgur.com/zkYlB.jpg";
    private string feedMediaSource = string.Empty;

    protected override bool ShowDialogModeSelector() => true;

    protected override void GetGui()
    {
      if (this.Button("Share - Link"))
      {
        FacebookDelegate<IShareResult> callback = new FacebookDelegate<IShareResult>(((MenuBase) this).HandleResult);
        FB.ShareLink(new Uri("https://developers.facebook.com/"), string.Empty, string.Empty, callback: callback);
      }
      if (this.Button("Share - Link Photo"))
        FB.ShareLink(new Uri("https://developers.facebook.com/"), "Link Share", "Look I'm sharing a link", new Uri("http://i.imgur.com/j4M7vCO.jpg"), new FacebookDelegate<IShareResult>(((MenuBase) this).HandleResult));
      this.LabelAndTextField("Link", ref this.shareLink);
      this.LabelAndTextField("Title", ref this.shareTitle);
      this.LabelAndTextField("Description", ref this.shareDescription);
      this.LabelAndTextField("Image", ref this.shareImage);
      if (this.Button("Share - Custom"))
        FB.ShareLink(new Uri(this.shareLink), this.shareTitle, this.shareDescription, new Uri(this.shareImage), new FacebookDelegate<IShareResult>(((MenuBase) this).HandleResult));
      if (this.Button("Feed Share - No To"))
        FB.FeedShare(string.Empty, new Uri("https://developers.facebook.com/"), "Test Title", "Test caption", "Test Description", new Uri("http://i.imgur.com/zkYlB.jpg"), string.Empty, new FacebookDelegate<IShareResult>(((MenuBase) this).HandleResult));
      this.LabelAndTextField("To", ref this.feedTo);
      this.LabelAndTextField("Link", ref this.feedLink);
      this.LabelAndTextField("Title", ref this.feedTitle);
      this.LabelAndTextField("Caption", ref this.feedCaption);
      this.LabelAndTextField("Description", ref this.feedDescription);
      this.LabelAndTextField("Image", ref this.feedImage);
      this.LabelAndTextField("Media Source", ref this.feedMediaSource);
      if (!this.Button("Feed Share - Custom"))
        return;
      FB.FeedShare(this.feedTo, !string.IsNullOrEmpty(this.feedLink) ? new Uri(this.feedLink) : (Uri) null, this.feedTitle, this.feedCaption, this.feedDescription, !string.IsNullOrEmpty(this.feedImage) ? new Uri(this.feedImage) : (Uri) null, this.feedMediaSource, new FacebookDelegate<IShareResult>(((MenuBase) this).HandleResult));
    }
  }
}
