﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      此代码由编码的 UI 测试生成器生成。
//      版本: 11.0.0.0
//
//      如果重新生成代码，则更改此文件可能会导致错误的行为，
//      并将丢失这些更改。
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace CodedUITestProject1
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("编码的 UI 测试生成器", "11.0.50727.1")]
    public partial class UIMap
    {
        
        /// <summary>
        /// RecordedMethod1 - 使用“RecordedMethod1Params”将参数传递到此方法中。
        /// </summary>
        public void RecordedMethod1()
        {
            #region Variable Declarations
            WinTabPage uIMicrosoftVisualStudiTabPage = this.UIMicrosoftVisualStudiWindow.UITabRowTabList.UIMicrosoftVisualStudiTabPage;
            HtmlSpan uIItemPane = this.UIMicrosoftVisualStudiWindow.UIMicrosoftVisualStudiDocument.UIFCustom.UIItemPane;
            HtmlInputButton uI百度一下Button = this.UIMicrosoftVisualStudiWindow.UIMicrosoftVisualStudiDocument.UI百度一下Button;
            HtmlEdit uIWDEdit = this.UIMicrosoftVisualStudiWindow.UIMicrosoftVisualStudiDocument.UIWDEdit;
            #endregion

            // 单击 “Microsoft.VisualStudio.TestTools.UITest.Playback 下...” 选项卡
            Mouse.Click(uIMicrosoftVisualStudiTabPage, new Point(28, 16));

            // 设置标志，以便在非必需操作失败时允许继续播放。(例如，鼠标悬停操作失败时。)
            Playback.PlaybackSettings.ContinueOnError = true;

            // 将鼠标悬停在(502, 6)处的  窗格 上
            Mouse.Hover(uIItemPane, new Point(502, 6));

            // 重置标志，以确保在出错时播放停止。
            Playback.PlaybackSettings.ContinueOnError = false;

            // 单击 “百度一下” 按钮
            Mouse.Click(uI百度一下Button, new Point(45, 16));

            // 在 “wd” 文本框 中键入“xxx”
            uIWDEdit.Text = this.RecordedMethod1Params.UIWDEditText;

            // 单击 “百度一下” 按钮
            Mouse.Click(uI百度一下Button, new Point(62, 12));
        }
        
        #region Properties
        public virtual RecordedMethod1Params RecordedMethod1Params
        {
            get
            {
                if ((this.mRecordedMethod1Params == null))
                {
                    this.mRecordedMethod1Params = new RecordedMethod1Params();
                }
                return this.mRecordedMethod1Params;
            }
        }
        
        public UIMicrosoftVisualStudiWindow UIMicrosoftVisualStudiWindow
        {
            get
            {
                if ((this.mUIMicrosoftVisualStudiWindow == null))
                {
                    this.mUIMicrosoftVisualStudiWindow = new UIMicrosoftVisualStudiWindow();
                }
                return this.mUIMicrosoftVisualStudiWindow;
            }
        }
        #endregion
        
        #region Fields
        private RecordedMethod1Params mRecordedMethod1Params;
        
        private UIMicrosoftVisualStudiWindow mUIMicrosoftVisualStudiWindow;
        #endregion
    }
    
    /// <summary>
    /// 要传递到“RecordedMethod1”中的参数
    /// </summary>
    [GeneratedCode("编码的 UI 测试生成器", "11.0.50727.1")]
    public class RecordedMethod1Params
    {
        
        #region Fields
        /// <summary>
        /// 在 “wd” 文本框 中键入“xxx”
        /// </summary>
        public string UIWDEditText = "xxx";
        #endregion
    }
    
    [GeneratedCode("编码的 UI 测试生成器", "11.0.50727.1")]
    public class UIMicrosoftVisualStudiWindow : BrowserWindow
    {
        
        public UIMicrosoftVisualStudiWindow()
        {
            #region 搜索条件
            this.SearchProperties[UITestControl.PropertyNames.Name] = "Microsoft.VisualStudio.TestTools.UITest.Playback.dll - 找DLL下载站,dll下载,DLL大全,系统开机提示" +
                ",DLL文件缺少,free  - Internet Explorer provided by";
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            this.WindowTitles.Add("Microsoft.VisualStudio.TestTools.UITest.Playback.dll - 找DLL下载站,dll下载,DLL大全,系统开机提示" +
                    ",DLL文件缺少,free  - Internet Explorer provided by");
            this.WindowTitles.Add("Microsoft.VisualStudio.TestTools.UITest.Playback 下载_百度搜索");
            #endregion
        }
        
        public void LaunchUrl(System.Uri url)
        {
            this.CopyFrom(BrowserWindow.Launch(url));
        }
        
        #region Properties
        public UITabRowTabList UITabRowTabList
        {
            get
            {
                if ((this.mUITabRowTabList == null))
                {
                    this.mUITabRowTabList = new UITabRowTabList(this);
                }
                return this.mUITabRowTabList;
            }
        }
        
        public UIMicrosoftVisualStudiDocument UIMicrosoftVisualStudiDocument
        {
            get
            {
                if ((this.mUIMicrosoftVisualStudiDocument == null))
                {
                    this.mUIMicrosoftVisualStudiDocument = new UIMicrosoftVisualStudiDocument(this);
                }
                return this.mUIMicrosoftVisualStudiDocument;
            }
        }
        #endregion
        
        #region Fields
        private UITabRowTabList mUITabRowTabList;
        
        private UIMicrosoftVisualStudiDocument mUIMicrosoftVisualStudiDocument;
        #endregion
    }
    
    [GeneratedCode("编码的 UI 测试生成器", "11.0.50727.1")]
    public class UITabRowTabList : WinTabList
    {
        
        public UITabRowTabList(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region 搜索条件
            this.SearchProperties[WinTabList.PropertyNames.Name] = "Tab Row";
            this.WindowTitles.Add("Microsoft.VisualStudio.TestTools.UITest.Playback.dll - 找DLL下载站,dll下载,DLL大全,系统开机提示" +
                    ",DLL文件缺少,free  - Internet Explorer provided by");
            #endregion
        }
        
        #region Properties
        public WinTabPage UIMicrosoftVisualStudiTabPage
        {
            get
            {
                if ((this.mUIMicrosoftVisualStudiTabPage == null))
                {
                    this.mUIMicrosoftVisualStudiTabPage = new WinTabPage(this);
                    #region 搜索条件
                    this.mUIMicrosoftVisualStudiTabPage.SearchProperties[WinTabPage.PropertyNames.Name] = "Microsoft.VisualStudio.TestTools.UITest.Playback 下载_百度搜索 Tab Group 13";
                    this.mUIMicrosoftVisualStudiTabPage.WindowTitles.Add("Microsoft.VisualStudio.TestTools.UITest.Playback.dll - 找DLL下载站,dll下载,DLL大全,系统开机提示" +
                            ",DLL文件缺少,free  - Internet Explorer provided by");
                    #endregion
                }
                return this.mUIMicrosoftVisualStudiTabPage;
            }
        }
        #endregion
        
        #region Fields
        private WinTabPage mUIMicrosoftVisualStudiTabPage;
        #endregion
    }
    
    [GeneratedCode("编码的 UI 测试生成器", "11.0.50727.1")]
    public class UIMicrosoftVisualStudiDocument : HtmlDocument
    {
        
        public UIMicrosoftVisualStudiDocument(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region 搜索条件
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = null;
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Microsoft.VisualStudio.TestTools.UITest.Playback 下载_百度搜索";
            this.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = "/s";
            this.FilterProperties[HtmlDocument.PropertyNames.PageUrl] = @"http://www.baidu.com/s?ie=utf-8&f=3&rsv_bp=1&rsv_idx=1&tn=baidu&wd=Microsoft.VisualStudio.TestTools.UITest.Playback%20%E4%B8%8B%E8%BD%BD&oq=Microsoft.VisualStudio.TestTools.UITest.Playback&rsv_pq=bb3aa8f40002282e&rsv_t=c2283LvqZGeV25NCr5F%2FMwHUr8yWm2wDOE2FQeuYpYbbyW1qcLFwzsFOlec&rqlang=cn&rsv_enter=0&inputT=3126&rsv_sug3=36&rsv_sug2=0&prefixsug=Microsoft.VisualStudio.TestTools.UITest.Playback%20%E4%B8%8B%E8%BD%BD&rsp=0&rsv_sug4=5028&rsv_sug=1";
            this.WindowTitles.Add("Microsoft.VisualStudio.TestTools.UITest.Playback 下载_百度搜索");
            #endregion
        }
        
        #region Properties
        public UIFCustom UIFCustom
        {
            get
            {
                if ((this.mUIFCustom == null))
                {
                    this.mUIFCustom = new UIFCustom(this);
                }
                return this.mUIFCustom;
            }
        }
        
        public HtmlInputButton UI百度一下Button
        {
            get
            {
                if ((this.mUI百度一下Button == null))
                {
                    this.mUI百度一下Button = new HtmlInputButton(this);
                    #region 搜索条件
                    this.mUI百度一下Button.SearchProperties[HtmlButton.PropertyNames.Id] = "su";
                    this.mUI百度一下Button.SearchProperties[HtmlButton.PropertyNames.Name] = null;
                    this.mUI百度一下Button.SearchProperties[HtmlButton.PropertyNames.DisplayText] = "百度一下";
                    this.mUI百度一下Button.FilterProperties[HtmlButton.PropertyNames.Type] = "submit";
                    this.mUI百度一下Button.FilterProperties[HtmlButton.PropertyNames.Title] = null;
                    this.mUI百度一下Button.FilterProperties[HtmlButton.PropertyNames.Class] = "bg s_btn";
                    this.mUI百度一下Button.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "class=\"bg s_btn\" id=\"su\" type=\"submit\" v";
                    this.mUI百度一下Button.FilterProperties[HtmlButton.PropertyNames.TagInstance] = "10";
                    this.mUI百度一下Button.WindowTitles.Add("Microsoft.VisualStudio.TestTools.UITest.Playback 下载_百度搜索");
                    #endregion
                }
                return this.mUI百度一下Button;
            }
        }
        
        public HtmlEdit UIWDEdit
        {
            get
            {
                if ((this.mUIWDEdit == null))
                {
                    this.mUIWDEdit = new HtmlEdit(this);
                    #region 搜索条件
                    this.mUIWDEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "kw";
                    this.mUIWDEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "wd";
                    this.mUIWDEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = null;
                    this.mUIWDEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUIWDEdit.FilterProperties[HtmlEdit.PropertyNames.Title] = null;
                    this.mUIWDEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = "s_ipt";
                    this.mUIWDEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "name=\"wd\" class=\"s_ipt\" id=\"kw\" maxlengt";
                    this.mUIWDEdit.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "9";
                    this.mUIWDEdit.WindowTitles.Add("Microsoft.VisualStudio.TestTools.UITest.Playback 下载_百度搜索");
                    #endregion
                }
                return this.mUIWDEdit;
            }
        }
        #endregion
        
        #region Fields
        private UIFCustom mUIFCustom;
        
        private HtmlInputButton mUI百度一下Button;
        
        private HtmlEdit mUIWDEdit;
        #endregion
    }
    
    [GeneratedCode("编码的 UI 测试生成器", "11.0.50727.1")]
    public class UIFCustom : HtmlCustom
    {
        
        public UIFCustom(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region 搜索条件
            this.SearchProperties["Id"] = "form";
            this.SearchProperties[UITestControl.PropertyNames.Name] = "f";
            this.SearchProperties["TagName"] = "FORM";
            this.FilterProperties["Class"] = "fm";
            this.FilterProperties["ControlDefinition"] = "name=\"f\" class=\"fm\" id=\"form\" action=\"/s";
            this.FilterProperties["TagInstance"] = "1";
            this.WindowTitles.Add("Microsoft.VisualStudio.TestTools.UITest.Playback 下载_百度搜索");
            #endregion
        }
        
        #region Properties
        public HtmlSpan UIItemPane
        {
            get
            {
                if ((this.mUIItemPane == null))
                {
                    this.mUIItemPane = new HtmlSpan(this);
                    #region 搜索条件
                    this.mUIItemPane.SearchProperties[HtmlDiv.PropertyNames.Id] = null;
                    this.mUIItemPane.SearchProperties[HtmlDiv.PropertyNames.Name] = null;
                    this.mUIItemPane.FilterProperties[HtmlDiv.PropertyNames.InnerText] = null;
                    this.mUIItemPane.FilterProperties[HtmlDiv.PropertyNames.Title] = null;
                    this.mUIItemPane.FilterProperties[HtmlDiv.PropertyNames.Class] = "bg s_ipt_wr quickdelete-wrap";
                    this.mUIItemPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"bg s_ipt_wr quickdelete-wrap\"";
                    this.mUIItemPane.FilterProperties[HtmlDiv.PropertyNames.TagInstance] = "2";
                    this.mUIItemPane.WindowTitles.Add("Microsoft.VisualStudio.TestTools.UITest.Playback 下载_百度搜索");
                    #endregion
                }
                return this.mUIItemPane;
            }
        }
        #endregion
        
        #region Fields
        private HtmlSpan mUIItemPane;
        #endregion
    }
}
