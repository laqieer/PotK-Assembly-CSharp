// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Editor.Dialogs.EmptyMockDialog
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity.Editor.Dialogs
{
  internal class EmptyMockDialog : EditorFacebookMockDialog
  {
    public string EmptyDialogTitle { get; set; }

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
      this.Callback(new ResultContainer((IDictionary<string, object>) dictionary));
    }
  }
}
