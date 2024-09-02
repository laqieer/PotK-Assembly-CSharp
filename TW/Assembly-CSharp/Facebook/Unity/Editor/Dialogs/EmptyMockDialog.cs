// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Editor.Dialogs.EmptyMockDialog
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Facebook.MiniJSON;
using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity.Editor.Dialogs
{
  internal class EmptyMockDialog : EditorFacebookMockDialog
  {
    public string EmptyDialogTitle { get; set; }

    protected override float WindowHeight => 500f;

    protected override string DialogTitle => this.EmptyDialogTitle;

    protected override void DoGui()
    {
    }

    protected override void SendSuccessResult()
    {
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      dictionary["did_complete"] = (object) true;
      if (!string.IsNullOrEmpty(this.CallbackID))
        dictionary["callback_id"] = (object) this.CallbackID;
      if (this.Callback == null)
        return;
      this.Callback(Json.Serialize((object) dictionary));
    }
  }
}
