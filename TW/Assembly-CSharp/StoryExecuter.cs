// Decompiled with JetBrains decompiler
// Type: StoryExecuter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class StoryExecuter : MonoBehaviour
{
  [SerializeField]
  private FadeControl fadeControl;
  [SerializeField]
  private FlushControl flushControl;
  [SerializeField]
  private Texture2D[] mSprite;
  [SerializeField]
  private GameObject resetButton;
  [SerializeField]
  private GameObject backButton;
  [SerializeField]
  private bool isReset;
  [SerializeField]
  private bool isBack;
  [SerializeField]
  private GameObject mainPanel;
  [SerializeField]
  private QuestMoviePlayer movieObj;
  public List<PlaySEData> plsySEDataList;
  public GameObject[] imageObj;
  public UILabel textTopLabel;
  public UILabel nameTopLabel;
  public UILabel textBottomLabel;
  public UILabel nameBottomLabel;
  public GameObject textContainerTop;
  public GameObject topArrow;
  public GameObject textContainerBottom;
  public GameObject textTopObj;
  public GameObject textBottomObj;
  public UISprite nextTopSprite;
  public UISprite nextBottomSprite;
  public GameObject windowObj;
  public BacklogManager backlog_manager;
  public Transform[] personPoints;
  public Transform[] imagePoints;
  public Vector3[] positions;
  public NGTweenParts nextButton;
  public GameObject selectObj;
  public float skip_wait;
  public float select_button_wait;
  public UILabel[] SelectLabel;
  public UILabel quastion;
  public GameObject[] select;
  public GameObject[] selectBtn;
  public GameObject[] selectBtnObj;
  public GameObject[] textBoxBaseTopObj;
  public GameObject[] textBoxBaseBottomObj;
  public GameObject[] textTopFlame;
  public GameObject[] textTop3Nozzle;
  public GameObject[] textBottomFlame;
  public GameObject[] textBottom3Nozzle;
  public UISprite[] textTopBox;
  public UISprite[] textBottomBox;
  public UISprite nameTopBox;
  public UISprite nameBottomBox;
  public GameObject nameTopBase;
  public GameObject nameBottomBase;
  public GameObject myselfBase;
  public GameObject charaTextBoxContainer;
  public GameObject myselfTextBoxContainer;
  public UISprite[] myselfSprite;
  public GameObject[] myselfTextBox;
  public GameObject[] myselfBoxBase;
  public GameObject cutinObj;
  public GameObject OnePiecePicture;
  public GameObject pictureContainer;
  public CutinNameManager CNM;
  public int charsPerSecond;
  public float stopBGMTime;
  private StoryEnvironment environment;
  private StoryResource storyResource;
  private ShakeControl shakecontrol;
  private TweenAlpha tweenalpha;
  private GameObject position;
  private GameObject bodyObj;
  private GameObject faceObj;
  private UI2DSprite fadeColor;
  private Jump jump;
  private TextShake textTopShake;
  private TextShake textBottomShake;
  private UISprite face;
  private GameObject bgObj;
  private UI2DSprite backGround;
  private int charaPos;
  private bool fadeIn;
  private bool fillrect;
  private float fadeAlpha;
  private bool skip_enable;
  private float skip_wait_time;
  private float select_wait;
  private bool onSelect;
  private GameObject unitPrefab;
  private NGxFaceSprite unitFace;
  private ResourceObject texture;
  private string cutinName;
  private int cutInNum;
  private bool cutIn;
  private NGSoundManager sm;
  private Vector3 myPos;
  private bool textFlame;
  private List<GameObject> units;
  private GameObject CharacterPrefab;
  private bool isInitializeDone;
  private float wait_command_time;
  private string typewriterText;
  private bool re;
  private BoxCollider box;
  private StoryBG sbg;
  private bool isWaitAndNext;
  public TextAsset storyText;
  private int coroutineCount;
  private Coroutine typewriterEffectCoroutine;
  private string selectSpriteName;
  private Dictionary<int, StoryExecuter.CharacterInfo> characterList;
  private Dictionary<int, StoryExecuter.ImageInfo> imageInfo;

  public StoryExecuter()
  {
    this.plsySEDataList = new List<PlaySEData>();
    this.skip_wait = 0.2f;
    this.select_button_wait = 1f;
    this.charsPerSecond = 40;
    this.stopBGMTime = 0.5f;
    this.environment = new StoryEnvironment();
    this.storyResource = new StoryResource();
    this.select_wait = 1f;
    this.units = new List<GameObject>();
    this.selectSpriteName = "ibtn_Choices_pressed.png__GUI__009-3_sozai__009-3_sozai_prefab";
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  private void Update()
  {
    if (this.skip_enable && this.isInitializeDone && this.environment.SkipReady())
    {
      this.skip_wait_time -= Time.deltaTime;
      this.fadeNextExit();
      if (this.cutIn)
      {
        this.CNM.wait = 0.3f;
        this.CNM.startWait = 0.3f;
        if (this.cutInNum == 1)
          this.CNM.left = CutinNameManager.LeftState.Del;
        else if (this.cutInNum == 2)
          this.CNM.center = CutinNameManager.CenterState.Del;
        else if (this.cutInNum == 3)
          this.CNM.right = CutinNameManager.RightState.Del;
      }
      if ((double) this.skip_wait_time <= 0.0)
      {
        this.skip_wait_time = this.skip_wait;
        this.wait_command_time = 0.0f;
        this.onNextButton();
      }
    }
    if ((double) this.wait_command_time > 0.0)
      this.wait_command_time -= Time.deltaTime;
    else if (this.isWaitAndNext && this.typewriterText == null)
    {
      this.isWaitAndNext = false;
      this.wait_command_time = 0.0f;
      this.onNextButton();
    }
    if (!this.onSelect)
      return;
    this.select_button_wait -= Time.deltaTime;
    if ((double) this.select_button_wait > 0.0)
      return;
    this.select_button_wait = this.select_wait;
    this.onSelect = false;
    this.textContainerBottom.SetActive(true);
    this.onNextButton();
  }

  private void fadeNextExit()
  {
    if (this.fadeIn && (double) this.fadeAlpha == 1.0)
    {
      this.fadeControl.time = 0.0f;
      this.fadeControl.StartFade();
    }
    else if (!this.fadeIn && (double) this.fadeAlpha == 0.0)
    {
      this.fadeControl.time = 0.0f;
      this.fadeControl.StartFade();
    }
    else
    {
      if (!this.fillrect)
        return;
      this.fillrect = false;
      this.fadeControl.time = 0.0f;
      this.fadeControl.StartFillrect();
    }
  }

  [DebuggerHidden]
  public IEnumerator initialize(string text)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StoryExecuter.\u003Cinitialize\u003Ec__Iterator56B()
    {
      text = text,
      \u003C\u0024\u003Etext = text,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator DeleteObject()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StoryExecuter.\u003CDeleteObject\u003Ec__Iterator56C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator typewriterEffect(string text, UILabel targetLabel)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StoryExecuter.\u003CtypewriterEffect\u003Ec__Iterator56D()
    {
      text = text,
      targetLabel = targetLabel,
      \u003C\u0024\u003Etext = text,
      \u003C\u0024\u003EtargetLabel = targetLabel,
      \u003C\u003Ef__this = this
    };
  }

  private void renderText(string text, bool isEffect = true)
  {
    UILabel uiLabel = this.environment.current.text.pos != TextBlock.Position.BOTTOM ? this.textTopLabel : this.textBottomLabel;
    if (uiLabel.alignment != NGUIText.Alignment.Center && isEffect)
      this.typewriterEffectCoroutine = this.StartCoroutine(this.typewriterEffect(text, uiLabel));
    else
      this.GetLabelIncludeText(text, uiLabel, text.Length);
  }

  private void CheckEnableObject()
  {
    this.box = this.windowObj.GetComponent<BoxCollider>();
    if (this.environment.current.select != null)
    {
      this.textContainerTop.SetActive(false);
      this.textContainerBottom.SetActive(false);
      ((Collider) this.box).enabled = false;
    }
    else
    {
      for (int index = 0; index < 3; ++index)
        this.select[index].SetActive(false);
      this.selectObj.SetActive(false);
      ((Collider) this.box).enabled = true;
    }
  }

  public void render()
  {
    this.resetCoroutine();
    try
    {
      this.environment.evalCurrent();
      if (this.environment.current.select == null)
      {
        if (this.environment.current.text.pos == TextBlock.Position.BOTTOM)
          this.backlog_manager.Add(this.nameBottomLabel.text, this.environment.current.text.text);
        else
          this.backlog_manager.Add(this.nameTopLabel.text, this.environment.current.text.text);
      }
    }
    catch (Exception ex)
    {
      Debug.LogException(ex);
    }
    this.CheckEnableObject();
    if (this.environment.current.select != null)
      return;
    this.nextButton.isActive = this.environment.nextBlockp();
    this.renderText(this.environment.current.getText());
  }

  public void onNextButton()
  {
    if ((double) this.wait_command_time > 0.0)
      return;
    this.isWaitAndNext = false;
    if (this.typewriterText != null)
    {
      this.StopCoroutine(this.typewriterEffectCoroutine);
      this.renderText(this.typewriterText, false);
      this.typewriterText = (string) null;
      foreach (KeyValuePair<int, StoryExecuter.CharacterInfo> character in this.characterList)
      {
        Clash component = character.Value.obj.GetComponent<Clash>();
        if (component.isClash)
          component.EndClash();
      }
    }
    else
    {
      this.CNM.left = CutinNameManager.LeftState.End;
      this.CNM.right = CutinNameManager.RightState.End;
      this.CNM.center = CutinNameManager.CenterState.End;
      this.charaPos = 0;
      if (this.environment.nextBlockp())
      {
        this.SetColorText(TextBlock.Position.TOP, "normal");
        this.SetColorText(TextBlock.Position.BOTTOM, "normal");
        this.SetTextAlgin(TextBlock.Position.TOP, "left");
        this.SetTextAlgin(TextBlock.Position.BOTTOM, "left");
        this.flushControl.SetEnd();
        this.fadeNextExit();
        this.environment.nextBlock();
        this.nextButton.isActive = this.environment.nextBlockp();
        this.render();
      }
      else
      {
        this.nextButton.isActive = this.environment.nextBlockp();
        this.backScene();
        this.skip_enable = false;
      }
      foreach (KeyValuePair<int, StoryExecuter.CharacterInfo> character in this.characterList)
      {
        Clash component = character.Value.obj.GetComponent<Clash>();
        if (component.isClash)
          component.EndClash();
      }
    }
    if ((double) this.textTopObj.transform.localPosition.x != 0.0)
      this.stopTextShake(true);
    if ((double) this.textBottomObj.transform.localPosition.x == 0.0)
      return;
    this.stopTextShake(false);
  }

  public void onSkipEnableButton() => this.skip_enable = false;

  public void backScene() => Singleton<NGSceneManager>.GetInstance().backScene();

  public void onSkipButton()
  {
    this.skip_enable = !this.skip_enable;
    if (!this.skip_enable)
      return;
    this.skip_wait_time = this.skip_wait;
  }

  public void onLogButton()
  {
    this.skip_enable = false;
    this.box = this.windowObj.GetComponent<BoxCollider>();
    if (this.backlog_manager.IsEnable())
      return;
    this.backlog_manager.StartBacklog(new System.Action(this.onLogCloseButton));
    ((Collider) this.box).enabled = false;
  }

  public void onLogCloseButton()
  {
    this.box = this.windowObj.GetComponent<BoxCollider>();
    if (!this.backlog_manager.IsEnable())
      return;
    this.backlog_manager.End();
    if (this.environment.current.select != null)
      ((Collider) this.box).enabled = false;
    else
      ((Collider) this.box).enabled = true;
  }

  public void onSelectButton00()
  {
    this.environment.current.setSelectIndex(0);
    this.environment.setNextLabel(this.environment.current.select.data[0].label);
    this.selectBtnObj[1].SetActive(false);
    this.selectBtnObj[2].SetActive(false);
    UISprite component = this.selectBtn[0].GetComponent<UISprite>();
    component.spriteName = this.selectSpriteName;
    ((Component) component).GetComponent<Collider>().enabled = false;
    this.select_button_wait = this.select_wait;
    this.onSelect = true;
    this.typewriterText = (string) null;
  }

  public void onSelectButton01()
  {
    this.environment.current.setSelectIndex(1);
    this.environment.setNextLabel(this.environment.current.select.data[1].label);
    this.selectBtnObj[0].SetActive(false);
    this.selectBtnObj[2].SetActive(false);
    UISprite component = this.selectBtn[1].GetComponent<UISprite>();
    component.spriteName = this.selectSpriteName;
    ((Component) component).GetComponent<Collider>().enabled = false;
    this.select_button_wait = this.select_wait;
    this.onSelect = true;
    this.typewriterText = (string) null;
  }

  public void onSelectButton02()
  {
    this.environment.current.setSelectIndex(2);
    this.environment.setNextLabel(this.environment.current.select.data[2].label);
    this.selectBtnObj[0].SetActive(false);
    this.selectBtnObj[1].SetActive(false);
    UISprite component = this.selectBtn[2].GetComponent<UISprite>();
    component.spriteName = this.selectSpriteName;
    ((Component) component).GetComponent<Collider>().enabled = false;
    this.select_button_wait = this.select_wait;
    this.onSelect = true;
    this.typewriterText = (string) null;
  }

  public void onResetButton()
  {
    this.re = true;
    this.environment.resetBlock();
    this.textContainerTop.SetActive(false);
    this.StartCoroutine(this.DeleteObject());
  }

  public void onBackButton()
  {
    this.environment.backBlock();
    this.render();
  }

  public void onWaitEnd()
  {
  }

  public void openTopLabelObject() => this.textContainerTop.SetActive(true);

  public void setNameMsgBright()
  {
    if (this.environment.current.text.pos == TextBlock.Position.BOTTOM)
    {
      for (int index = 0; index < this.textTopBox.Length; ++index)
      {
        this.textTopBox[index].color = new Color(0.5f, 0.5f, 0.5f);
        this.textBottomBox[index].color = new Color(1f, 1f, 1f);
        this.myselfSprite[index].color = new Color(1f, 1f, 1f);
      }
      this.nameTopBox.color = new Color(0.5f, 0.5f, 0.5f);
      this.nameBottomLabel.color = new Color(1f, 1f, 1f);
      this.nameTopLabel.color = new Color(0.5f, 0.5f, 0.5f);
      this.nameBottomBox.color = new Color(1f, 1f, 1f);
      this.nextTopSprite.color = new Color(0.5f, 0.5f, 0.5f);
      this.nextBottomSprite.color = new Color(1f, 1f, 1f);
    }
    else
    {
      for (int index = 0; index < this.textTopBox.Length; ++index)
      {
        this.textTopBox[index].color = new Color(1f, 1f, 1f);
        this.textBottomBox[index].color = new Color(0.5f, 0.5f, 0.5f);
        this.myselfSprite[index].color = new Color(0.5f, 0.5f, 0.5f);
      }
      this.nameTopBox.color = new Color(1f, 1f, 1f);
      this.nameTopLabel.color = new Color(1f, 1f, 1f);
      this.nameBottomLabel.color = new Color(0.5f, 0.5f, 0.5f);
      this.nameBottomBox.color = new Color(0.5f, 0.5f, 0.5f);
      this.nextTopSprite.color = new Color(1f, 1f, 1f);
      this.nextBottomSprite.color = new Color(0.5f, 0.5f, 0.5f);
    }
  }

  public void setTextBox()
  {
    if (this.environment.current.text.pos != TextBlock.Position.BOTTOM || this.textFlame)
      return;
    this.myselfTextBoxContainer.SetActive(false);
    this.charaTextBoxContainer.SetActive(true);
  }

  public void setBottomTextArrow(int n)
  {
    for (int index = 0; index < this.textBoxBaseBottomObj.Length; ++index)
    {
      if (Object.op_Inequality((Object) this.textBoxBaseBottomObj[index], (Object) null))
        this.textBoxBaseBottomObj[index].SetActive(index == n);
    }
  }

  public void setTopTextArrow(int n)
  {
    for (int index = 0; index < this.textBoxBaseTopObj.Length; ++index)
    {
      if (Object.op_Inequality((Object) this.textBoxBaseTopObj[index], (Object) null))
        this.textBoxBaseTopObj[index].SetActive(index == n);
    }
  }

  public object setBottomName(string s = null)
  {
    if (this.textFlame)
    {
      this.myselfBase.SetActive(true);
      this.nameBottomBase.SetActive(false);
    }
    else
    {
      this.nameBottomBase.SetActive(true);
      this.myselfBase.SetActive(false);
    }
    if (s == string.Empty || s == Consts.GetInstance().name_null)
    {
      this.nameBottomBase.SetActive(false);
      this.myselfBase.SetActive(false);
      s = string.Empty;
    }
    this.setNameMsgBright();
    this.nameBottomLabel.SetTextLocalize(s);
    this.cutinName = s;
    return (object) s;
  }

  public object setTopName(string s)
  {
    this.setNameMsgBright();
    this.nameTopBase.SetActive(true);
    if (s == string.Empty || s == Consts.GetInstance().name_null)
    {
      this.nameTopBase.SetActive(false);
      s = string.Empty;
    }
    this.nameTopLabel.SetTextLocalize(s);
    this.cutinName = s;
    return (object) s;
  }

  private UILabel GetLabelIncludeText(string text, UILabel target, int offset)
  {
    string text1 = !Object.op_Equality((Object) target, (Object) this.textBottomLabel) ? string.Format("[{0}]{1}", (object) StoryExecuter.ColorDefault.Top, (object) text.Substring(0, offset)) : string.Format("[{0}]{1}", (object) StoryExecuter.ColorDefault.Bottom, (object) text.Substring(0, offset));
    target.SetTextLocalize(text1);
    return target;
  }

  private int getBoxName(string name)
  {
    string key = name;
    if (key != null)
    {
      // ISSUE: reference to a compiler-generated field
      if (StoryExecuter.\u003C\u003Ef__switch\u0024map18 == null)
      {
        // ISSUE: reference to a compiler-generated field
        StoryExecuter.\u003C\u003Ef__switch\u0024map18 = new Dictionary<string, int>(3)
        {
          {
            "normal",
            0
          },
          {
            "toge",
            1
          },
          {
            "moya",
            2
          }
        };
      }
      int num;
      // ISSUE: reference to a compiler-generated field
      if (StoryExecuter.\u003C\u003Ef__switch\u0024map18.TryGetValue(key, out num))
      {
        switch (num)
        {
          case 0:
            return 0;
          case 1:
            return 1;
          case 2:
            return 2;
        }
      }
    }
    return 0;
  }

  private void waitColorTime(float t)
  {
  }

  public object setCutinName(float time, int num)
  {
    this.cutIn = true;
    this.cutInNum = num;
    this.CNM.startWait = time;
    this.CNM.characterName = this.cutinName;
    switch (num)
    {
      case 1:
        this.cutinObj.SendMessage("StartLeft");
        break;
      case 2:
        this.cutinObj.SendMessage("StartCenter");
        break;
      case 3:
        this.cutinObj.SendMessage("StartRight");
        break;
    }
    return (object) num;
  }

  public void setTextFlame(int n, int think = -1)
  {
    if (n == 0)
    {
      this.myselfTextBoxContainer.SetActive(true);
      this.charaTextBoxContainer.SetActive(false);
      if (think == 0)
      {
        this.myselfBoxBase[0].SetActive(true);
        this.myselfBoxBase[1].SetActive(false);
      }
      else
      {
        this.myselfBoxBase[0].SetActive(false);
        this.myselfBoxBase[1].SetActive(true);
      }
      this.textFlame = true;
    }
    else
    {
      this.charaTextBoxContainer.SetActive(true);
      this.myselfTextBoxContainer.SetActive(false);
      this.textFlame = false;
    }
    this.setBottomName();
  }

  public object setBackGround(string s)
  {
    this.doStartCoroutine(this.InitBackGround(s));
    return (object) s;
  }

  [DebuggerHidden]
  private IEnumerator InitBackGround(string s)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StoryExecuter.\u003CInitBackGround\u003Ec__Iterator56E()
    {
      s = s,
      \u003C\u0024\u003Es = s,
      \u003C\u003Ef__this = this
    };
  }

  public void setWait(float t, bool moveNext = false)
  {
    this.isWaitAndNext = moveNext;
    this.wait_command_time = t;
  }

  public void setColorAndTime(float r, float g, float b, float a, float to, float t)
  {
    this.fadeControl.r = r;
    this.fadeControl.g = g;
    this.fadeControl.b = b;
    this.fadeAlpha = a;
    this.fadeControl.fromAlpha = this.fadeAlpha;
    this.fadeControl.toAlpha = to;
    this.fadeControl.time = t;
  }

  public object startFlush(Color color, float time, int value)
  {
    this.flushControl.Start(color, time, value);
    return (object) string.Empty;
  }

  public void startFillrect()
  {
    this.fillrect = true;
    this.fadeControl.StartFillrect();
  }

  public void startFade()
  {
    this.fadeIn = (double) this.fadeAlpha == 1.0;
    this.fadeControl.StartFade();
  }

  public object setTextTopWindow(string s)
  {
    this.textContainerTop.SetActive(true);
    int boxName = this.getBoxName(s);
    for (int index = 0; index < this.textTopFlame.Length; ++index)
    {
      if (index == boxName)
      {
        this.textTopFlame[boxName].SetActive(true);
        if (boxName == 2)
        {
          ((IEnumerable<GameObject>) this.textTop3Nozzle).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
          if (this.charaPos == 1 || this.charaPos == 2)
            this.textTop3Nozzle[0].SetActive(true);
          else if (this.charaPos == 3)
            this.textTop3Nozzle[1].SetActive(true);
          else
            this.textTop3Nozzle[2].SetActive(true);
        }
      }
      else
        this.textTopFlame[index].SetActive(false);
    }
    return (object) s;
  }

  public object setTextBottomWindow(string s)
  {
    this.textContainerBottom.SetActive(true);
    int boxName = this.getBoxName(s);
    if (this.textFlame)
    {
      for (int index = 0; index < this.myselfTextBox.Length; ++index)
      {
        if (index == boxName)
          this.myselfTextBox[boxName].SetActive(true);
        else
          this.myselfTextBox[index].SetActive(false);
      }
    }
    else
    {
      this.charaTextBoxContainer.SetActive(true);
      for (int index = 0; index < this.myselfTextBox.Length; ++index)
      {
        if (index == 0)
          this.myselfTextBox[index].SetActive(true);
        else
          this.myselfTextBox[index].SetActive(false);
      }
      this.myselfTextBoxContainer.SetActive(false);
      for (int index = 0; index < this.textBottomFlame.Length; ++index)
      {
        if (index == boxName)
        {
          this.textBottomFlame[boxName].SetActive(true);
          if (boxName == 2)
          {
            ((IEnumerable<GameObject>) this.textBottom3Nozzle).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
            if (this.charaPos == 1 || this.charaPos == 2)
              this.textBottom3Nozzle[0].SetActive(true);
            else if (this.charaPos == 3)
              this.textBottom3Nozzle[1].SetActive(true);
            else
              this.textBottom3Nozzle[2].SetActive(true);
          }
        }
        else
          this.textBottomFlame[index].SetActive(false);
      }
    }
    return (object) s;
  }

  public void setTextClose(TextBlock.Position type)
  {
    if (type == TextBlock.Position.TOP)
      this.textContainerTop.SetActive(false);
    else
      this.textContainerBottom.SetActive(false);
  }

  public void setTextSize(int size, bool b)
  {
    if (b)
      this.textTopLabel.fontSize = size;
    else
      this.textBottomLabel.fontSize = size;
  }

  private string TranslateColor(string color)
  {
    string key = color;
    if (key != null)
    {
      // ISSUE: reference to a compiler-generated field
      if (StoryExecuter.\u003C\u003Ef__switch\u0024map19 == null)
      {
        // ISSUE: reference to a compiler-generated field
        StoryExecuter.\u003C\u003Ef__switch\u0024map19 = new Dictionary<string, int>(8)
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
            "green",
            2
          },
          {
            "blue",
            3
          },
          {
            "pink",
            4
          },
          {
            "red",
            5
          },
          {
            "normal",
            6
          },
          {
            "nomal",
            6
          }
        };
      }
      int num;
      // ISSUE: reference to a compiler-generated field
      if (StoryExecuter.\u003C\u003Ef__switch\u0024map19.TryGetValue(key, out num))
      {
        switch (num)
        {
          case 0:
            color = "000000";
            break;
          case 1:
            color = "FFFFFF";
            break;
          case 2:
            color = "00FF00";
            break;
          case 3:
            color = "0000FF";
            break;
          case 4:
            color = "FFBFCC";
            break;
          case 5:
            color = "FF0000";
            break;
          case 6:
            color = "330000";
            break;
        }
      }
    }
    return color;
  }

  public void SetColorText(TextBlock.Position pos, string color)
  {
    string str = this.TranslateColor(color);
    if (pos == TextBlock.Position.TOP)
      StoryExecuter.ColorDefault.Top = str;
    else
      StoryExecuter.ColorDefault.Bottom = str;
  }

  public void SetTextAlgin(TextBlock.Position pos, string align)
  {
    UILabel uiLabel = pos != TextBlock.Position.TOP ? this.textBottomLabel : this.textTopLabel;
    string key = align;
    NGUIText.Alignment alignment;
    if (key != null)
    {
      // ISSUE: reference to a compiler-generated field
      if (StoryExecuter.\u003C\u003Ef__switch\u0024map1A == null)
      {
        // ISSUE: reference to a compiler-generated field
        StoryExecuter.\u003C\u003Ef__switch\u0024map1A = new Dictionary<string, int>(5)
        {
          {
            "center",
            0
          },
          {
            "left",
            1
          },
          {
            "right",
            2
          },
          {
            "just",
            3
          },
          {
            "auto",
            4
          }
        };
      }
      int num;
      // ISSUE: reference to a compiler-generated field
      if (StoryExecuter.\u003C\u003Ef__switch\u0024map1A.TryGetValue(key, out num))
      {
        switch (num)
        {
          case 0:
            alignment = NGUIText.Alignment.Center;
            goto label_11;
          case 1:
            alignment = NGUIText.Alignment.Left;
            goto label_11;
          case 2:
            alignment = NGUIText.Alignment.Right;
            goto label_11;
          case 3:
            alignment = NGUIText.Alignment.Justified;
            goto label_11;
          case 4:
            alignment = NGUIText.Alignment.Automatic;
            goto label_11;
        }
      }
    }
    alignment = NGUIText.Alignment.Left;
label_11:
    uiLabel.alignment = alignment;
  }

  public void setTextShake(float t, bool b)
  {
    if (b)
    {
      this.textTopShake = this.textTopObj.GetComponent<TextShake>();
      this.textTopShake.timer = t;
      this.textTopObj.SendMessage("StartTextShake");
    }
    else
    {
      this.textBottomShake = this.textBottomObj.GetComponent<TextShake>();
      this.textBottomShake.timer = t;
      this.textBottomObj.SendMessage("StartTextShake");
    }
  }

  public void stopTextShake(bool b)
  {
    if (b)
      this.textTopObj.SendMessage("StopTextShake");
    else
      this.textBottomObj.SendMessage("StopTextShake");
  }

  public object setShake(float w, float t)
  {
    this.shakecontrol = this.windowObj.GetComponent<ShakeControl>();
    this.shakecontrol.wieght = w;
    this.shakecontrol.waitTime = t;
    this.windowObj.SendMessage("StartShake");
    return (object) t;
  }

  public void stopShake() => this.windowObj.SendMessage("StopShake");

  public object setStack(int n) => (object) n;

  public object setEmotion() => (object) string.Empty;

  public object deleteEmotion() => (object) string.Empty;

  public object setEmotionBright() => (object) string.Empty;

  public object setSe(string clip, float delay = 0.0f)
  {
    if (this.plsySEDataList == null)
      this.plsySEDataList = new List<PlaySEData>();
    this.sm = Singleton<NGSoundManager>.GetInstance();
    this.plsySEDataList.Add(new PlaySEData(clip, this.sm.playSE(clip, delay: delay)));
    return (object) clip;
  }

  public object stopSe(string clip, float delay = 0.0f)
  {
    if (this.plsySEDataList == null || this.plsySEDataList.Count <= 0)
      return (object) clip;
    PlaySEData playSeData = this.plsySEDataList.Find((Predicate<PlaySEData>) (x => x.clip == clip));
    if (playSeData == null)
      return (object) clip;
    this.plsySEDataList.Remove(playSeData);
    this.StartCoroutine(this.delayStopSe(playSeData.ch, delay));
    return (object) clip;
  }

  [DebuggerHidden]
  public IEnumerator delayStopSe(int ch, float delay = 0.0f)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StoryExecuter.\u003CdelayStopSe\u003Ec__Iterator56F()
    {
      delay = delay,
      ch = ch,
      \u003C\u0024\u003Edelay = delay,
      \u003C\u0024\u003Ech = ch,
      \u003C\u003Ef__this = this
    };
  }

  public void stopSeAll()
  {
    if (this.plsySEDataList == null)
      return;
    this.plsySEDataList.ForEach((Action<PlaySEData>) (x => this.StartCoroutine(this.delayStopSe(x.ch))));
  }

  public object setVoice(string charaID, string name, float delay = 0.0f)
  {
    if (!this.skip_enable)
    {
      this.sm = Singleton<NGSoundManager>.GetInstance();
      this.sm.playVoiceByStringID("VO_" + charaID, name, delay: delay);
    }
    return (object) name;
  }

  public void setBgm(string s, float time = 0.7f)
  {
    Singleton<NGSoundManager>.GetInstance().PlayBgm(s, fadeInTime: time, fadeOutTime: time);
  }

  public void setBgmFile(string file, string s, float time = 0.7f)
  {
    Singleton<NGSoundManager>.GetInstance().PlayBgmFile(file, s, fadeInTime: time, fadeOutTime: time);
  }

  public void stopBgm()
  {
    this.sm = Singleton<NGSoundManager>.GetInstance();
    this.sm.stopBGMWithFadeOut(this.stopBGMTime);
  }

  public void StartSelect(SelectBlock sb)
  {
    this.selectObj.SetActive(true);
    for (int index = 0; index < 3; ++index)
    {
      if (index < sb.data.Count)
      {
        this.select[index].SetActive(true);
        this.SelectLabel[index].SetTextLocalize(sb.data[index].msg);
      }
    }
    this.InitStartSelect();
    this.quastion.SetTextLocalize(this.environment.current.text.text);
    this.skip_enable = false;
  }

  private void InitStartSelect()
  {
    foreach (GameObject gameObject in this.select)
    {
      UISprite componentInChildren = gameObject.GetComponentInChildren<UISprite>();
      if (!Object.op_Equality((Object) componentInChildren, (Object) null))
      {
        componentInChildren.color = Color.white;
        ((Component) componentInChildren).GetComponent<Collider>().enabled = true;
      }
    }
  }

  public void PopupStoryEffect(string label) => this.doStartCoroutine(this.ShowStoryEffect(label));

  [DebuggerHidden]
  private IEnumerator ShowStoryEffect(string label)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StoryExecuter.\u003CShowStoryEffect\u003Ec__Iterator570()
    {
      label = label,
      \u003C\u0024\u003Elabel = label
    };
  }

  private void resetCoroutine() => this.coroutineCount = 0;

  [DebuggerHidden]
  private IEnumerator execCoroutine(IEnumerator e)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StoryExecuter.\u003CexecCoroutine\u003Ec__Iterator571()
    {
      e = e,
      \u003C\u0024\u003Ee = e,
      \u003C\u003Ef__this = this
    };
  }

  private void doStartCoroutine(IEnumerator e) => this.StartCoroutine(this.execCoroutine(e));

  public bool isRenderDone => this.coroutineCount == 0;

  public void PlayMovie(string fileName, bool enabledSkip)
  {
    if (this.skip_enable)
      return;
    NGSoundManager sm = Singleton<NGSoundManager>.GetInstance();
    string nowBgmName = sm.GetBgmName();
    this.movieObj.Attach(fileName, enabledSkip, (System.Action) (() =>
    {
      sm.PlayBgm(nowBgmName);
      this.movieObj.ShowMainPanel();
    }));
  }

  public StoryExecuter.CharacterInfo setHenshin(
    int uniqueId,
    int dataId,
    int beforeId,
    int afterId)
  {
    StoryExecuter.CharacterInfo characterInfo1;
    StoryExecuter.CharacterInfo characterInfo2;
    StoryExecuter.CharacterInfo characterInfo3;
    if (!this.characterList.TryGetValue(uniqueId, out characterInfo1) && this.characterList.TryGetValue(beforeId, out characterInfo2) && this.characterList.TryGetValue(afterId, out characterInfo3) && characterInfo2.parentId == 0 && characterInfo3.parentId == 0)
    {
      characterInfo1 = new StoryExecuter.CharacterInfo();
      this.characterList.Add(uniqueId, characterInfo1);
      characterInfo1.obj = Object.Instantiate<GameObject>(this.CharacterPrefab);
      characterInfo1.obj.transform.localPosition = Vector3.zero;
      characterInfo1.obj.transform.localScale = Vector3.one;
      characterInfo1.obj.transform.parent = this.windowObj.transform;
      ((Behaviour) characterInfo1.obj.GetComponent<TweenPosition>()).enabled = false;
      characterInfo2.parentId = uniqueId;
      characterInfo3.parentId = uniqueId;
      characterInfo1.child = new int[2]{ beforeId, afterId };
      this.doStartCoroutine(characterInfo1.obj.GetComponent<HenshinControl>().coSetUnit(dataId, characterInfo2.obj, characterInfo3.obj));
    }
    return characterInfo1;
  }

  public void startHenshin(int uniqueId)
  {
    StoryExecuter.CharacterInfo characterInfo;
    if (!this.characterList.TryGetValue(uniqueId, out characterInfo))
      return;
    characterInfo.obj.GetComponent<HenshinControl>().startHenshin();
  }

  public void skipHenshin(int uniqueId)
  {
    StoryExecuter.CharacterInfo characterInfo;
    if (!this.characterList.TryGetValue(uniqueId, out characterInfo))
      return;
    characterInfo.obj.GetComponent<HenshinControl>().skipHenshin();
  }

  public StoryExecuter.CharacterInfo setPerson(int unique_id, int chara_id)
  {
    StoryExecuter.CharacterInfo characterInfo;
    if (!this.characterList.TryGetValue(unique_id, out characterInfo))
    {
      characterInfo = new StoryExecuter.CharacterInfo();
      this.characterList.Add(unique_id, characterInfo);
      characterInfo.obj = Object.Instantiate<GameObject>(this.CharacterPrefab);
      characterInfo.obj.transform.localPosition = new Vector3(500f, 0.0f, 0.0f);
      characterInfo.obj.transform.localScale = Vector3.one;
      characterInfo.obj.transform.parent = this.windowObj.transform;
      ((Behaviour) characterInfo.obj.GetComponent<TweenPosition>()).enabled = false;
      this.getUnit(unique_id, chara_id, this.characterList.Count<KeyValuePair<int, StoryExecuter.CharacterInfo>>());
    }
    return characterInfo;
  }

  private void getUnit(int unique_id, int chara_id, int layer = 1)
  {
    StoryExecuter.CharacterInfo character = this.characterList[unique_id];
    character.image = this.storyResource.GetCharacterPrefab(chara_id).Clone(character.obj.transform);
    if (chara_id > 999)
      MasterData.UnitUnit[chara_id].SetStoryData(character.image);
    character.obj.GetComponent<Clash>().windowObj = this.mainPanel;
    character.image.GetComponent<NGxMaskSpriteWithScale>().MainUI2DSprite.sprite2D = this.storyResource.GetLargeTexture(chara_id);
    this.setMaskChange(character);
    UIWidget w = character.image.GetComponent<UIWidget>();
    w.depth = 5;
    Transform[] componentsInChildren = ((Component) character.image.transform).GetComponentsInChildren<Transform>();
    ((IEnumerable<Transform>) componentsInChildren).Where<Transform>((Func<Transform, bool>) (v => ((Object) v).name == "face")).ForEach<Transform>((Action<Transform>) (v => ((Component) v).GetComponent<UIWidget>().depth = w.depth + 1));
    ((IEnumerable<Transform>) componentsInChildren).Where<Transform>((Func<Transform, bool>) (v => ((Object) v).name == "eye")).ForEach<Transform>((Action<Transform>) (v => ((Component) v).GetComponent<UIWidget>().depth = w.depth + 2));
  }

  public void setMaskChange(int id) => this.setMaskChange(this.setPerson(id, id));

  public void setMaskChange(StoryExecuter.CharacterInfo chara)
  {
    if (Object.op_Equality((Object) chara.image, (Object) null))
      return;
    NGxMaskSpriteWithScale component = chara.image.GetComponent<NGxMaskSpriteWithScale>();
    if (Object.op_Equality((Object) component, (Object) null))
      return;
    int index = Mathf.Clamp(chara.pos - 1, 0, this.mSprite.Length - 1);
    component.maskTexture = this.mSprite[index];
    component.FitMask();
  }

  public void setCharaPosition(int id, int pos)
  {
    StoryExecuter.CharacterInfo chara = this.setPerson(id, id);
    chara.pos = pos;
    chara.obj.transform.localPosition = this.positions[pos - 1];
    this.setMaskChange(chara);
  }

  public void getCharaPosition(int id)
  {
    StoryExecuter.CharacterInfo chara = this.setPerson(id, id);
    this.charaPos = chara.pos;
    this.setMaskChange(chara);
  }

  public void setFace(int id, string s)
  {
    StoryExecuter.CharacterInfo characterInfo = this.setPerson(id, id);
    characterInfo.faceName = s;
    NGxFaceSprite component = characterInfo.image.GetComponent<NGxFaceSprite>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    this.doStartCoroutine(component.ChangeFace(s));
  }

  public void setEye(int id, string s)
  {
    StoryExecuter.CharacterInfo characterInfo = this.setPerson(id, id);
    characterInfo.eyeName = s;
    NGxEyeSprite component = characterInfo.image.GetComponent<NGxEyeSprite>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    ((Behaviour) component).enabled = true;
    ((Component) component.EyeUI2DSprite).gameObject.SetActive(true);
    this.doStartCoroutine(component.ChangeEye(s));
  }

  public void setCharaMoveIn(int id, float time, float pos)
  {
    StoryExecuter.CharacterInfo chara = this.setPerson(id, id);
    Vector3 localPosition = chara.obj.transform.localPosition;
    chara.obj.transform.localPosition = new Vector3(pos, 0.0f, 0.0f);
    if (this.skip_enable)
      TweenPosition.Begin(chara.obj, 0.1f, localPosition);
    else
      TweenPosition.Begin(chara.obj, time, localPosition);
    chara.pos = (double) localPosition.x >= 0.0 ? ((double) localPosition.x <= 0.0 ? 2 : 4) : 0;
    this.setMaskChange(chara);
  }

  public void setCharaMoveOut(int id, float time, float pos)
  {
    StoryExecuter.CharacterInfo chara = this.setPerson(id, id);
    if (this.skip_enable)
      TweenPosition.Begin(chara.obj, 0.1f, new Vector3(pos, 0.0f, 0.0f));
    else
      TweenPosition.Begin(chara.obj, time, new Vector3(pos, 0.0f, 0.0f));
    this.setMaskChange(chara);
  }

  public void setCharaScale(int id, float size, float time)
  {
    StoryExecuter.CharacterInfo chara = this.setPerson(id, id);
    if (this.skip_enable)
      TweenScale.Begin(chara.obj, 0.1f, new Vector3(size, size, 1f));
    else
      TweenScale.Begin(chara.obj, time, new Vector3(size, size, 1f));
    this.setMaskChange(chara);
  }

  public void setJump(int id)
  {
    StoryExecuter.CharacterInfo chara = this.setPerson(id, id);
    this.jump = chara.obj.GetComponent<Jump>();
    this.jump.state = Jump.JumpEffect.Start;
    this.setMaskChange(chara);
  }

  public void setClash(int id)
  {
    Clash component = this.setPerson(id, id).obj.GetComponent<Clash>();
    if (this.skip_enable)
      component.isSkip = true;
    component.state = Clash.State.Start;
  }

  public void setMoveChara(int id, int pos, float time)
  {
    StoryExecuter.CharacterInfo chara = this.setPerson(id, id);
    this.charaPos = chara.pos = pos;
    TweenPosition.Begin(chara.obj, !this.skip_enable ? time : 0.1f, this.positions[pos - 1]);
    this.setMaskChange(chara);
  }

  public void setCharaReversal(int id, bool b)
  {
    this.setPerson(id, id).obj.transform.localRotation = new Quaternion(0.0f, !b ? 0.0f : 180f, 0.0f, 0.0f);
  }

  public void setCharaBrightness(int id, float c, float t)
  {
    StoryExecuter.CharacterInfo chara = this.setPerson(id, id);
    GameObject image = chara.image;
    TweenColor component1 = image.GetComponent<TweenColor>();
    GameObject gameObject = ((Component) image.transform.Find("face")).gameObject;
    TweenColor component2 = gameObject.GetComponent<TweenColor>();
    if (Object.op_Equality((Object) component1, (Object) null) && Object.op_Equality((Object) component2, (Object) null))
    {
      image.AddComponent<TweenColor>();
      gameObject.AddComponent<TweenColor>();
    }
    if (this.skip_enable)
    {
      TweenColor.Begin(image, 0.1f, new Color(c, c, c));
      TweenColor.Begin(gameObject, 0.1f, new Color(c, c, c));
    }
    else
    {
      TweenColor.Begin(image, t, new Color(c, c, c));
      TweenColor.Begin(gameObject, t, new Color(c, c, c));
    }
    this.setMaskChange(chara);
  }

  public void setCharaAlpha(int id, float alpha, float time)
  {
    StoryExecuter.CharacterInfo chara = this.setPerson(id, id);
    TweenAlpha.Begin(chara.obj, !this.skip_enable ? time : 0.1f, alpha);
    this.setMaskChange(chara);
  }

  public void setCharaLayer(int id, int depth)
  {
    StoryExecuter.CharacterInfo chara = this.setPerson(id, id);
    UIWidget w = chara.image.GetComponent<UIWidget>();
    w.depth = (depth + 1) * 5;
    Transform[] componentsInChildren = ((Component) chara.image.transform).GetComponentsInChildren<Transform>();
    ((IEnumerable<Transform>) componentsInChildren).Where<Transform>((Func<Transform, bool>) (v => ((Object) v).name == "face")).ForEach<Transform>((Action<Transform>) (v => ((Component) v).GetComponent<UIWidget>().depth = w.depth + 1));
    ((IEnumerable<Transform>) componentsInChildren).Where<Transform>((Func<Transform, bool>) (v => ((Object) v).name == "eye")).ForEach<Transform>((Action<Transform>) (v => ((Component) v).GetComponent<UIWidget>().depth = w.depth + 2));
    this.setMaskChange(chara);
  }

  public void deleteUnit(int id)
  {
    StoryExecuter.CharacterInfo info;
    if (!this.characterList.TryGetValue(id, out info))
      return;
    if (info.child != null && info.child.Length > 0)
    {
      foreach (int key in this.getChildIdsInCharacterInfo(info))
        this.characterList.Remove(key);
    }
    StoryExecuter.CharacterInfo characterInfo;
    if (info.parentId != 0 && this.characterList.TryGetValue(info.parentId, out characterInfo))
      characterInfo.child = ((IEnumerable<int>) characterInfo.child).Where<int>((Func<int, bool>) (i => i != id)).ToArray<int>();
    Object.Destroy((Object) info.obj);
    this.characterList.Remove(id);
  }

  private List<int> getChildIdsInCharacterInfo(StoryExecuter.CharacterInfo info)
  {
    List<int> idsInCharacterInfo = new List<int>();
    foreach (int key in info.child)
    {
      StoryExecuter.CharacterInfo character = this.characterList[key];
      if (character.child != null && character.child.Length > 0)
        idsInCharacterInfo.AddRange((IEnumerable<int>) this.getChildIdsInCharacterInfo(character));
      idsInCharacterInfo.Add(key);
    }
    return idsInCharacterInfo;
  }

  public void SetMaskEnable(int id, bool enable)
  {
    StoryExecuter.CharacterInfo characterInfo = this.setPerson(id, id);
    NGxMaskSpriteWithScale component = !Object.op_Inequality((Object) characterInfo.image, (Object) null) ? (NGxMaskSpriteWithScale) null : characterInfo.image.GetComponent<NGxMaskSpriteWithScale>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    component.SetMaskEnable(enable);
  }

  public void stopDistinction()
  {
  }

  public void setUnitDistinction(int id, int which)
  {
  }

  public StoryExecuter.CharacterInfo setEmotion(
    int uniqueId,
    int dataId,
    int noColor,
    int parentId,
    int offsetX,
    int offsetY)
  {
    StoryExecuter.CharacterInfo characterInfo1;
    StoryExecuter.CharacterInfo characterInfo2;
    if (!this.characterList.TryGetValue(uniqueId, out characterInfo1) && this.characterList.TryGetValue(parentId, out characterInfo2))
    {
      characterInfo1 = new StoryExecuter.CharacterInfo();
      this.characterList.Add(uniqueId, characterInfo1);
      characterInfo1.obj = Object.Instantiate<GameObject>(this.CharacterPrefab);
      characterInfo1.obj.transform.parent = characterInfo2.obj.transform;
      characterInfo1.obj.transform.localPosition = Vector2.op_Implicit(new Vector2((float) offsetX, (float) offsetY));
      characterInfo1.obj.transform.localScale = Vector3.one;
      characterInfo1.obj.transform.localRotation = Quaternion.identity;
      ((Behaviour) characterInfo1.obj.GetComponent<TweenPosition>()).enabled = false;
      characterInfo1.parentId = parentId;
      StoryExecuter.CharacterInfo characterInfo3 = characterInfo2;
      int[] numArray;
      if (characterInfo2.child != null)
        numArray = ((IEnumerable<int>) characterInfo2.child).Concat<int>((IEnumerable<int>) new int[1]
        {
          uniqueId
        }).ToArray<int>();
      else
        numArray = new int[1]{ uniqueId };
      characterInfo3.child = numArray;
      this.doStartCoroutine(characterInfo1.obj.GetComponent<StoryEffectControl>().coInitializeEmotion(dataId, noColor));
    }
    return characterInfo1;
  }

  public StoryExecuter.CharacterInfo setEnvEffect(int uniqueId, int dataId, int noColor)
  {
    StoryExecuter.CharacterInfo characterInfo;
    if (!this.characterList.TryGetValue(uniqueId, out characterInfo))
    {
      characterInfo = new StoryExecuter.CharacterInfo();
      this.characterList.Add(uniqueId, characterInfo);
      characterInfo.obj = Object.Instantiate<GameObject>(this.CharacterPrefab);
      characterInfo.obj.transform.parent = this.windowObj.transform;
      characterInfo.obj.transform.localPosition = Vector3.zero;
      characterInfo.obj.transform.localScale = Vector3.one;
      characterInfo.obj.transform.localRotation = Quaternion.identity;
      ((Behaviour) characterInfo.obj.GetComponent<TweenPosition>()).enabled = false;
      this.doStartCoroutine(characterInfo.obj.GetComponent<StoryEffectControl>().coInitializeEnvironment(dataId, noColor));
    }
    return characterInfo;
  }

  public StoryExecuter.CharacterInfo setEffect(
    int uniqueId,
    int dataId,
    int noColor,
    int positionX,
    int positionY)
  {
    StoryExecuter.CharacterInfo characterInfo;
    if (!this.characterList.TryGetValue(uniqueId, out characterInfo))
    {
      characterInfo = new StoryExecuter.CharacterInfo();
      this.characterList.Add(uniqueId, characterInfo);
      characterInfo.obj = Object.Instantiate<GameObject>(this.CharacterPrefab);
      characterInfo.obj.transform.parent = this.windowObj.transform;
      characterInfo.obj.transform.localPosition = Vector2.op_Implicit(new Vector2((float) positionX, (float) positionY));
      characterInfo.obj.transform.localScale = Vector3.one;
      characterInfo.obj.transform.localRotation = Quaternion.identity;
      ((Behaviour) characterInfo.obj.GetComponent<TweenPosition>()).enabled = false;
      this.doStartCoroutine(characterInfo.obj.GetComponent<StoryEffectControl>().coInitializeEffect(dataId, noColor));
    }
    return characterInfo;
  }

  public void startEffect(int uniqueId)
  {
    StoryExecuter.CharacterInfo characterInfo;
    if (!this.characterList.TryGetValue(uniqueId, out characterInfo))
      return;
    characterInfo.obj.GetComponent<StoryEffectControl>().startEffect();
  }

  public void skipEffect(int uniqueId)
  {
    StoryExecuter.CharacterInfo characterInfo;
    if (!this.characterList.TryGetValue(uniqueId, out characterInfo))
      return;
    characterInfo.obj.GetComponent<StoryEffectControl>().skipEffect();
  }

  public void changeEffect(int uniqueId, int noPattern, int noColor)
  {
    StoryExecuter.CharacterInfo characterInfo;
    if (!this.characterList.TryGetValue(uniqueId, out characterInfo))
      return;
    characterInfo.obj.GetComponent<StoryEffectControl>().changeEffect(noPattern, noColor);
  }

  public void setImageName(int id, string name)
  {
    if (!this.imageInfo.ContainsKey(id))
      this.imageInfo.Add(id, new StoryExecuter.ImageInfo());
    if (name == string.Empty)
    {
      this.imageObj[id].SetActive(false);
    }
    else
    {
      this.imageObj[id].SetActive(true);
      this.imageInfo[id].obj = this.imageObj[id];
      this.imageInfo[id].name = name;
      Singleton<ResourceManager>.GetInstance().Load<Sprite>("AssetBundle/Resources/EventImages/" + name).RunOn<Sprite>((MonoBehaviour) this, (Action<Sprite>) (s =>
      {
        UI2DSprite component = this.imageInfo[id].obj.GetComponent<UI2DSprite>();
        component.sprite2D = s;
        UI2DSprite ui2Dsprite1 = component;
        Rect textureRect1 = s.textureRect;
        int width = (int) ((Rect) ref textureRect1).width;
        ui2Dsprite1.width = width;
        UI2DSprite ui2Dsprite2 = component;
        Rect textureRect2 = s.textureRect;
        int height = (int) ((Rect) ref textureRect2).height;
        ui2Dsprite2.height = height;
        ((Component) component).transform.localPosition = new Vector3(2500f, 0.0f, 0.0f);
      }));
    }
  }

  public void setImagePriority(int id, int priority)
  {
    if (!this.imageInfo.ContainsKey(id))
      this.imageInfo.Add(id, new StoryExecuter.ImageInfo());
    this.imageInfo[id].priority = priority;
    this.imageInfo[id].obj.GetComponent<UI2DSprite>().depth = priority + 100;
  }

  public void setImagePosition(int id, float x, float y)
  {
    if (!this.imageInfo.ContainsKey(id))
      this.imageInfo.Add(id, new StoryExecuter.ImageInfo());
    this.imageInfo[id].x = x;
    this.imageInfo[id].y = y;
    this.imageInfo[id].obj.transform.localPosition = new Vector3(x, y, 0.0f);
  }

  public void setImageAlpha(int id, float alpha, float time)
  {
    if (!this.imageInfo.ContainsKey(id))
      this.imageInfo.Add(id, new StoryExecuter.ImageInfo());
    this.imageInfo[id].alpha = alpha;
    TweenAlpha.Begin(this.imageInfo[id].obj, !this.skip_enable ? time : 0.1f, alpha);
  }

  public void setImageScale(int id, float scale, float time)
  {
    if (!this.imageInfo.ContainsKey(id))
      this.imageInfo.Add(id, new StoryExecuter.ImageInfo());
    this.imageInfo[id].scale = scale;
    TweenScale.Begin(this.imageInfo[id].obj, !this.skip_enable ? time : 0.1f, new Vector3(scale, scale, 1f));
  }

  public void setImageMoveIn(int id, float time, float x, float y)
  {
    if (!this.imageInfo.ContainsKey(id))
      this.imageInfo.Add(id, new StoryExecuter.ImageInfo());
    GameObject go = this.imageInfo[id].obj;
    Vector3 localPosition = go.transform.localPosition;
    Vector3 pos;
    // ISSUE: explicit constructor call
    ((Vector3) ref pos).\u002Ector(localPosition.x, localPosition.y, localPosition.z);
    go.transform.localPosition = new Vector3(x, y, localPosition.z);
    TweenPosition.Begin(go, !this.skip_enable ? time : 0.1f, pos);
  }

  public void setImageMoveOut(int id, float time, float x, float y)
  {
    if (!this.imageInfo.ContainsKey(id))
      this.imageInfo.Add(id, new StoryExecuter.ImageInfo());
    GameObject go = this.imageInfo[id].obj;
    Vector3 localPosition = go.transform.localPosition;
    Vector3 pos;
    // ISSUE: explicit constructor call
    ((Vector3) ref pos).\u002Ector(x, y, localPosition.z);
    TweenPosition.Begin(go, !this.skip_enable ? time : 0.1f, pos);
  }

  private static class ColorDefault
  {
    public static string Top { get; set; }

    public static string Bottom { get; set; }
  }

  public class CharacterInfo
  {
    public GameObject obj;
    public GameObject image;
    public int pos;
    public string faceName = "normal";
    public string eyeName = "normal";
    public int parentId;
    public int[] child;
  }

  private class ImageInfo
  {
    public GameObject obj;
    public string name;
    public int priority;
    public float x;
    public float y;
    public float alpha;
    public float scale;
  }
}
