// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Editor.Dialogs.MockShareDialog
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;

#nullable disable
namespace Facebook.Unity.Editor.Dialogs
{
  internal class MockShareDialog : EditorFacebookMockDialog
  {
    public string SubTitle { private get; set; }

    protected override string DialogTitle => "Mock " + this.SubTitle + " Dialog";

    protected override void DoGui()
    {
    }

    protected override void SendSuccessResult()
    {
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      if (FB.IsLoggedIn)
        dictionary["postId"] = (object) this.GenerateFakePostID();
      else
        dictionary["did_complete"] = (object) true;
      if (!string.IsNullOrEmpty(this.CallbackID))
        dictionary["callback_id"] = (object) this.CallbackID;
      if (this.Callback == null)
        return;
      this.Callback(new ResultContainer((IDictionary<string, object>) dictionary));
    }

    protected override void SendCancelResult()
    {
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      dictionary["cancelled"] = (object) "true";
      if (!string.IsNullOrEmpty(this.CallbackID))
        dictionary["callback_id"] = (object) this.CallbackID;
      this.Callback(new ResultContainer((IDictionary<string, object>) dictionary));
    }

    private string GenerateFakePostID()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(AccessToken.CurrentAccessToken.UserId);
      stringBuilder.Append('_');
      for (int index = 0; index < 17; ++index)
        stringBuilder.Append(Random.Range(0, 10));
      return stringBuilder.ToString();
    }
  }
}
