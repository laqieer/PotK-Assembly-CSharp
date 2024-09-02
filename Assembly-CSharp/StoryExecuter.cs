// Decompiled with JetBrains decompiler
// Type: StoryExecuter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class StoryExecuter : BackButtonMonoBehaiviour
{
  [SerializeField]
  private bool isAutoPlay_;
  [SerializeField]
  private float waitNextAutoPlay_ = 0.5f;
  [SerializeField]
  private GameObject btnAutoON_;
  [SerializeField]
  private GameObject btnAutoOFF_;
  private float timeNextAutoPlay_;
  private List<Func<bool>> lstFunctionWait_ = new List<Func<bool>>();
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
  [SerializeField]
  private string rgbTextNormal_ = "330000";
  [SerializeField]
  private float fadeInTime_ = 0.5f;
  public List<PlaySEData> plsySEDataList = new List<PlaySEData>();
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
  public float skip_wait = 0.2f;
  public float select_button_wait = 1f;
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
  public SpriteSelectDirect nameTopBox;
  public SpriteSelectDirect nameBottomBox;
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
  public int charsPerSecond = 40;
  public float stopBGMTime = 0.5f;
  public GameObject skipBtn;
  private StoryExecuter.ScriptMode modeScript_;
  private System.Action<int, int> onSelected_;
  private int countSelect_;
  private bool _isFinished;
  private StoryEnvironment environment = new StoryEnvironment();
  private StoryResource storyResource = new StoryResource();
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
  private float select_wait = 1f;
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
  private List<GameObject> units = new List<GameObject>();
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
  private int scriptId = -1;
  private List<Story0093Scene.ContinuousData> continuousDataList = new List<Story0093Scene.ContinuousData>();
  public bool continuousPopupView;
  private System.Action endAction;
  public const string lastScriptIdKey = "LastScriptId";
  private Dictionary<int, StoryExecuter.CharacterInfo> characterList = new Dictionary<int, StoryExecuter.CharacterInfo>();
  [SerializeField]
  private FadeControl fadeSubControl_;
  [SerializeField]
  private int[] subFillrectDepths_ = new int[2]{ 1, 100 };
  [SerializeField]
  private GameObject frameTop_;
  [SerializeField]
  private GameObject frameBottom_;
  [SerializeField]
  private StoryExecuter.FramePositions[] frameOutPositions_;
  [SerializeField]
  private GameObject topButtons_;
  [SerializeField]
  private Vector2[] buttonOutPositions_;
  private bool fillrectSub_;
  private Dictionary<int, StoryExecuter.ImageInfo> imageInfo = new Dictionary<int, StoryExecuter.ImageInfo>();

  private bool checkWaitAutoPlay()
  {
    int index = 0;
    while (index < this.lstFunctionWait_.Count)
    {
      if (this.lstFunctionWait_[index]())
        ++index;
      else
        this.lstFunctionWait_.RemoveAt(index);
    }
    return this.lstFunctionWait_.Count > 0;
  }

  private void addWaitAutoPlay(Func<bool> execWait)
  {
    if (execWait == null)
      return;
    this.lstFunctionWait_.Add(execWait);
    this.timeNextAutoPlay_ = this.waitNextAutoPlay_;
  }

  private bool isNextAutoPlay()
  {
    if ((double) this.timeNextAutoPlay_ > 0.0)
      this.timeNextAutoPlay_ -= Time.deltaTime;
    return (double) this.timeNextAutoPlay_ <= 0.0;
  }

  private void clearWaitAutoPlay()
  {
    this.lstFunctionWait_.Clear();
    this.timeNextAutoPlay_ = this.waitNextAutoPlay_;
  }

  private void initAutoPlay()
  {
    this.setStatusAutoPlay(this.isAutoPlay_);
    this.clearWaitAutoPlay();
  }

  private void setStatusAutoPlay(bool isAutoPlay)
  {
    this.btnAutoON_.SetActive(!isAutoPlay);
    this.btnAutoOFF_.SetActive(isAutoPlay);
    this.isAutoPlay_ = isAutoPlay;
  }

  public void onClickedAutoPlayON()
  {
    this.setStatusAutoPlay(true);
    this.saveOptionSetting();
  }

  public void onClickedAutoPlayOFF()
  {
    this.setStatusAutoPlay(false);
    this.saveOptionSetting();
  }

  private void saveOptionSetting()
  {
    Persist<Persist.StoryOptions> storyOptions = Persist.storyOptions;
    storyOptions.Data.autoPlayEnable = this.isAutoPlay_;
    storyOptions.Flush();
  }

  private void loadOptionSetting() => this.isAutoPlay_ = Persist.storyOptions.Data.autoPlayEnable;

  private bool isFinished
  {
    set
    {
      NGBattleManager instance = Singleton<NGBattleManager>.GetInstance();
      if ((UnityEngine.Object) instance != (UnityEngine.Object) null && instance.CharacterQuestAfterBattleInfo != null && (instance.CharacterQuestAfterBattleScriptId != 0 && this.endAction != null))
        this._isFinished = false;
      else
        this._isFinished = value;
    }
  }

  protected override void Update()
  {
    base.Update();
    if (!this.isInitializeDone || this._isFinished)
      return;
    bool flag = this.checkWaitAutoPlay();
    if (this.skip_enable && this.environment.SkipReady())
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
    else if (!this.backlog_manager.IsEnable() && !this.continuousPopupView && (this.isWaitAndNext && this.typewriterText == null || this.isAutoPlay_ && !flag && (this.typewriterText == null && this.isNextAutoPlay())))
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
    else if (this.fillrect)
    {
      this.fillrect = false;
      this.fadeControl.time = 0.0f;
      this.fadeControl.StartFillrect();
    }
    this.fadeSubNextExit();
  }

  public void setMode(StoryExecuter.ScriptMode mode) => this.modeScript_ = mode;

  public void setEventSelected(System.Action<int, int> eventSelected) => this.onSelected_ = eventSelected;

  private void callEventSelected(int index)
  {
    if (this.onSelected_ != null)
      this.onSelected_(this.countSelect_, index);
    ++this.countSelect_;
  }

  public IEnumerator initialize(
    string text,
    System.Action endAction = null,
    int scriptId = -1,
    List<Story0093Scene.ContinuousData> continuousDataList = null)
  {
    StoryExecuter exec = this;
    exec._isFinished = false;
    exec.isInitializeDone = false;
    exec.scriptId = scriptId;
    exec.continuousDataList = continuousDataList;
    PlayerPrefs.SetInt("LastScriptId", scriptId);
    PlayerPrefs.Save();
    exec.continuousPopupView = false;
    exec.loadOptionSetting();
    exec.plsySEDataList = (List<PlaySEData>) null;
    exec.plsySEDataList = new List<PlaySEData>();
    exec.plsySEDataList.Clear();
    StoryExecuter.ColorDefault.Bottom = exec.rgbTextNormal_;
    StoryExecuter.ColorDefault.Top = exec.rgbTextNormal_;
    if (text == null)
      text = exec.storyText.text;
    exec.resetButton.SetActive(exec.isReset);
    exec.backButton.SetActive(exec.isBack);
    exec.initAutoPlay();
    IEnumerator e = exec.DeleteObject();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    exec.charaPos = 0;
    exec.textContainerTop.SetActive(false);
    exec.textContainerBottom.SetActive(true);
    Future<UnityEngine.Sprite> spriteF = Res.GUI._009_3_sozai.mask_Chara_L.Load<UnityEngine.Sprite>();
    e = spriteF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    exec.mSprite[0] = spriteF.Result.texture;
    spriteF = Res.GUI._009_3_sozai.mask_Chara_L.Load<UnityEngine.Sprite>();
    e = spriteF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    exec.mSprite[1] = spriteF.Result.texture;
    spriteF = Res.GUI._009_3_sozai.mask_Chara_C.Load<UnityEngine.Sprite>();
    e = spriteF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    exec.mSprite[2] = spriteF.Result.texture;
    spriteF = Res.GUI._009_3_sozai.mask_Chara_R.Load<UnityEngine.Sprite>();
    e = spriteF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    exec.mSprite[3] = spriteF.Result.texture;
    spriteF = Res.GUI._009_3_sozai.mask_Chara_R.Load<UnityEngine.Sprite>();
    e = spriteF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    exec.mSprite[4] = spriteF.Result.texture;
    Future<GameObject> bg1 = Res.Prefabs.BackGround.storyBGprefab.Load<GameObject>();
    e = bg1.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    exec.bgObj = bg1.Result.Clone(exec.windowObj.transform);
    exec.bgObj.transform.localPosition = new Vector3(0.0f, 50f, 0.0f);
    Future<GameObject> charaFuture = Res.Prefabs.ADVCharacter.Load<GameObject>();
    e = charaFuture.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    exec.CharacterPrefab = charaFuture.Result;
    exec.environment.initialize(text, exec);
    e = exec.storyResource.Run(exec.environment.all());
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    exec.isInitializeDone = true;
    exec.endAction = endAction;
  }

  public void onEndScene()
  {
    this.stopSeAll();
    this.stopVoiceAll();
  }

  public IEnumerator DeleteObject()
  {
    foreach (UnityEngine.Object unit in this.units)
      UnityEngine.Object.Destroy(unit);
    this.units.Clear();
    this.windowObj.SendMessage("StopShake");
    this.setColorAndTime(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
    this.fadeControl.StartFade();
    if (this.re)
    {
      this.re = false;
      this.render();
      yield break;
    }
  }

  private IEnumerator typewriterEffect(string text, UILabel targetLabel)
  {
    int offset = 0;
    float nextChar = 0.0f;
    int cps = this.charsPerSecond;
    if (this.typewriterText == text)
      text = (string) null;
    this.typewriterText = text;
    while (true)
    {
      NGUIText.ParseSymbol(text, ref offset);
      if (offset < text.Length)
      {
        if ((double) nextChar <= (double) RealTime.time)
        {
          cps = Mathf.Max(1, cps);
          float num = 1f / (float) cps;
          switch (text[offset])
          {
            case '\n':
            case '!':
            case '?':
            case '、':
            case '。':
            case '・':
            case '！':
            case '？':
              num *= 4f;
              break;
          }
          nextChar = RealTime.time + num;
          this.setTextBox();
          this.setNameMsgBright();
          this.GetLabelIncludeText(text, targetLabel, ++offset).SetDirty();
        }
        yield return (object) null;
      }
      else
        break;
    }
    this.typewriterText = (string) null;
  }

  private void renderText(string text, bool isEffect = true)
  {
    UILabel uiLabel = this.environment.current.text.pos == TextBlock.Position.BOTTOM ? this.textBottomLabel : this.textTopLabel;
    if (uiLabel.alignment != NGUIText.Alignment.Center & isEffect)
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
      this.box.enabled = false;
    }
    else
    {
      for (int index = 0; index < 3; ++index)
        this.select[index].SetActive(false);
      this.selectObj.SetActive(false);
      this.box.enabled = true;
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
    this.clearWaitAutoPlay();
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
      if ((UnityEngine.Object) this.CNM != (UnityEngine.Object) null)
      {
        this.CNM.left = CutinNameManager.LeftState.End;
        this.CNM.right = CutinNameManager.RightState.End;
        this.CNM.center = CutinNameManager.CenterState.End;
      }
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
        if (!this.storyContinuous())
        {
          this.backScene();
          this.skip_enable = false;
          this.isFinished = true;
        }
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

  public void backScene()
  {
    if (this.endAction != null)
      this.endAction();
    else
      Singleton<NGSceneManager>.GetInstance().backScene();
  }

  public void onSkipButton()
  {
    if (this.modeScript_ == StoryExecuter.ScriptMode.Normal)
    {
      if (this._isFinished || this.storyContinuous())
        return;
      if (Singleton<NGGameDataManager>.GetInstance().IsSea)
        Singleton<NGSoundManager>.GetInstance().playSE("SE_1040");
      else
        Singleton<NGSoundManager>.GetInstance().playSE("SE_1002");
      this.isFinished = true;
      this.backScene();
    }
    else
    {
      this.skip_enable = !this.skip_enable;
      if (this.skip_enable)
        this.skip_wait_time = this.skip_wait;
      if (this.environment.nextBlockp() && !Input.GetKey("return"))
        return;
      this.skip_enable = false;
      if (this.skip_enable)
        return;
      this.onNextButton();
    }
  }

  public void onLogButton()
  {
    this.skip_enable = false;
    this.box = this.windowObj.GetComponent<BoxCollider>();
    if (this.backlog_manager.IsEnable())
      return;
    this.backlog_manager.StartBacklog(new System.Action(this.onLogCloseButton));
    this.box.enabled = false;
  }

  public void onLogCloseButton()
  {
    this.box = this.windowObj.GetComponent<BoxCollider>();
    if (!this.backlog_manager.IsEnable())
      return;
    this.backlog_manager.End();
    if (this.environment.current.select != null)
      this.box.enabled = false;
    else
      this.box.enabled = true;
  }

  public void onSelectButton00()
  {
    this.environment.current.setSelectIndex(0);
    this.environment.setNextLabel(this.environment.current.select.data[0].label);
    this.selectBtnObj[1].SetActive(false);
    this.selectBtnObj[2].SetActive(false);
    UISprite component = this.selectBtn[0].GetComponent<UISprite>();
    component.spriteName = this.selectBtn[0].GetComponent<UIButton>().pressedSprite;
    component.GetComponent<Collider>().enabled = false;
    this.select_button_wait = this.select_wait;
    if (!this.onSelect)
      this.callEventSelected(0);
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
    component.spriteName = this.selectBtn[1].GetComponent<UIButton>().pressedSprite;
    component.GetComponent<Collider>().enabled = false;
    this.select_button_wait = this.select_wait;
    if (!this.onSelect)
      this.callEventSelected(1);
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
    component.spriteName = this.selectBtn[2].GetComponent<UIButton>().pressedSprite;
    component.GetComponent<Collider>().enabled = false;
    this.select_button_wait = this.select_wait;
    if (!this.onSelect)
      this.callEventSelected(2);
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

  public void onBackButtonInStory()
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
      this.nameTopBox.Sprite.color = new Color(0.5f, 0.5f, 0.5f);
      this.nameBottomLabel.color = new Color(1f, 1f, 1f);
      this.nameTopLabel.color = new Color(0.5f, 0.5f, 0.5f);
      this.nameBottomBox.Sprite.color = new Color(1f, 1f, 1f);
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
      this.nameTopBox.Sprite.color = new Color(1f, 1f, 1f);
      this.nameTopLabel.color = new Color(1f, 1f, 1f);
      this.nameBottomLabel.color = new Color(0.5f, 0.5f, 0.5f);
      this.nameBottomBox.Sprite.color = new Color(0.5f, 0.5f, 0.5f);
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
    if (this.textBoxBaseBottomObj == null)
      return;
    for (int index = 0; index < this.textBoxBaseBottomObj.Length; ++index)
    {
      if ((UnityEngine.Object) this.textBoxBaseBottomObj[index] != (UnityEngine.Object) null)
        this.textBoxBaseBottomObj[index].SetActive(index == n);
    }
  }

  public void setTopTextArrow(int n)
  {
    if (this.textBoxBaseTopObj == null)
      return;
    for (int index = 0; index < this.textBoxBaseTopObj.Length; ++index)
    {
      if ((UnityEngine.Object) this.textBoxBaseTopObj[index] != (UnityEngine.Object) null)
        this.textBoxBaseTopObj[index].SetActive(index == n);
    }
  }

  private string getNameBoxSprite(int nameType)
  {
    string str;
    switch (nameType)
    {
      case 1:
        str = "pink";
        break;
      case 2:
        str = "blue";
        break;
      case 3:
        str = "green";
        break;
      default:
        str = "default";
        break;
    }
    return str;
  }

  public object setBottomName(string s = null, int nameType = -1)
  {
    if (this.textFlame)
    {
      this.myselfBase.SetActive(true);
      this.nameBottomBox.gameObject.SetActive(false);
    }
    else
    {
      this.nameBottomBox.SetSpriteName<string>(this.getNameBoxSprite(nameType));
      this.nameBottomBox.gameObject.SetActive(true);
      this.myselfBase.SetActive(false);
    }
    if (s == "" || s == "ななし")
    {
      this.nameBottomBox.gameObject.SetActive(false);
      this.myselfBase.SetActive(false);
      s = "";
    }
    this.setNameMsgBright();
    this.nameBottomLabel.SetTextLocalize(s);
    this.cutinName = s;
    return (object) s;
  }

  public object setTopName(string s, int nameType = -1)
  {
    this.setNameMsgBright();
    this.nameTopBox.SetSpriteName<string>(this.getNameBoxSprite(nameType));
    this.nameTopBox.gameObject.SetActive(true);
    if (s == "" || s == "ななし")
    {
      this.nameTopBox.gameObject.SetActive(false);
      s = "";
    }
    this.nameTopLabel.SetTextLocalize(s);
    this.cutinName = s;
    return (object) s;
  }

  private UILabel GetLabelIncludeText(string text, UILabel target, int offset)
  {
    string text1 = (UnityEngine.Object) target == (UnityEngine.Object) this.textBottomLabel ? string.Format("[{0}]{1}", (object) StoryExecuter.ColorDefault.Bottom, (object) text.Substring(0, offset)) : string.Format("[{0}]{1}", (object) StoryExecuter.ColorDefault.Top, (object) text.Substring(0, offset));
    target.SetTextLocalize(text1);
    return target;
  }

  private int getBoxName(string name) => name == "normal" ? 0 : (name == "toge" ? 1 : (name == "moya" ? 2 : 0));

  private bool storyContinuous()
  {
    if (this.continuousDataList == null)
      return false;
    if (this.continuousPopupView)
      return true;
    Story0093Scene.ContinuousData continuousData1 = (Story0093Scene.ContinuousData) null;
    foreach (Story0093Scene.ContinuousData continuousData2 in this.continuousDataList)
    {
      if (continuousData2.scriptId_ == this.scriptId)
      {
        continuousData1 = continuousData2;
        break;
      }
    }
    if (continuousData1 == null || !continuousData1.continuousFlag_)
      return false;
    int nextNum = this.continuousDataList.IndexOf(continuousData1) + 1;
    if (nextNum >= this.continuousDataList.Count)
      return false;
    if (Singleton<NGGameDataManager>.GetInstance().IsSea)
      Singleton<NGSoundManager>.GetInstance().playSE("SE_1044");
    else
      Singleton<NGSoundManager>.GetInstance().playSE("SE_1006");
    PopupCommonNoYes.Show("シナリオ連続再生", "連続再生を行いますか？", (System.Action) (() =>
    {
      this.backlog_manager.BacklogDestroy();
      this.StartCoroutine(this.ContinuousCharaReset(nextNum));
    }), (System.Action) (() =>
    {
      this._isFinished = true;
      this.StartCoroutine(this.ContinuousCancel());
    }), isNonSe: true);
    this.continuousPopupView = true;
    return true;
  }

  private IEnumerator ContinuousCancel()
  {
    yield return (object) null;
    this.backScene();
  }

  private IEnumerator ContinuousCharaReset(int nextNum)
  {
    if ((double) this.fadeControl.toAlpha == 0.0)
    {
      this.setColorAndTime(0.0f, 0.0f, 0.0f, 0.0f, 1f, this.fadeInTime_);
      this.startFade();
      yield return (object) new WaitForSeconds(this.fadeInTime_);
    }
    foreach (KeyValuePair<int, StoryExecuter.CharacterInfo> character in this.characterList)
      UnityEngine.Object.Destroy((UnityEngine.Object) character.Value.obj);
    this.characterList.Clear();
    foreach (KeyValuePair<int, StoryExecuter.ImageInfo> keyValuePair in this.imageInfo)
    {
      UI2DSprite component = keyValuePair.Value.obj.GetComponent<UI2DSprite>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
        component.sprite2D = Resources.Load<UnityEngine.Sprite>("sprites/1x1_black");
      keyValuePair.Value.obj.SetActive(false);
    }
    this.startMoveButtons(0, false, 0.0f);
    this.startMoveFrame(0, false, 0.0f);
    if ((UnityEngine.Object) this.bgObj != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.bgObj);
    this.setSubColorAndTime(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
    this.startSubFillrect();
    this.isWaitAndNext = false;
    Story0093Scene.continuousChangeScene009_3(false, this.continuousDataList[nextNum].scriptId_);
  }

  private void waitColorTime(float t)
  {
  }

  public object setCutinName(float time, int num)
  {
    if ((UnityEngine.Object) this.cutinObj == (UnityEngine.Object) null || (UnityEngine.Object) this.CNM == (UnityEngine.Object) null)
      return (object) -1;
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
      if (this.myselfBoxBase.Length == 2)
      {
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

  private IEnumerator InitBackGround(string s)
  {
    if (!((UnityEngine.Object) this.bgObj == (UnityEngine.Object) null))
    {
      UI2DSprite sprite = this.bgObj.GetComponent<UI2DSprite>();
      this.sbg = this.bgObj.GetComponent<StoryBG>();
      Future<UnityEngine.Sprite> spriteF = Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>("Prefabs/BackGround/" + s);
      IEnumerator e = spriteF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      sprite.sprite2D = spriteF.Result;
      sprite.SetDirty();
      this.sbg.namePrefab = s;
    }
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
    return (object) "";
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
        if (boxName == 2 && this.textTop3Nozzle != null)
        {
          ((IEnumerable<GameObject>) this.textTop3Nozzle).Where<GameObject>((Func<GameObject, bool>) (x => (UnityEngine.Object) x != (UnityEngine.Object) null)).ForEach<GameObject>((System.Action<GameObject>) (x => x.SetActive(false)));
          if (this.charaPos == 1 || this.charaPos == 2)
            this.setOnTextTopNozzle(0);
          else if (this.charaPos == 3)
            this.setOnTextTopNozzle(1);
          else
            this.setOnTextTopNozzle(2);
        }
      }
      else
        this.textTopFlame[index].SetActive(false);
    }
    return (object) s;
  }

  private void setOnTextTopNozzle(int index)
  {
    if (this.textTop3Nozzle.Length <= index || !((UnityEngine.Object) this.textTop3Nozzle[index] != (UnityEngine.Object) null))
      return;
    this.textTop3Nozzle[index].SetActive(true);
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
          if (boxName == 2 && this.textBottom3Nozzle != null)
          {
            ((IEnumerable<GameObject>) this.textBottom3Nozzle).Where<GameObject>((Func<GameObject, bool>) (x => (UnityEngine.Object) x != (UnityEngine.Object) null)).ForEach<GameObject>((System.Action<GameObject>) (x => x.SetActive(false)));
            if (this.charaPos == 1 || this.charaPos == 2)
              this.setOnTextBottomNozzle(0);
            else if (this.charaPos == 3)
              this.setOnTextBottomNozzle(1);
            else
              this.setOnTextBottomNozzle(2);
          }
        }
        else
          this.textBottomFlame[index].SetActive(false);
      }
    }
    return (object) s;
  }

  private void setOnTextBottomNozzle(int index)
  {
    if (this.textBottom3Nozzle.Length <= index || !((UnityEngine.Object) this.textBottom3Nozzle[index] != (UnityEngine.Object) null))
      return;
    this.textBottom3Nozzle[index].SetActive(true);
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
    switch (color)
    {
      case "black":
        color = "000000";
        break;
      case "blue":
        color = "0000FF";
        break;
      case "green":
        color = "00FF00";
        break;
      case "nomal":
      case "normal":
        color = this.rgbTextNormal_;
        break;
      case "pink":
        color = "FFBFCC";
        break;
      case "red":
        color = "FF0000";
        break;
      case "white":
        color = "FFFFFF";
        break;
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

  public void SetTextAlgin(TextBlock.Position pos, string align) => (pos == TextBlock.Position.TOP ? this.textTopLabel : this.textBottomLabel).alignment = align == "center" ? NGUIText.Alignment.Center : (align == "left" ? NGUIText.Alignment.Left : (align == "right" ? NGUIText.Alignment.Right : (align == "just" ? NGUIText.Alignment.Justified : (align == "auto" ? NGUIText.Alignment.Automatic : NGUIText.Alignment.Left))));

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

  public object setEmotion() => (object) "";

  public object deleteEmotion() => (object) "";

  public object setEmotionBright() => (object) "";

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

  public IEnumerator delayStopSe(int ch, float delay = 0.0f)
  {
    yield return (object) new WaitForSeconds(delay);
    this.sm = Singleton<NGSoundManager>.GetInstance();
    this.sm.stopSE(ch);
  }

  public void stopSeAll()
  {
    if (this.plsySEDataList == null)
      return;
    this.plsySEDataList.ForEach((System.Action<PlaySEData>) (x => this.StartCoroutine(this.delayStopSe(x.ch))));
  }

  public object setVoice(string charaID, string name, float delay = 0.0f)
  {
    if (!this.skip_enable)
    {
      this.sm = Singleton<NGSoundManager>.GetInstance();
      int voiceno = this.sm.playVoiceByStringID("VO_" + charaID, name, delay: delay);
      this.addWaitAutoPlay((Func<bool>) (() => this.sm.IsVoicePlaying(voiceno)));
    }
    return (object) name;
  }

  public void stopVoiceAll() => Singleton<NGSoundManager>.GetInstance().StopVoice();

  public void setBgm(string s, float time = 0.7f) => Singleton<NGSoundManager>.GetInstance().PlayBgm(s, fadeInTime: time, fadeOutTime: time);

  public void setBgmFile(string file, string s, float time = 0.7f) => Singleton<NGSoundManager>.GetInstance().PlayBgmFile(file, s, fadeInTime: time, fadeOutTime: time);

  public void setNextBgmBlock(int blockIndex) => Singleton<NGSoundManager>.GetInstance().SetNextBGMBlock(0, blockIndex);

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
    if (sb.data.Count > 0)
      this.addWaitAutoPlay((Func<bool>) (() => true));
    this.InitStartSelect();
    this.quastion.SetTextLocalize(this.environment.current.text.text);
    this.skip_enable = false;
  }

  private void InitStartSelect()
  {
    foreach (GameObject gameObject in this.select)
    {
      UISprite componentInChildren = gameObject.GetComponentInChildren<UISprite>();
      if (!((UnityEngine.Object) componentInChildren == (UnityEngine.Object) null))
      {
        componentInChildren.color = Color.white;
        componentInChildren.GetComponent<Collider>().enabled = true;
      }
    }
  }

  public void PopupStoryEffect(string label) => this.doStartCoroutine(this.ShowStoryEffect(label));

  private IEnumerator ShowStoryEffect(string label)
  {
    Singleton<CommonRoot>.GetInstance().isActiveBlackBGPanel = true;
    Future<GameObject> prefabF = Res.Prefabs.quest052_8.P0_Quest_Title.Load<GameObject>();
    IEnumerator e = prefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject prefab = prefabF.Result.Clone();
    prefab.GetComponent<QuestStartAnim>().StartAnim(label);
    Singleton<PopupManager>.GetInstance().open(prefab, isCloned: true);
  }

  private void resetCoroutine() => this.coroutineCount = 0;

  private IEnumerator execCoroutine(IEnumerator e)
  {
    ++this.coroutineCount;
    while (e.MoveNext())
      yield return e.Current;
    --this.coroutineCount;
  }

  private void doStartCoroutine(IEnumerator e) => this.StartCoroutine(this.execCoroutine(e));

  public bool isRenderDone => this.coroutineCount == 0;

  public void PlayMovie(string fileName, bool enabledSkip)
  {
    if (this.skip_enable)
      return;
    NGSoundManager sm = Singleton<NGSoundManager>.GetInstance();
    string nowBgmName = sm.GetBgmName();
    this.enabled = false;
    this.movieObj.Attach(fileName, enabledSkip, (System.Action) (() =>
    {
      sm.PlayBgm(nowBgmName);
      this.movieObj.ShowMainPanel();
      StatusBarHelper.SetVisibility(false);
      this.enabled = true;
    }));
  }

  public override void onBackButton()
  {
    if (this.backlog_manager.IsEnable())
      return;
    this.showBackKeyToast();
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
    if (!this.characterList.TryGetValue(uniqueId, out characterInfo1) && this.characterList.TryGetValue(beforeId, out characterInfo2) && (this.characterList.TryGetValue(afterId, out characterInfo3) && characterInfo2.parentId == 0) && characterInfo3.parentId == 0)
    {
      characterInfo1 = new StoryExecuter.CharacterInfo();
      this.characterList.Add(uniqueId, characterInfo1);
      characterInfo1.obj = UnityEngine.Object.Instantiate<GameObject>(this.CharacterPrefab);
      characterInfo1.obj.transform.localPosition = Vector3.zero;
      characterInfo1.obj.transform.localScale = Vector3.one;
      characterInfo1.obj.transform.parent = this.windowObj.transform;
      characterInfo1.obj.GetComponent<TweenPosition>().enabled = false;
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

  public StoryExecuter.CharacterInfo setPerson(
    int unique_id,
    int chara_id,
    int? job_id = null)
  {
    StoryExecuter.CharacterInfo characterInfo;
    if (!this.characterList.TryGetValue(unique_id, out characterInfo))
    {
      characterInfo = new StoryExecuter.CharacterInfo();
      this.characterList.Add(unique_id, characterInfo);
      characterInfo.obj = UnityEngine.Object.Instantiate<GameObject>(this.CharacterPrefab);
      characterInfo.obj.transform.localPosition = new Vector3(500f, 0.0f, 0.0f);
      characterInfo.obj.transform.localScale = Vector3.one;
      characterInfo.obj.transform.parent = this.windowObj.transform;
      characterInfo.obj.GetComponent<TweenPosition>().enabled = false;
      this.getUnit(unique_id, chara_id, this.characterList.Count<KeyValuePair<int, StoryExecuter.CharacterInfo>>(), job_id);
    }
    return characterInfo;
  }

  private void getUnit(int unique_id, int chara_id, int layer = 1, int? ext_id = null)
  {
    StoryExecuter.CharacterInfo character = this.characterList[unique_id];
    character.image = this.storyResource.GetCharacterPrefab(unique_id).Clone(character.obj.transform);
    if (chara_id > 999)
      MasterData.UnitUnit[chara_id].SetStoryData(character.image, ext_id: ext_id);
    character.obj.GetComponent<Clash>().windowObj = this.mainPanel;
    character.image.GetComponent<NGxMaskSpriteWithScale>().MainUI2DSprite.sprite2D = this.storyResource.GetLargeTexture(unique_id);
    this.setMaskChange(character);
    UIWidget component1 = character.image.GetComponent<UIWidget>();
    component1.depth = 5;
    Transform[] componentsInChildren = character.image.transform.GetComponentsInChildren<Transform>();
    foreach (Component component2 in ((IEnumerable<Transform>) componentsInChildren).Where<Transform>((Func<Transform, bool>) (v => v.name == "face")))
      component2.GetComponent<UIWidget>().depth = component1.depth + 1;
    foreach (Component component2 in ((IEnumerable<Transform>) componentsInChildren).Where<Transform>((Func<Transform, bool>) (v => v.name == "eye")))
      component2.GetComponent<UIWidget>().depth = component1.depth + 2;
  }

  public void setMaskChange(int id) => this.setMaskChange(this.setPerson(id, id));

  public void setMaskChange(StoryExecuter.CharacterInfo chara)
  {
    if ((UnityEngine.Object) chara.image == (UnityEngine.Object) null)
      return;
    NGxMaskSpriteWithScale component = chara.image.GetComponent<NGxMaskSpriteWithScale>();
    if ((UnityEngine.Object) component == (UnityEngine.Object) null)
      return;
    int index = Mathf.Clamp(chara.pos - 1, 0, this.mSprite.Length - 1);
    component.maskTexture = this.mSprite[index];
  }

  public void setCharaPosition(int id, int pos)
  {
    StoryExecuter.CharacterInfo chara = this.setPerson(id, id);
    chara.pos = pos;
    chara.obj.transform.localPosition = this.positions[pos - 1];
    this.setMaskChange(chara);
  }

  public void getCharaPosition(int id, int? jobid = null)
  {
    StoryExecuter.CharacterInfo chara = this.setPerson(id, id, jobid);
    this.charaPos = chara.pos;
    this.setMaskChange(chara);
  }

  public void setFace(int id, string s)
  {
    StoryExecuter.CharacterInfo characterInfo = this.setPerson(id, id);
    characterInfo.faceName = s;
    NGxFaceSprite component = characterInfo.image.GetComponent<NGxFaceSprite>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    this.doStartCoroutine(component.ChangeFace(s));
  }

  public void setEye(int id, string s)
  {
    StoryExecuter.CharacterInfo characterInfo = this.setPerson(id, id);
    characterInfo.eyeName = s;
    NGxEyeSprite component = characterInfo.image.GetComponent<NGxEyeSprite>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    component.enabled = true;
    component.EyeUI2DSprite.gameObject.SetActive(true);
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
    TweenPosition.Begin(chara.obj, this.skip_enable ? 0.1f : time, this.positions[pos - 1]);
    this.setMaskChange(chara);
  }

  public void setCharaReversal(int id, bool b) => this.setPerson(id, id).obj.transform.localRotation = new Quaternion(0.0f, b ? 180f : 0.0f, 0.0f, 0.0f);

  public void setCharaBrightness(int id, float c, float t)
  {
    StoryExecuter.CharacterInfo chara = this.setPerson(id, id);
    GameObject image = chara.image;
    TweenColor component1 = image.GetComponent<TweenColor>();
    GameObject gameObject = image.transform.Find("face").gameObject;
    TweenColor component2 = gameObject.GetComponent<TweenColor>();
    if ((UnityEngine.Object) component1 == (UnityEngine.Object) null && (UnityEngine.Object) component2 == (UnityEngine.Object) null)
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
    TweenAlpha.Begin(chara.obj, this.skip_enable ? 0.1f : time, alpha);
    this.setMaskChange(chara);
  }

  public void setCharaLayer(int id, int depth)
  {
    StoryExecuter.CharacterInfo chara = this.setPerson(id, id);
    UIWidget w = chara.image.GetComponent<UIWidget>();
    w.depth = (depth + 1) * 5;
    Transform[] componentsInChildren = chara.image.transform.GetComponentsInChildren<Transform>();
    ((IEnumerable<Transform>) componentsInChildren).Where<Transform>((Func<Transform, bool>) (v => v.name == "face")).ForEach<Transform>((System.Action<Transform>) (v => v.GetComponent<UIWidget>().depth = w.depth + 1));
    ((IEnumerable<Transform>) componentsInChildren).Where<Transform>((Func<Transform, bool>) (v => v.name == "eye")).ForEach<Transform>((System.Action<Transform>) (v => v.GetComponent<UIWidget>().depth = w.depth + 2));
    this.setMaskChange(chara);
  }

  public void deleteUnit(int id)
  {
    StoryExecuter.CharacterInfo info;
    if (!this.characterList.TryGetValue(id, out info))
      return;
    if (info.child != null && info.child.Length != 0)
    {
      foreach (int key in this.getChildIdsInCharacterInfo(info))
        this.characterList.Remove(key);
    }
    StoryExecuter.CharacterInfo characterInfo;
    if (info.parentId != 0 && this.characterList.TryGetValue(info.parentId, out characterInfo))
      characterInfo.child = ((IEnumerable<int>) characterInfo.child).Where<int>((Func<int, bool>) (i => i != id)).ToArray<int>();
    UnityEngine.Object.Destroy((UnityEngine.Object) info.obj);
    this.characterList.Remove(id);
  }

  private List<int> getChildIdsInCharacterInfo(StoryExecuter.CharacterInfo info)
  {
    List<int> intList = new List<int>();
    foreach (int key in info.child)
    {
      StoryExecuter.CharacterInfo character = this.characterList[key];
      if (character.child != null && character.child.Length != 0)
        intList.AddRange((IEnumerable<int>) this.getChildIdsInCharacterInfo(character));
      intList.Add(key);
    }
    return intList;
  }

  public void SetMaskEnable(int id, bool enable)
  {
    StoryExecuter.CharacterInfo characterInfo = this.setPerson(id, id);
    NGxMaskSpriteWithScale maskSpriteWithScale = (UnityEngine.Object) characterInfo.image != (UnityEngine.Object) null ? characterInfo.image.GetComponent<NGxMaskSpriteWithScale>() : (NGxMaskSpriteWithScale) null;
    if (!((UnityEngine.Object) maskSpriteWithScale != (UnityEngine.Object) null))
      return;
    maskSpriteWithScale.SetMaskEnable(enable);
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
      characterInfo1.obj = UnityEngine.Object.Instantiate<GameObject>(this.CharacterPrefab);
      characterInfo1.obj.transform.parent = characterInfo2.obj.transform;
      characterInfo1.obj.transform.localPosition = (Vector3) new Vector2((float) offsetX, (float) offsetY);
      characterInfo1.obj.transform.localScale = Vector3.one;
      characterInfo1.obj.transform.localRotation = Quaternion.identity;
      characterInfo1.obj.GetComponent<TweenPosition>().enabled = false;
      characterInfo1.parentId = parentId;
      StoryExecuter.CharacterInfo characterInfo3 = characterInfo2;
      int[] numArray;
      if (characterInfo2.child == null)
        numArray = new int[1]{ uniqueId };
      else
        numArray = ((IEnumerable<int>) characterInfo2.child).Concat<int>((IEnumerable<int>) new int[1]
        {
          uniqueId
        }).ToArray<int>();
      characterInfo3.child = numArray;
      this.doStartCoroutine(characterInfo1.obj.GetComponent<StoryEffectControl>().coInitializeEmotion(dataId, noColor));
    }
    return characterInfo1;
  }

  public StoryExecuter.CharacterInfo setEnvEffect(
    int uniqueId,
    int dataId,
    int noColor)
  {
    StoryExecuter.CharacterInfo characterInfo;
    if (!this.characterList.TryGetValue(uniqueId, out characterInfo))
    {
      characterInfo = new StoryExecuter.CharacterInfo();
      this.characterList.Add(uniqueId, characterInfo);
      characterInfo.obj = UnityEngine.Object.Instantiate<GameObject>(this.CharacterPrefab);
      characterInfo.obj.transform.parent = this.windowObj.transform;
      characterInfo.obj.transform.localPosition = Vector3.zero;
      characterInfo.obj.transform.localScale = Vector3.one;
      characterInfo.obj.transform.localRotation = Quaternion.identity;
      characterInfo.obj.GetComponent<TweenPosition>().enabled = false;
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
      characterInfo.obj = UnityEngine.Object.Instantiate<GameObject>(this.CharacterPrefab);
      characterInfo.obj.transform.parent = this.windowObj.transform;
      characterInfo.obj.transform.localPosition = (Vector3) new Vector2((float) positionX, (float) positionY);
      characterInfo.obj.transform.localScale = Vector3.one;
      characterInfo.obj.transform.localRotation = Quaternion.identity;
      characterInfo.obj.GetComponent<TweenPosition>().enabled = false;
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

  public GameObject topButtons => this.topButtons_;

  public void setSubDepth(int index)
  {
    if (this.subFillrectDepths_ == null || index < 0 || (index >= this.subFillrectDepths_.Length || !((UnityEngine.Object) this.fadeSubControl_ != (UnityEngine.Object) null)))
      return;
    this.fadeSubControl_.setDepth(this.subFillrectDepths_[index]);
  }

  public void setSubColorAndTime(float r, float g, float b, float a, float to, float t)
  {
    if ((UnityEngine.Object) this.fadeSubControl_ == (UnityEngine.Object) null)
      return;
    this.fadeSubControl_.r = r;
    this.fadeSubControl_.g = g;
    this.fadeSubControl_.b = b;
    this.fadeSubControl_.fromAlpha = a;
    this.fadeSubControl_.toAlpha = to;
    this.fadeSubControl_.time = t;
  }

  public void startSubFillrect()
  {
    this.fillrectSub_ = true;
    if (!((UnityEngine.Object) this.fadeSubControl_ != (UnityEngine.Object) null))
      return;
    this.fadeSubControl_.StartFillrect();
  }

  private void fadeSubNextExit()
  {
    if (!this.fillrectSub_)
      return;
    this.fillrectSub_ = false;
    if (!((UnityEngine.Object) this.fadeSubControl_ != (UnityEngine.Object) null))
      return;
    this.fadeSubControl_.time = 0.0f;
    this.fadeSubControl_.StartFillrect();
  }

  public void startMoveFrame(int index, bool toOut, float duration)
  {
    if ((UnityEngine.Object) this.frameTop_ == (UnityEngine.Object) null || (UnityEngine.Object) this.frameBottom_ == (UnityEngine.Object) null)
      return;
    if (toOut)
    {
      if (index < 0 || this.frameOutPositions_ == null || this.frameOutPositions_.Length <= index)
        return;
      this.moveEndDeleteControl(this.frameTop_, duration, (Vector3) this.frameOutPositions_[index].top_);
      this.moveEndDeleteControl(this.frameBottom_, duration, (Vector3) this.frameOutPositions_[index].bottom_);
    }
    else
    {
      this.moveEndDeleteControl(this.frameTop_, duration, Vector3.zero);
      this.moveEndDeleteControl(this.frameBottom_, duration, Vector3.zero);
    }
  }

  public void startMoveButtons(int index, bool toOut, float duration)
  {
    if ((UnityEngine.Object) this.topButtons_ == (UnityEngine.Object) null)
      return;
    if (toOut)
    {
      if (index < 0 || this.buttonOutPositions_ == null || this.buttonOutPositions_.Length <= index)
        return;
      this.moveEndDeleteControl(this.topButtons_, duration, (Vector3) this.buttonOutPositions_[index]);
    }
    else
      this.moveEndDeleteControl(this.topButtons_, duration, Vector3.zero);
  }

  private void moveEndDeleteControl(GameObject go, float duration, Vector3 to)
  {
    TweenPosition cntl = TweenPosition.Begin(go, duration, to);
    EventDelegate.Add(cntl.onFinished, (EventDelegate.Callback) (() => UnityEngine.Object.Destroy((UnityEngine.Object) cntl)), true);
  }

  public void setImageName(int id, string name)
  {
    if (!this.imageInfo.ContainsKey(id))
      this.imageInfo.Add(id, new StoryExecuter.ImageInfo());
    if (name == "")
    {
      this.imageObj[id].SetActive(false);
    }
    else
    {
      this.imageObj[id].SetActive(true);
      this.imageInfo[id].obj = this.imageObj[id];
      this.imageInfo[id].name = name;
      Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>("AssetBundle/Resources/EventImages/" + name).RunOn<UnityEngine.Sprite>((MonoBehaviour) this, (System.Action<UnityEngine.Sprite>) (s =>
      {
        UI2DSprite component = this.imageInfo[id].obj.GetComponent<UI2DSprite>();
        component.sprite2D = s;
        component.width = (int) s.textureRect.width;
        component.height = (int) s.textureRect.height;
        component.transform.localPosition = new Vector3(2500f, 0.0f, 0.0f);
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
    TweenAlpha.Begin(this.imageInfo[id].obj, this.skip_enable ? 0.1f : time, alpha);
  }

  public void setImageScale(int id, float scale, float time)
  {
    if (!this.imageInfo.ContainsKey(id))
      this.imageInfo.Add(id, new StoryExecuter.ImageInfo());
    this.imageInfo[id].scale = scale;
    TweenScale.Begin(this.imageInfo[id].obj, this.skip_enable ? 0.1f : time, new Vector3(scale, scale, 1f));
  }

  public void setImageMoveIn(int id, float time, float x, float y)
  {
    if (!this.imageInfo.ContainsKey(id))
      this.imageInfo.Add(id, new StoryExecuter.ImageInfo());
    GameObject go = this.imageInfo[id].obj;
    Vector3 localPosition = go.transform.localPosition;
    Vector3 pos = new Vector3(localPosition.x, localPosition.y, localPosition.z);
    go.transform.localPosition = new Vector3(x, y, localPosition.z);
    TweenPosition.Begin(go, this.skip_enable ? 0.1f : time, pos);
  }

  public void setImageMoveOut(int id, float time, float x, float y)
  {
    if (!this.imageInfo.ContainsKey(id))
      this.imageInfo.Add(id, new StoryExecuter.ImageInfo());
    GameObject go = this.imageInfo[id].obj;
    Vector3 localPosition = go.transform.localPosition;
    Vector3 pos = new Vector3(x, y, localPosition.z);
    TweenPosition.Begin(go, this.skip_enable ? 0.1f : time, pos);
  }

  public enum ScriptMode
  {
    Normal,
    Date,
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

  [Serializable]
  private class FramePositions
  {
    public Vector2 top_ = Vector2.zero;
    public Vector2 bottom_ = Vector2.zero;
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
