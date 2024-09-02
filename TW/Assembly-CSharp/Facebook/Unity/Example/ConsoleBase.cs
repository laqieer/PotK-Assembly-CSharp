// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Example.ConsoleBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
namespace Facebook.Unity.Example
{
  internal class ConsoleBase : MonoBehaviour
  {
    protected const int ButtonHeight = 60;
    private const int DpiScalingFactor = 160;
    protected static int MainWindowWidth = Screen.width - 30;
    protected static int MainWindowFullWidth = Screen.width;
    private static Stack<string> menuStack = new Stack<string>();
    private string status = "Ready";
    private string lastResponse = string.Empty;
    private Vector2 scrollPosition = Vector2.zero;
    private float? scaleFactor;
    private GUIStyle textStyle;
    private GUIStyle buttonStyle;
    private GUIStyle textInputStyle;
    private GUIStyle labelStyle;

    protected static Stack<string> MenuStack
    {
      get => ConsoleBase.menuStack;
      set => ConsoleBase.menuStack = value;
    }

    protected string Status
    {
      get => this.status;
      set => this.status = value;
    }

    protected Texture2D LastResponseTexture { get; set; }

    protected string LastResponse
    {
      get => this.lastResponse;
      set => this.lastResponse = value;
    }

    protected Vector2 ScrollPosition
    {
      get => this.scrollPosition;
      set => this.scrollPosition = value;
    }

    protected float ScaleFactor
    {
      get
      {
        if (!this.scaleFactor.HasValue)
          this.scaleFactor = new float?(Screen.dpi / 160f);
        return this.scaleFactor.Value;
      }
    }

    protected int FontSize => (int) Math.Round((double) this.ScaleFactor * 16.0);

    protected GUIStyle TextStyle
    {
      get
      {
        if (this.textStyle == null)
        {
          this.textStyle = new GUIStyle(GUI.skin.textArea);
          this.textStyle.alignment = (TextAnchor) 0;
          this.textStyle.wordWrap = true;
          this.textStyle.padding = new RectOffset(10, 10, 10, 10);
          this.textStyle.stretchHeight = true;
          this.textStyle.stretchWidth = false;
          this.textStyle.fontSize = this.FontSize;
        }
        return this.textStyle;
      }
    }

    protected GUIStyle ButtonStyle
    {
      get
      {
        if (this.buttonStyle == null)
        {
          this.buttonStyle = new GUIStyle(GUI.skin.button);
          this.buttonStyle.fontSize = this.FontSize;
        }
        return this.buttonStyle;
      }
    }

    protected GUIStyle TextInputStyle
    {
      get
      {
        if (this.textInputStyle == null)
        {
          this.textInputStyle = new GUIStyle(GUI.skin.textField);
          this.textInputStyle.fontSize = this.FontSize;
        }
        return this.textInputStyle;
      }
    }

    protected GUIStyle LabelStyle
    {
      get
      {
        if (this.labelStyle == null)
        {
          this.labelStyle = new GUIStyle(GUI.skin.label);
          this.labelStyle.fontSize = this.FontSize;
        }
        return this.labelStyle;
      }
    }

    protected virtual void Awake() => Application.targetFrameRate = 60;

    protected bool Button(string label)
    {
      return GUILayout.Button(label, this.ButtonStyle, new GUILayoutOption[2]
      {
        GUILayout.MinHeight(60f * this.ScaleFactor),
        GUILayout.MaxWidth((float) ConsoleBase.MainWindowWidth)
      });
    }

    protected void LabelAndTextField(string label, ref string text)
    {
      GUILayout.BeginHorizontal(new GUILayoutOption[0]);
      GUILayout.Label(label, this.LabelStyle, new GUILayoutOption[1]
      {
        GUILayout.MaxWidth(200f * this.ScaleFactor)
      });
      text = GUILayout.TextField(text, this.TextInputStyle, new GUILayoutOption[1]
      {
        GUILayout.MaxWidth((float) (ConsoleBase.MainWindowWidth - 150))
      });
      GUILayout.EndHorizontal();
    }

    protected bool IsHorizontalLayout() => Screen.orientation == 3;

    protected void SwitchMenu(Type menuClass)
    {
      ConsoleBase.menuStack.Push(((object) this).GetType().Name);
      Application.LoadLevel(menuClass.Name);
    }

    protected void GoBack()
    {
      if (!ConsoleBase.menuStack.Any<string>())
        return;
      Application.LoadLevel(ConsoleBase.menuStack.Pop());
    }
  }
}
