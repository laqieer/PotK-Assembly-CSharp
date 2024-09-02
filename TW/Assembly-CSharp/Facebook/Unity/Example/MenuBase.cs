// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Example.MenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Linq;
using UnityEngine;

#nullable disable
namespace Facebook.Unity.Example
{
  internal abstract class MenuBase : ConsoleBase
  {
    private static ShareDialogMode shareDialogMode;

    protected abstract void GetGui();

    protected virtual bool ShowDialogModeSelector() => false;

    protected virtual bool ShowBackButton() => true;

    protected void HandleResult(IResult result)
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

    protected void OnGUI()
    {
    }

    private void AddStatus()
    {
      GUILayout.Space(5f);
      GUILayout.Box("Status: " + this.Status, this.TextStyle, new GUILayoutOption[1]
      {
        GUILayout.MinWidth((float) ConsoleBase.MainWindowWidth)
      });
    }

    private void AddBackButton()
    {
      GUI.enabled = ConsoleBase.MenuStack.Any<string>();
      if (this.Button("Back"))
        this.GoBack();
      GUI.enabled = true;
    }

    private void AddLogButton()
    {
      if (!this.Button("Log"))
        return;
      this.SwitchMenu(typeof (LogView));
    }

    private void AddDialogModeButtons()
    {
      GUILayout.BeginHorizontal(new GUILayoutOption[0]);
      foreach (int mode in Enum.GetValues(typeof (ShareDialogMode)))
        this.AddDialogModeButton((ShareDialogMode) mode);
      GUILayout.EndHorizontal();
    }

    private void AddDialogModeButton(ShareDialogMode mode)
    {
      bool enabled = GUI.enabled;
      GUI.enabled = enabled && mode != MenuBase.shareDialogMode;
      if (this.Button(mode.ToString()))
      {
        MenuBase.shareDialogMode = mode;
        FB.Mobile.ShareDialogMode = mode;
      }
      GUI.enabled = enabled;
    }
  }
}
