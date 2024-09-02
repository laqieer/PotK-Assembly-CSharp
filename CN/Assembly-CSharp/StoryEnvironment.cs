// Decompiled with JetBrains decompiler
// Type: StoryEnvironment
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore.LispCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UniLinq;
using UnityEngine;

#nullable disable
public class StoryEnvironment
{
  private float r;
  private float g;
  private float b;
  private float fromAlpha;
  private float toAlpha;
  private float standPos;
  private GameObject obj;
  public static bool IsNoWaitOnChoise;
  private Dictionary<string, object> scriptEnv = new Dictionary<string, object>();
  private Lisp engine;
  private List<StoryBlock> storyBlocks;
  private StoryExecuter executer;
  private int currentIdx;
  private string nextLabel;

  private int? lispNumberToInt(object a)
  {
    Decimal? nullable = a as Decimal?;
    return !nullable.HasValue ? new int?() : new int?((int) nullable.Value);
  }

  private float? lispNumberToFloat(object a)
  {
    Decimal? nullable = a as Decimal?;
    return !nullable.HasValue ? new float?() : new float?((float) nullable.Value);
  }

  private string lispStringToString(object a)
  {
    return !(a is SExpString sexpString) ? (string) null : sexpString.strValue;
  }

  private void defineVariables()
  {
    this.engine.setq("on", (object) new bool?(true));
    this.engine.setq("off", (object) new bool?(false));
  }

  private static void colorFromName(string name, out float r, out float g, out float b)
  {
    string key = name;
    if (key != null)
    {
      // ISSUE: reference to a compiler-generated field
      if (StoryEnvironment.\u003C\u003Ef__switch\u0024map15 == null)
      {
        // ISSUE: reference to a compiler-generated field
        StoryEnvironment.\u003C\u003Ef__switch\u0024map15 = new Dictionary<string, int>(6)
        {
          {
            "black",
            0
          },
          {
            "white",
            1
          },
          {
            "red",
            2
          },
          {
            "green",
            3
          },
          {
            "blue",
            4
          },
          {
            "pink",
            5
          }
        };
      }
      int num;
      // ISSUE: reference to a compiler-generated field
      if (StoryEnvironment.\u003C\u003Ef__switch\u0024map15.TryGetValue(key, out num))
      {
        switch (num)
        {
          case 0:
            r = 0.0f;
            g = 0.0f;
            b = 0.0f;
            return;
          case 1:
            r = 1f;
            g = 1f;
            b = 1f;
            return;
          case 2:
            r = 1f;
            g = 0.0f;
            b = 0.0f;
            return;
          case 3:
            r = 0.0f;
            g = 1f;
            b = 0.0f;
            return;
          case 4:
            r = 0.0f;
            g = 0.0f;
            b = 1f;
            return;
          case 5:
            r = 1f;
            g = 0.75f;
            b = 0.8f;
            return;
        }
      }
    }
    r = 0.2f;
    g = 0.0f;
    b = 0.0f;
  }

  private void defunCommands()
  {
    this.engine.defun("serif", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      if (nullable.Value == 0)
      {
        this.current.text.pos = TextBlock.Position.BOTTOM;
      }
      else
      {
        this.current.text.pos = TextBlock.Position.TOP;
        this.executer.openTopLabelObject();
      }
      return args[0];
    }));
    this.engine.defun("setname", (Func<List<object>, object>) (args =>
    {
      this.engine.setq("name", args[0]);
      string s = this.lispStringToString(args[0]);
      if (s == null)
        return (object) null;
      if (this.current.text.pos == TextBlock.Position.BOTTOM)
        this.executer.setBottomName(s);
      else
        this.executer.setTopName(s);
      return args[0];
    }));
    this.engine.defun("gotolabel", (Func<List<object>, object>) (args =>
    {
      this.setNextLabel(this.lispStringToString(args[0]));
      return args[0];
    }));
    this.engine.defun("debug-addtext", (Func<List<object>, object>) (args =>
    {
      this.current.addText(this.lispStringToString(args[0]) ?? args[0].ToString());
      return args[0];
    }));
    this.engine.defun("unity-debug-log", (Func<List<object>, object>) (args =>
    {
      Debug.Log((object) (this.lispStringToString(args[0]) ?? args[0].ToString()));
      return args[0];
    }));
    this.engine.defun("body", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.setPerson(nullable.Value, nullable.Value);
      return args[0];
    }));
    this.engine.defun("pos", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      int? nullable2 = this.lispNumberToInt(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      this.executer.setCharaPosition(nullable1.Value, nullable2.Value);
      return args[0];
    }));
    this.engine.defun("chara", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.getCharaPosition(nullable.Value);
      return args[0];
    }));
    this.engine.defun("face", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      string s = this.lispStringToString(args[1]);
      if (s == null)
        return (object) null;
      this.executer.setFace(nullable.Value, s);
      return args[0];
    }));
    this.engine.defun("eye", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      string s = this.lispStringToString(args[1]);
      if (s == null)
        return (object) null;
      this.executer.setEye(nullable.Value, s);
      return args[0];
    }));
    this.engine.defun("leftin", (Func<List<object>, object>) (args =>
    {
      int? nullable3 = this.lispNumberToInt(args[0]);
      if (!nullable3.HasValue)
        return (object) null;
      float? nullable4 = this.lispNumberToFloat(args[1]);
      if (!nullable4.HasValue)
        return (object) null;
      this.executer.setCharaMoveIn(nullable3.Value, nullable4.Value, -1000f);
      return args[0];
    }));
    this.engine.defun("rightin", (Func<List<object>, object>) (args =>
    {
      int? nullable5 = this.lispNumberToInt(args[0]);
      if (!nullable5.HasValue)
        return (object) null;
      float? nullable6 = this.lispNumberToFloat(args[1]);
      if (!nullable6.HasValue)
        return (object) null;
      this.executer.setCharaMoveIn(nullable5.Value, nullable6.Value, 1000f);
      return args[0];
    }));
    this.engine.defun("leftout", (Func<List<object>, object>) (args =>
    {
      int? nullable7 = this.lispNumberToInt(args[0]);
      if (!nullable7.HasValue)
        return (object) null;
      float? nullable8 = this.lispNumberToFloat(args[1]);
      if (!nullable8.HasValue)
        return (object) null;
      this.executer.setCharaMoveOut(nullable7.Value, nullable8.Value, -1000f);
      return args[0];
    }));
    this.engine.defun("rightout", (Func<List<object>, object>) (args =>
    {
      int? nullable9 = this.lispNumberToInt(args[0]);
      if (!nullable9.HasValue)
        return (object) null;
      float? nullable10 = this.lispNumberToFloat(args[1]);
      if (!nullable10.HasValue)
        return (object) null;
      this.executer.setCharaMoveOut(nullable9.Value, nullable10.Value, 1000f);
      return args[0];
    }));
    this.engine.defun("scale", (Func<List<object>, object>) (args =>
    {
      int? nullable11 = this.lispNumberToInt(args[0]);
      if (!nullable11.HasValue)
        return (object) null;
      float? nullable12 = this.lispNumberToFloat(args[1]);
      if (!nullable12.HasValue)
        return (object) null;
      float? nullable13 = this.lispNumberToFloat(args[2]);
      if (!nullable13.HasValue)
        return (object) null;
      this.executer.setCharaScale(nullable11.Value, nullable12.Value, nullable13.Value);
      return args[0];
    }));
    this.engine.defun("henshinbody", (Func<List<object>, object>) (args =>
    {
      int count = args.Count;
      switch (count)
      {
        case 3:
        case 4:
          int? nullable14 = this.lispNumberToInt(args[0]);
          if (!nullable14.HasValue)
            return (object) null;
          int num1 = count != 3 ? 1 : 0;
          List<object> objectList1 = args;
          int index1 = num1;
          int num2 = index1 + 1;
          int? nullable15 = this.lispNumberToInt(objectList1[index1]);
          if (!nullable15.HasValue)
            return (object) null;
          List<object> objectList2 = args;
          int index2 = num2;
          int index3 = index2 + 1;
          int? nullable16 = this.lispNumberToInt(objectList2[index2]);
          if (!nullable16.HasValue)
            return (object) null;
          int? nullable17 = this.lispNumberToInt(args[index3]);
          if (!nullable17.HasValue)
            return (object) null;
          this.executer.setHenshin(nullable14.Value, nullable15.Value, nullable16.Value, nullable17.Value);
          return args[0];
        default:
          return (object) null;
      }
    }));
    this.engine.defun("henshin", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.startHenshin(nullable.Value);
      return args[0];
    }));
    this.engine.defun("henshinskip", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.skipHenshin(nullable.Value);
      return args[0];
    }));
    this.engine.defun("emotionbody", (Func<List<object>, object>) (args =>
    {
      int? nullable18 = this.lispNumberToInt(args[0]);
      if (!nullable18.HasValue)
        return (object) null;
      int? nullable19 = this.lispNumberToInt(args[1]);
      if (!nullable19.HasValue)
        return (object) null;
      int? nullable20 = this.lispNumberToInt(args[2]);
      if (!nullable20.HasValue)
        return (object) null;
      int? nullable21 = this.lispNumberToInt(args[3]);
      if (!nullable21.HasValue)
        return (object) null;
      int? nullable22 = this.lispNumberToInt(args[4]);
      if (!nullable22.HasValue)
        return (object) null;
      int? nullable23 = args.Count != 6 ? new int?(0) : this.lispNumberToInt(args[5]);
      if (!nullable23.HasValue)
        return (object) null;
      this.executer.setEmotion(nullable18.Value, nullable19.Value, nullable23.Value, nullable20.Value, nullable21.Value, nullable22.Value);
      return args[0];
    }));
    this.engine.defun("envbody", (Func<List<object>, object>) (args =>
    {
      int? nullable24 = this.lispNumberToInt(args[0]);
      if (!nullable24.HasValue)
        return (object) null;
      int? nullable25 = this.lispNumberToInt(args[1]);
      if (!nullable25.HasValue)
        return (object) null;
      int? nullable26 = args.Count != 3 ? new int?(0) : this.lispNumberToInt(args[2]);
      if (!nullable26.HasValue)
        return (object) null;
      this.executer.setEnvEffect(nullable24.Value, nullable25.Value, nullable26.Value);
      return args[0];
    }));
    this.engine.defun("effectbody", (Func<List<object>, object>) (args =>
    {
      int? nullable27 = this.lispNumberToInt(args[0]);
      if (!nullable27.HasValue)
        return (object) null;
      int? nullable28 = this.lispNumberToInt(args[1]);
      if (!nullable28.HasValue)
        return (object) null;
      int? nullable29 = this.lispNumberToInt(args[2]);
      if (!nullable29.HasValue)
        return (object) null;
      int? nullable30 = this.lispNumberToInt(args[3]);
      if (!nullable30.HasValue)
        return (object) null;
      int? nullable31 = args.Count != 5 ? new int?(0) : this.lispNumberToInt(args[4]);
      if (!nullable31.HasValue)
        return (object) null;
      this.executer.setEffect(nullable27.Value, nullable28.Value, nullable31.Value, nullable29.Value, nullable30.Value);
      return args[0];
    }));
    this.engine.defun("effectpattern", (Func<List<object>, object>) (args =>
    {
      int? nullable32 = this.lispNumberToInt(args[0]);
      if (!nullable32.HasValue)
        return (object) null;
      int? nullable33 = this.lispNumberToInt(args[1]);
      if (!nullable33.HasValue)
        return (object) null;
      int? nullable34 = args.Count != 3 ? new int?(0) : this.lispNumberToInt(args[2]);
      if (!nullable34.HasValue)
        return (object) null;
      this.executer.changeEffect(nullable32.Value, nullable33.Value, nullable34.Value);
      return args[0];
    }));
    this.engine.defun("effectstart", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.startEffect(nullable.Value);
      return args[0];
    }));
    this.engine.defun("effectskip", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.skipEffect(nullable.Value);
      return args[0];
    }));
    this.engine.defun("jump", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.setJump(nullable.Value);
      return args[0];
    }));
    this.engine.defun("clash", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.setClash(nullable.Value);
      return args[0];
    }));
    this.engine.defun("move", (Func<List<object>, object>) (args =>
    {
      int? nullable35 = this.lispNumberToInt(args[0]);
      if (!nullable35.HasValue)
        return (object) null;
      int? nullable36 = this.lispNumberToInt(args[1]);
      if (!nullable36.HasValue)
        return (object) null;
      float? nullable37 = this.lispNumberToFloat(args[2]);
      if (!nullable37.HasValue)
        return (object) null;
      this.executer.setMoveChara(nullable35.Value, nullable36.Value, nullable37.Value);
      return args[0];
    }));
    this.engine.defun("brightness", (Func<List<object>, object>) (args =>
    {
      int? nullable38 = this.lispNumberToInt(args[0]);
      if (!nullable38.HasValue)
        return (object) null;
      float? nullable39 = this.lispNumberToFloat(args[1]);
      if (!nullable39.HasValue)
        return (object) null;
      float? nullable40 = this.lispNumberToFloat(args[2]);
      if (!nullable40.HasValue)
        return (object) null;
      this.executer.setCharaBrightness(nullable38.Value, nullable39.Value, nullable40.Value);
      return args[0];
    }));
    this.engine.defun("alpha", (Func<List<object>, object>) (args =>
    {
      int? nullable41 = this.lispNumberToInt(args[0]);
      if (!nullable41.HasValue)
        return (object) null;
      float? nullable42 = this.lispNumberToFloat(args[1]);
      if (!nullable42.HasValue)
        return (object) null;
      float? nullable43 = this.lispNumberToFloat(args[2]);
      if (!nullable43.HasValue)
        return (object) null;
      this.executer.setCharaAlpha(nullable41.Value, nullable42.Value, nullable43.Value);
      return args[0];
    }));
    this.engine.defun("reversal", (Func<List<object>, object>) (args =>
    {
      int? nullable44 = this.lispNumberToInt(args[0]);
      if (!nullable44.HasValue)
        return (object) null;
      int? nullable45 = this.lispNumberToInt(args[1]);
      if (!nullable45.HasValue)
        return (object) null;
      this.executer.setCharaReversal(nullable44.Value, nullable45.GetValueOrDefault() == 0 && nullable45.HasValue);
      return args[0];
    }));
    this.engine.defun("distinction", (Func<List<object>, object>) (args =>
    {
      int? nullable46 = this.lispNumberToInt(args[0]);
      if (!nullable46.HasValue)
        return (object) null;
      int? nullable47 = this.lispNumberToInt(args[1]);
      if (!nullable47.HasValue)
        return (object) null;
      this.executer.setUnitDistinction(nullable46.Value, nullable47.Value);
      return args[0];
    }));
    this.engine.defun("distinctionstop", (Func<List<object>, object>) (args =>
    {
      this.executer.stopDistinction();
      return args[0];
    }));
    this.engine.defun("clone", (Func<List<object>, object>) (args =>
    {
      int? nullable48 = this.lispNumberToInt(args[0]);
      if (!nullable48.HasValue)
        return (object) null;
      int? nullable49 = this.lispNumberToInt(args[1]);
      if (!nullable49.HasValue)
        return (object) null;
      this.executer.setPerson(nullable48.Value, nullable49.Value);
      return args[0];
    }));
    this.engine.defun("cutinname", (Func<List<object>, object>) (args =>
    {
      float? nullable50 = this.lispNumberToFloat(args[0]);
      if (!nullable50.HasValue)
        return (object) null;
      int? nullable51 = this.lispNumberToInt(args[1]);
      if (!nullable51.HasValue)
        return (object) null;
      this.executer.setCutinName(nullable50.Value, nullable51.Value);
      return args[0];
    }));
    this.engine.defun("textflame", (Func<List<object>, object>) (args =>
    {
      int? nullable52 = this.lispNumberToInt(args[0]);
      if (!nullable52.HasValue)
        return (object) null;
      if (nullable52.Value == 0)
      {
        int? nullable53 = this.lispNumberToInt(args[1]);
        if (!nullable53.HasValue)
          return (object) null;
        this.executer.setTextFlame(nullable52.Value, nullable53.Value);
      }
      else
        this.executer.setTextFlame(nullable52.Value);
      return args[0];
    }));
    this.engine.defun("textboxarrow", (Func<List<object>, object>) (args =>
    {
      int? nullable54 = this.lispNumberToInt(args[0]);
      if (!nullable54.HasValue)
        return (object) null;
      int? nullable55 = this.lispNumberToInt(args[1]);
      if (!nullable55.HasValue)
        return (object) null;
      if (nullable54.Value == 0)
        this.executer.setBottomTextArrow(nullable55.Value);
      else
        this.executer.setTopTextArrow(nullable55.Value);
      return (object) null;
    }));
    this.engine.defun("layer", (Func<List<object>, object>) (args =>
    {
      int? nullable56 = this.lispNumberToInt(args[0]);
      if (!nullable56.HasValue)
        return (object) null;
      int? nullable57 = this.lispNumberToInt(args[1]);
      if (!nullable57.HasValue)
        return (object) null;
      this.executer.setCharaLayer(nullable56.Value, nullable57.Value);
      return args[0];
    }));
    this.engine.defun("delete", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.deleteUnit(nullable.Value);
      return args[0];
    }));
    this.engine.defun("mask", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      bool enable = (bool) args[1];
      this.executer.SetMaskEnable(nullable.Value, enable);
      return args[0];
    }));
    this.engine.defun("background", (Func<List<object>, object>) (args =>
    {
      string s = this.lispStringToString(args[0]);
      if (s == null)
        return (object) null;
      this.executer.setBackGround(s);
      return args[0];
    }));
    this.engine.defun("wait", (Func<List<object>, object>) (args =>
    {
      float? nullable = this.lispNumberToFloat(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.setWait(nullable.Value);
      return args[0];
    }));
    this.engine.defun("waitandnext", (Func<List<object>, object>) (args =>
    {
      float? nullable = this.lispNumberToFloat(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.setWait(nullable.Value, true);
      return args[0];
    }));
    this.engine.defun("fillrect", (Func<List<object>, object>) (args =>
    {
      string name = this.lispStringToString(args[0]);
      if (name == null)
        return (object) null;
      float? nullable58 = this.lispNumberToFloat(args[1]);
      if (!nullable58.HasValue)
        return (object) null;
      float? nullable59 = this.lispNumberToFloat(args[2]);
      if (!nullable59.HasValue)
        return (object) null;
      float? nullable60 = this.lispNumberToFloat(args[3]);
      if (!nullable60.HasValue)
        return (object) null;
      StoryEnvironment.colorFromName(name, out this.r, out this.g, out this.b);
      this.executer.setColorAndTime(this.r, this.g, this.b, nullable59.Value, nullable60.Value, nullable58.Value);
      this.executer.startFillrect();
      return args[0];
    }));
    this.engine.defun("fadein", (Func<List<object>, object>) (args =>
    {
      string name = this.lispStringToString(args[0]);
      if (name == null)
        return (object) null;
      float? nullable = this.lispNumberToFloat(args[1]);
      if (!nullable.HasValue)
        return (object) null;
      StoryEnvironment.colorFromName(name, out this.r, out this.g, out this.b);
      this.fromAlpha = 1f;
      this.toAlpha = 0.0f;
      this.executer.setColorAndTime(this.r, this.g, this.b, this.fromAlpha, this.toAlpha, nullable.Value);
      this.executer.startFade();
      return args[0];
    }));
    this.engine.defun("fadeout", (Func<List<object>, object>) (args =>
    {
      string name = this.lispStringToString(args[0]);
      if (name == null)
        return (object) null;
      float? nullable = this.lispNumberToFloat(args[1]);
      if (!nullable.HasValue)
        return (object) null;
      StoryEnvironment.colorFromName(name, out this.r, out this.g, out this.b);
      this.fromAlpha = 0.0f;
      this.toAlpha = 1f;
      this.executer.setColorAndTime(this.r, this.g, this.b, this.fromAlpha, this.toAlpha, nullable.Value);
      this.executer.startFade();
      return args[0];
    }));
    this.engine.defun("flush", (Func<List<object>, object>) (args =>
    {
      string name = this.lispStringToString(args[0]);
      if (name == null)
        return (object) null;
      float? nullable61 = this.lispNumberToFloat(args[1]);
      if (!nullable61.HasValue)
        return (object) null;
      int? nullable62 = this.lispNumberToInt(args[2]);
      if (!nullable62.HasValue)
        return (object) null;
      StoryEnvironment.colorFromName(name, out this.r, out this.g, out this.b);
      return this.executer.startFlush(new Color(this.r, this.g, this.b), nullable61.Value, nullable62.Value);
    }));
    this.engine.defun("textwindow", (Func<List<object>, object>) (args =>
    {
      string s = this.lispStringToString(args[0]);
      switch (s)
      {
        case null:
          return (object) null;
        case "close":
          this.executer.setTextClose(this.current.text.pos);
          break;
        default:
          if (!(s == string.Empty))
          {
            switch (s)
            {
              case "top_close":
                this.executer.setTextClose(TextBlock.Position.TOP);
                break;
              case "bottom_close":
                this.executer.setTextClose(TextBlock.Position.BOTTOM);
                break;
              default:
                if (this.current.text.pos == TextBlock.Position.TOP)
                {
                  this.executer.setTextTopWindow(s);
                  break;
                }
                this.executer.setTextBottomWindow(s);
                break;
            }
          }
          else
            goto case "close";
          break;
      }
      return args[0];
    }));
    this.engine.defun("textsize", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      if (this.current.text.pos == TextBlock.Position.TOP)
        this.executer.setTextSize(nullable.Value, true);
      else
        this.executer.setTextSize(nullable.Value, false);
      return args[0];
    }));
    this.engine.defun("textshake", (Func<List<object>, object>) (args =>
    {
      float? nullable = this.lispNumberToFloat(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      if (this.current.text.pos == TextBlock.Position.TOP)
        this.executer.setTextShake(nullable.Value, true);
      else
        this.executer.setTextShake(nullable.Value, false);
      return args[0];
    }));
    this.engine.defun("textcolor", (Func<List<object>, object>) (args =>
    {
      string color = this.lispStringToString(args[0]);
      if (color == null)
        return (object) null;
      this.executer.SetColorText(this.current.text.pos, color);
      return args[0];
    }));
    this.engine.defun("textalign", (Func<List<object>, object>) (args =>
    {
      string align = this.lispStringToString(args[0]);
      if (align == null)
        return (object) null;
      this.executer.SetTextAlgin(this.current.text.pos, align);
      return args[0];
    }));
    this.engine.defun("textstop", (Func<List<object>, object>) (args =>
    {
      this.executer.SetColorText(this.current.text.pos, "normal");
      if (this.current.text.pos == TextBlock.Position.TOP)
      {
        this.executer.setTextSize(24, true);
        this.executer.setTextTopWindow("normal");
      }
      else
      {
        this.executer.setTextSize(24, false);
        this.executer.setTextBottomWindow("normal");
      }
      if (this.current.text.pos == TextBlock.Position.TOP)
        this.executer.stopTextShake(true);
      else
        this.executer.stopTextShake(false);
      return args[0];
    }));
    this.engine.defun("shake", (Func<List<object>, object>) (args =>
    {
      int? nullable63 = this.lispNumberToInt(args[0]);
      if (!nullable63.HasValue)
        return (object) null;
      float w = 3f;
      if (nullable63.Value != 0)
        w = 7f;
      float? nullable64 = this.lispNumberToFloat(args[1]);
      this.executer.setShake(w, nullable64.Value);
      return args[0];
    }));
    this.engine.defun("shakeloop", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      float w = 3f;
      if (nullable.Value != 0)
        w = 7f;
      this.executer.setShake(w, 0.0f);
      return (object) null;
    }));
    this.engine.defun("shakestop", (Func<List<object>, object>) (args =>
    {
      this.executer.stopShake();
      return (object) null;
    }));
    this.engine.defun("imageset", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) false;
      string name = this.lispStringToString(args[1]);
      if (name == null)
        return (object) null;
      this.executer.setImageName(nullable.Value, name);
      return args[0];
    }));
    this.engine.defun("imagelayer", (Func<List<object>, object>) (args =>
    {
      int? nullable65 = this.lispNumberToInt(args[0]);
      if (!nullable65.HasValue)
        return (object) false;
      int? nullable66 = this.lispNumberToInt(args[1]);
      if (!nullable66.HasValue)
        return (object) false;
      this.executer.setImagePriority(nullable65.Value, nullable66.Value);
      return args[0];
    }));
    this.engine.defun("imagepos", (Func<List<object>, object>) (args =>
    {
      int? nullable67 = this.lispNumberToInt(args[0]);
      if (!nullable67.HasValue)
        return (object) null;
      float? nullable68 = this.lispNumberToFloat(args[1]);
      if (!nullable68.HasValue)
        return (object) null;
      float? nullable69 = this.lispNumberToFloat(args[2]);
      if (!nullable69.HasValue)
        return (object) null;
      this.executer.setImagePosition(nullable67.Value, nullable68.Value, nullable69.Value);
      return args[0];
    }));
    this.engine.defun("imagealpha", (Func<List<object>, object>) (args =>
    {
      int? nullable70 = this.lispNumberToInt(args[0]);
      if (!nullable70.HasValue)
        return (object) null;
      float? nullable71 = this.lispNumberToFloat(args[1]);
      if (!nullable71.HasValue)
        return (object) null;
      float? nullable72 = this.lispNumberToFloat(args[2]);
      if (!nullable72.HasValue)
        return (object) null;
      this.executer.setImageAlpha(nullable70.Value, nullable71.Value, nullable72.Value);
      return args[0];
    }));
    this.engine.defun("imagescale", (Func<List<object>, object>) (args =>
    {
      int? nullable73 = this.lispNumberToInt(args[0]);
      if (!nullable73.HasValue)
        return (object) null;
      float? nullable74 = this.lispNumberToFloat(args[1]);
      if (!nullable74.HasValue)
        return (object) null;
      float? nullable75 = this.lispNumberToFloat(args[2]);
      if (!nullable75.HasValue)
        return (object) null;
      this.executer.setImageScale(nullable73.Value, nullable74.Value, nullable75.Value);
      return args[0];
    }));
    this.engine.defun("imageleftin", (Func<List<object>, object>) (args =>
    {
      int? nullable76 = this.lispNumberToInt(args[0]);
      if (!nullable76.HasValue)
        return (object) null;
      float? nullable77 = this.lispNumberToFloat(args[1]);
      if (!nullable77.HasValue)
        return (object) null;
      this.executer.setImageMoveIn(nullable76.Value, nullable77.Value, -2500f, 0.0f);
      return args[0];
    }));
    this.engine.defun("imagerightin", (Func<List<object>, object>) (args =>
    {
      int? nullable78 = this.lispNumberToInt(args[0]);
      if (!nullable78.HasValue)
        return (object) null;
      float? nullable79 = this.lispNumberToFloat(args[1]);
      if (!nullable79.HasValue)
        return (object) null;
      this.executer.setImageMoveIn(nullable78.Value, nullable79.Value, 2500f, 0.0f);
      return args[0];
    }));
    this.engine.defun("imageleftout", (Func<List<object>, object>) (args =>
    {
      int? nullable80 = this.lispNumberToInt(args[0]);
      if (!nullable80.HasValue)
        return (object) null;
      float? nullable81 = this.lispNumberToFloat(args[1]);
      if (!nullable81.HasValue)
        return (object) null;
      this.executer.setImageMoveOut(nullable80.Value, nullable81.Value, -2500f, 0.0f);
      return args[0];
    }));
    this.engine.defun("imagerightout", (Func<List<object>, object>) (args =>
    {
      int? nullable82 = this.lispNumberToInt(args[0]);
      if (!nullable82.HasValue)
        return (object) null;
      float? nullable83 = this.lispNumberToFloat(args[1]);
      if (!nullable83.HasValue)
        return (object) null;
      this.executer.setImageMoveOut(nullable82.Value, nullable83.Value, 2500f, 0.0f);
      return args[0];
    }));
    this.engine.defun("imagemoveto", (Func<List<object>, object>) (args =>
    {
      int? nullable84 = this.lispNumberToInt(args[0]);
      if (!nullable84.HasValue)
        return (object) null;
      float? nullable85 = this.lispNumberToFloat(args[1]);
      if (!nullable85.HasValue)
        return (object) null;
      float? nullable86 = this.lispNumberToFloat(args[2]);
      if (!nullable86.HasValue)
        return (object) null;
      float? nullable87 = this.lispNumberToFloat(args[3]);
      if (!nullable87.HasValue)
        return (object) null;
      this.executer.setImageMoveOut(nullable84.Value, nullable87.Value, nullable85.Value, nullable86.Value);
      return args[0];
    }));
    this.engine.defun("emotion", (Func<List<object>, object>) (args =>
    {
      if (!this.lispNumberToInt(args[0]).HasValue)
        return (object) false;
      string str = this.lispStringToString(args[1]);
      if (str == null)
        return (object) null;
      if (!this.lispNumberToFloat(args[2]).HasValue)
        return (object) null;
      if (!this.lispNumberToFloat(args[3]).HasValue)
        return (object) null;
      switch (str)
      {
        case "del":
          this.executer.deleteEmotion();
          break;
        case "brightness":
          this.executer.setEmotionBright();
          break;
        default:
          this.executer.setEmotion();
          break;
      }
      return args[0];
    }));
    this.engine.defun("voice", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) false;
      string name = this.lispStringToString(args[1]);
      if (name == null)
        return (object) null;
      this.executer.setVoice(nullable.Value.ToString(), name);
      return args[0];
    }));
    this.engine.defun("voicedelay", (Func<List<object>, object>) (args =>
    {
      int? nullable88 = this.lispNumberToInt(args[0]);
      if (!nullable88.HasValue)
        return (object) false;
      string name = this.lispStringToString(args[1]);
      if (name == null)
        return (object) null;
      float? nullable89 = this.lispNumberToFloat(args[2]);
      if (!nullable89.HasValue)
        return (object) false;
      this.executer.setVoice(nullable88.Value.ToString(), name, nullable89.Value);
      return args[0];
    }));
    this.engine.defun("se", (Func<List<object>, object>) (args =>
    {
      string clip = this.lispStringToString(args[0]);
      if (clip == null)
        return (object) null;
      this.executer.setSe(clip);
      return args[0];
    }));
    this.engine.defun("sedelay", (Func<List<object>, object>) (args =>
    {
      string clip = this.lispStringToString(args[0]);
      if (clip == null)
        return (object) null;
      float? nullable = this.lispNumberToFloat(args[1]);
      if (!nullable.HasValue)
        return (object) false;
      this.executer.setSe(clip, nullable.Value);
      return args[0];
    }));
    this.engine.defun("sestop", (Func<List<object>, object>) (args =>
    {
      string clip = this.lispStringToString(args[0]);
      if (clip == null)
        return (object) null;
      this.executer.stopSe(clip);
      return args[0];
    }));
    this.engine.defun("sestopdelay", (Func<List<object>, object>) (args =>
    {
      string clip = this.lispStringToString(args[0]);
      if (clip == null)
        return (object) null;
      float? nullable = this.lispNumberToFloat(args[1]);
      if (!nullable.HasValue)
        return (object) false;
      this.executer.stopSe(clip, nullable.Value);
      return args[0];
    }));
    this.engine.defun("bgm", (Func<List<object>, object>) (args =>
    {
      string s = this.lispStringToString(args[0]);
      switch (s)
      {
        case null:
          return (object) null;
        case "stop":
          this.executer.stopBgm();
          break;
        default:
          string file = (string) null;
          if (args.Count > 2)
            file = this.lispStringToString(args[2]);
          float? nullable = this.lispNumberToFloat(args[1]);
          if ((double) nullable.Value < 0.699999988079071)
          {
            if (file != null)
            {
              this.executer.setBgmFile(file, s);
              break;
            }
            this.executer.setBgm(s);
            break;
          }
          if (file != null)
          {
            this.executer.setBgmFile(file, s, nullable.Value);
            break;
          }
          this.executer.setBgm(s, nullable.Value);
          break;
      }
      return args[0];
    }));
    this.engine.defun("bgmfile", (Func<List<object>, object>) (args =>
    {
      string s = this.lispStringToString(args[0]);
      switch (s)
      {
        case null:
          return (object) null;
        case "stop":
          this.executer.stopBgm();
          break;
        default:
          string file = this.lispStringToString(args[1]);
          float? nullable = this.lispNumberToFloat(args[2]);
          if ((double) nullable.Value < 0.699999988079071)
          {
            this.executer.setBgmFile(file, s);
            break;
          }
          this.executer.setBgmFile(file, s, nullable.Value);
          break;
      }
      return args[0];
    }));
    this.engine.defun("movieplay", (Func<List<object>, object>) (args =>
    {
      string fileName = this.lispStringToString(args[0]);
      if (fileName == null)
        return (object) null;
      bool enabledSkip = (args.Count<object>() >= 2 ? this.lispStringToString(args[1]) : "skip") == "skip";
      this.executer.PlayMovie(fileName, enabledSkip);
      return args[0];
    }));
    this.engine.defun("flag", (Func<List<object>, object>) (args =>
    {
      if (args.Count < 2)
        return (object) null;
      return this.lispStringToString(args[0]) == null ? (object) null : args[0];
    }));
    this.engine.defun("flagjump", (Func<List<object>, object>) (args =>
    {
      if (args.Count < 2)
        return (object) null;
      string v = this.lispStringToString(args[0]);
      if (v == null)
        return (object) null;
      bool? nullable = (bool?) this.getVariable(v);
      if (!nullable.HasValue)
      {
        this.setVariable(v, (object) false);
        nullable = new bool?(false);
      }
      this.setNextLabel(this.lispStringToString(args[1]));
      return args[0];
    }));
    this.engine.defun("labeljump", (Func<List<object>, object>) (args =>
    {
      if (args.Count < 1)
        return (object) null;
      this.setNextLabel(this.lispStringToString(args[0]));
      return args[0];
    }));
    this.engine.defun("select", (Func<List<object>, object>) (args =>
    {
      if (args.Count < 2 || args.Count % 2 != 0)
        return (object) null;
      SelectBlock sb = new SelectBlock();
      int num = args.Count / 2;
      for (int index = 0; index < num; ++index)
      {
        SelectBlock.Data data = new SelectBlock.Data();
        data.msg = this.lispStringToString(args[index * 2]);
        data.label = this.lispStringToString(args[index * 2 + 1]);
        if (data.msg == null || data.label == null)
          return (object) null;
        sb.data.Add(data);
      }
      this.current.setSelect(sb);
      this.executer.StartSelect(sb);
      this.current.next_enable = false;
      return args[0];
    }));
    this.engine.defun("popupstoryeffect", (Func<List<object>, object>) (args =>
    {
      if (args.Count < 1)
        return (object) null;
      this.executer.PopupStoryEffect(this.lispStringToString(args[0]));
      return args[0];
    }));
  }

  public bool SkipReady()
  {
    if (StoryEnvironment.IsNoWaitOnChoise)
      return true;
    return this.storyBlocks != null && this.storyBlocks.Count > 0 && this.current.select == null;
  }

  public StoryBlock current => this.storyBlocks[this.currentIdx];

  public ReadOnlyCollection<StoryBlock> all()
  {
    return new ReadOnlyCollection<StoryBlock>((IList<StoryBlock>) this.storyBlocks);
  }

  public void initialize(string program, StoryExecuter exec)
  {
    this.engine = new Lisp(this.scriptEnv);
    this.executer = exec;
    this.defineVariables();
    this.defunCommands();
    this.storyBlocks = new StoryParser().parse(program, this.scriptEnv);
    this.currentIdx = 0;
  }

  public void setVariable(string v, object o) => this.scriptEnv[v] = o;

  public object getVariable(string v)
  {
    try
    {
      return this.scriptEnv[v];
    }
    catch (Exception ex)
    {
      Debug.LogError((object) ("getVariable not found name=" + v));
      return (object) null;
    }
  }

  public object nextBlock()
  {
    if (this.nextBlockp())
    {
      if (this.nextLabel == null)
      {
        ++this.currentIdx;
      }
      else
      {
        this.setCurrent(this.nextLabel);
        this.nextLabel = (string) null;
      }
    }
    return (object) this.storyBlocks[this.currentIdx];
  }

  public object resetBlock()
  {
    this.currentIdx = 0;
    return (object) this.storyBlocks[this.currentIdx];
  }

  public object backBlock() => (object) this.storyBlocks[this.currentIdx - 1];

  public bool nextBlockp()
  {
    return this.nextLabel != null || this.currentIdx < this.storyBlocks.Count - 1;
  }

  public object setCurrent(string label)
  {
    int num = 0;
    foreach (StoryBlock storyBlock in this.storyBlocks)
    {
      if (storyBlock.label == label)
      {
        this.currentIdx = num;
        return (object) label;
      }
      ++num;
    }
    return (object) null;
  }

  public void evalCurrent() => this.current.eval(this.engine);

  public void setNextLabel(string label) => this.nextLabel = label;
}
