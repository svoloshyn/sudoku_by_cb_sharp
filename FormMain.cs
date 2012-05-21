using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SudokuCB
{
  public class FormMain : Form
  {
    #region Declarations
    private int L = 600;
    private int [,,] mm = new int[9, 9, 2];
    private bool [,] mmCorr = new bool[9,9];

    private bool isEditorMode = false;
    private bool isHardcoreMode = false;
    private bool isTip = false;

    private Pen penThin = new Pen(Color.Black, 1f);
    private Pen penThick = new Pen(Color.Black, 3f);

    private Font font = new Font("Arial", 42f);
    private Font fontTip = new Font("Arial", 14f);

    private SolidBrush solidBrush = new SolidBrush(Color.Black);
    private SolidBrush solidBrushW = new SolidBrush(Color.White);
    private StringFormat sf = new StringFormat();

    #region Colors
    private Color TipColor;
    private Color WrongColor;
    private Color CorrectColor;
    private Color GridColor;
    private Color MapColor;
    #endregion

    #region MenuItems
    private MainMenu mainMenu;
    private MenuItem menuGame;
    private MenuItem menuGameNew;
    private MenuItem menuGameNewEasy;
    private MenuItem menuGameNewNormal;
    private MenuItem menuGameNewHard;
    private MenuItem menuGameNewExteme;
    private MenuItem menuGameReset;
    private MenuItem menuGameOpen;
    private MenuItem menuGameSave;
    private MenuItem menuGameExport;
    private MenuItem menuGameExit;
    private MenuItem menuOptions;
    private MenuItem menuOptionsFont;
    private MenuItem menuOtionsEditorMode;
    private MenuItem menuOptionsHardcore;
    private MenuItem menuHelp;
    private MenuItem menuHelpAbout;
    private MenuItem menuHelpTip;
    #endregion

    #region Dialogs
    private OpenFileDialog openFileDialog;
    private SaveFileDialog saveFileDialog;
    private FontDialog fontDialog;
    private SaveFileDialog saveFileDialogExport;
    #endregion    

    #endregion

    #region Common Stuff
    private System.ComponentModel.Container components = null;

    protected override void Dispose( bool disposing )
    {
      if( disposing )
      {
        if (components != null) 
        {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }

    [STAThread]
    static void Main() 
    {
      Application.Run(new FormMain());
    }
    #endregion

    #region Windows Form Designer generated code
    private void InitializeComponent()
    {
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormMain));
      this.mainMenu = new System.Windows.Forms.MainMenu();
      this.menuGame = new System.Windows.Forms.MenuItem();
      this.menuGameNew = new System.Windows.Forms.MenuItem();
      this.menuGameNewEasy = new System.Windows.Forms.MenuItem();
      this.menuGameNewNormal = new System.Windows.Forms.MenuItem();
      this.menuGameNewHard = new System.Windows.Forms.MenuItem();
      this.menuGameNewExteme = new System.Windows.Forms.MenuItem();
      this.menuGameReset = new System.Windows.Forms.MenuItem();
      this.menuGameOpen = new System.Windows.Forms.MenuItem();
      this.menuGameSave = new System.Windows.Forms.MenuItem();
      this.menuGameExport = new System.Windows.Forms.MenuItem();
      this.menuGameExit = new System.Windows.Forms.MenuItem();
      this.menuOptions = new System.Windows.Forms.MenuItem();
      this.menuOptionsFont = new System.Windows.Forms.MenuItem();
      this.menuOtionsEditorMode = new System.Windows.Forms.MenuItem();
      this.menuOptionsHardcore = new System.Windows.Forms.MenuItem();
      this.menuHelp = new System.Windows.Forms.MenuItem();
      this.menuHelpAbout = new System.Windows.Forms.MenuItem();
      this.menuHelpTip = new System.Windows.Forms.MenuItem();
      this.fontDialog = new System.Windows.Forms.FontDialog();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.saveFileDialogExport = new System.Windows.Forms.SaveFileDialog();
      // 
      // mainMenu
      // 
      this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                             this.menuGame,
                                                                             this.menuOptions,
                                                                             this.menuHelp});
      // 
      // menuGame
      // 
      this.menuGame.Index = 0;
      this.menuGame.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                             this.menuGameNew,
                                                                             this.menuGameReset,
                                                                             this.menuGameOpen,
                                                                             this.menuGameSave,
                                                                             this.menuGameExport,
                                                                             this.menuGameExit});
      this.menuGame.Text = "Game";
      // 
      // menuGameNew
      // 
      this.menuGameNew.Index = 0;
      this.menuGameNew.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                this.menuGameNewEasy,
                                                                                this.menuGameNewNormal,
                                                                                this.menuGameNewHard,
                                                                                this.menuGameNewExteme});
      this.menuGameNew.Text = "New game";
      // 
      // menuGameNewEasy
      // 
      this.menuGameNewEasy.Index = 0;
      this.menuGameNewEasy.Text = "Easy";
      this.menuGameNewEasy.Click += new System.EventHandler(this.menuGameNewEasy_Click);
      // 
      // menuGameNewNormal
      // 
      this.menuGameNewNormal.Index = 1;
      this.menuGameNewNormal.Text = "Normal";
      this.menuGameNewNormal.Click += new System.EventHandler(this.menuGameNewNormal_Click);
      // 
      // menuGameNewHard
      // 
      this.menuGameNewHard.Index = 2;
      this.menuGameNewHard.Text = "Hard";
      this.menuGameNewHard.Click += new System.EventHandler(this.menuGameNewHard_Click);
      // 
      // menuGameNewExteme
      // 
      this.menuGameNewExteme.Index = 3;
      this.menuGameNewExteme.Text = "Extreme";
      this.menuGameNewExteme.Click += new System.EventHandler(this.menuGameNewExteme_Click);
      // 
      // menuGameReset
      // 
      this.menuGameReset.Index = 1;
      this.menuGameReset.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
      this.menuGameReset.Text = "Reset";
      this.menuGameReset.Click += new System.EventHandler(this.menuGameReset_Click);
      // 
      // menuGameOpen
      // 
      this.menuGameOpen.Index = 2;
      this.menuGameOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
      this.menuGameOpen.Text = "Open...";
      this.menuGameOpen.Click += new System.EventHandler(this.menuGameOpen_Click);
      // 
      // menuGameSave
      // 
      this.menuGameSave.Index = 3;
      this.menuGameSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
      this.menuGameSave.Text = "Save...";
      this.menuGameSave.Click += new System.EventHandler(this.menuGameSave_Click);
      // 
      // menuGameExport
      // 
      this.menuGameExport.Index = 4;
      this.menuGameExport.Text = "Export...";
      this.menuGameExport.Click += new System.EventHandler(this.menuGameExport_Click);
      // 
      // menuGameExit
      // 
      this.menuGameExit.Index = 5;
      this.menuGameExit.Shortcut = System.Windows.Forms.Shortcut.F10;
      this.menuGameExit.Text = "Exit";
      this.menuGameExit.Click += new System.EventHandler(this.menuGameExit_Click);
      // 
      // menuOptions
      // 
      this.menuOptions.Index = 1;
      this.menuOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                this.menuOptionsFont,
                                                                                this.menuOtionsEditorMode,
                                                                                this.menuOptionsHardcore});
      this.menuOptions.Text = "Options";
      // 
      // menuOptionsFont
      // 
      this.menuOptionsFont.Index = 0;
      this.menuOptionsFont.Text = "Font";
      this.menuOptionsFont.Click += new System.EventHandler(this.menuOptionsFont_Click);
      // 
      // menuOtionsEditorMode
      // 
      this.menuOtionsEditorMode.Index = 1;
      this.menuOtionsEditorMode.Text = "Editor mode";
      this.menuOtionsEditorMode.Click += new System.EventHandler(this.menuOtionsEditorMode_Click);
      // 
      // menuOptionsHardcore
      // 
      this.menuOptionsHardcore.Index = 2;
      this.menuOptionsHardcore.Text = "Hardcore mode";
      this.menuOptionsHardcore.Click += new System.EventHandler(this.menuOptionsHardcore_Click);
      // 
      // menuHelp
      // 
      this.menuHelp.Index = 2;
      this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                             this.menuHelpAbout,
                                                                             this.menuHelpTip});
      this.menuHelp.Text = "Help";
      // 
      // menuHelpAbout
      // 
      this.menuHelpAbout.Index = 0;
      this.menuHelpAbout.Shortcut = System.Windows.Forms.Shortcut.F1;
      this.menuHelpAbout.Text = "About";
      this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
      // 
      // menuHelpTip
      // 
      this.menuHelpTip.Index = 1;
      this.menuHelpTip.Text = "Tip";
      this.menuHelpTip.Click += new System.EventHandler(this.menuHelpTip_Click);
      // 
      // fontDialog
      // 
      this.fontDialog.ShowEffects = false;
      // 
      // openFileDialog
      // 
      this.openFileDialog.Filter = "gm files|*.gm";
      this.openFileDialog.Title = "Open";
      // 
      // saveFileDialog
      // 
      this.saveFileDialog.DefaultExt = "gm";
      this.saveFileDialog.Filter = "gm files|*.gm";
      this.saveFileDialog.Title = "Save";
      // 
      // saveFileDialogExport
      // 
      this.saveFileDialogExport.Filter = "htm files | *.htm";
      this.saveFileDialogExport.Title = "Export";
      // 
      // FormMain
      // 
      this.AutoScale = false;
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(601, 601);
      this.Enabled = false;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Menu = this.mainMenu;
      this.Name = "FormMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "  Sudoku by CB 2005-December edition";
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);

    }
    #endregion

    public FormMain()
    {
      InitializeComponent();

      sf.Alignment = StringAlignment.Center;
      sf.LineAlignment = StringAlignment.Center;

      setColors();
      gameNew("normal");
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
    }

    private void setColors()
    {
      TipColor = Color.Green;
      WrongColor = Color.Red;
      CorrectColor = Color.DarkGray;
      GridColor = Color.Black;
      MapColor = Color.Black;

      penThin.Color = GridColor;
      penThick.Color = GridColor;
    }

    private void FormMain_MouseDown(object sender, MouseEventArgs e)
    {
      int i = 9*e.X/L;
      int j = 9*e.Y/L;
      int k = isEditorMode ? 0 : 1;

      if((!this.isEditorMode && mm[i,j,0]==0) || isEditorMode)
      {
        if(e.Button == MouseButtons.Right)
          mm[i,j,k] = (mm[i,j,k]+1)%10;
        else if(e.Button == MouseButtons.Left)
          mm[i,j,k] = (mm[i,j,k]+9)%10;

        this.checkAll();

        if(!this.isTip)
          this.Invalidate(new Rectangle (i*L/9-2, j*L/9-2, L/9-2, L/9-2));
        else
          this.Invalidate();
      }

      if(checkWin())
        MessageBox.Show("Congratulations !");
    }

    private void checkAll()
    {
      for(int i=0; i<=8; i++) 
        for(int j=0; j<=8; j++)
          mmCorr[i,j] = check(i,j);
    }

    private bool check(int i0,int j0)
    {
      if(mm[i0,j0,1]==0)
        return true;

      int [,] mm2 = new int[9, 9];

      for(int i=0; i<=8; i++) 
        for(int j=0; j<=8; j++)
          mm2[i,j] = mm[i,j,0]+mm[i,j,1];

      for(int j=0; j<=8; j++)
        if(j!=j0 && mm2[i0,j]==mm2[i0,j0])
          return false;

      for(int i=0; i<=8; i++)
        if(i!=i0 && mm2[i,j0]==mm2[i0,j0])
          return false;

      int di = i0/3,dj = j0/3;

      for(int i1=di*3; i1<=di*3+2; i1++)
        for(int j1=dj*3; j1<=dj*3+2; j1++)
          if((i1!=i0 || j1!=j0) && mm2[i1,j1]==mm2[i0,j0])
            return false;

      return true;
    }

    private bool checkWin()
    {
      for(int i=0; i<=8; i++) 
        for(int j=0; j<=8; j++)
          if(!mmCorr[i,j] || (mm[i,j,0]==0 && mm[i,j,1]==0))
            return false;

      return true;
    }

    #region Drawing
    private void FormMain_Paint(object sender, PaintEventArgs e)
    {
      Graphics g = e.Graphics;

      this.drawGrid(g);
      this.drawMatrix(g);

      if(isTip && !isEditorMode)
        this.drawTip(g);
    }

    private void drawGrid(Graphics g)
    {
      g.FillRectangle(solidBrushW, 0, 0, L, L);

      for(int i=0; i<=3; i++)
      {
        g.DrawLine(penThick, 0, i*L/3, L+1, i*L/3);
        g.DrawLine(penThick, i*L/3, 0, i*L/3, L+1);
      }

      for(int i=0; i<=9; i++)
        if(i%3!=0)
        {
          g.DrawLine(penThin, 0, i*L/9, L+1, i*L/9);
          g.DrawLine(penThin, i*L/9, 0, i*L/9, L+1);
        }
    }

    private void drawMatrix(Graphics g)
    {
      solidBrush.Color = MapColor;
      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

      for(int i=0; i<=8; i++)
        for(int j=0; j<=8; j++)
          if(mm[i,j,0]!=0)
            g.DrawString(mm[i,j,0].ToString(),
              font,
              solidBrush,
              new Rectangle(i*L/9, j*L/9, L/9, L/9),
              sf);

      for(int i=0; i<=8; i++)
        for(int j=0; j<=8; j++)
          if(mm[i,j,1]!=0)
          {
            solidBrush.Color = mmCorr[i,j] ? CorrectColor : WrongColor;
            g.DrawString(mm[i,j,1].ToString(),
              font,
              solidBrush,
              new Rectangle(i*L/9, j*L/9, L/9, L/9),
              sf);
          }
    }

    private void drawTip(Graphics g)
    {
      solidBrush.Color = TipColor;

      for(int i=0; i<=8; i++)
        for(int j=0; j<=8; j++)
          if(mm[i,j,0]==0 && mm[i,j,1]==0)
          {
            int tip = 0;

            for(int t=1; t<=9; t++)
            {
              mm[i,j,1]=t;
              if(check(i,j))
                tip++;
            }

            mm[i,j,1]=0;

            g.DrawString(tip.ToString(),
              fontTip,
              solidBrush,
              new Rectangle(i*L/9, j*L/9, L/27, L/27),
              sf);
          }
    }
    #endregion

    #region menuGame... click
    private void menuGameNewEasy_Click(object sender, System.EventArgs e)
    {
      gameNew("easy");
    }

    private void menuGameNewNormal_Click(object sender, System.EventArgs e)
    {
      gameNew("normal");
    }

    private void menuGameNewHard_Click(object sender, System.EventArgs e)
    {
      gameNew("hard");
    }

    private void menuGameNewExteme_Click(object sender, System.EventArgs e)
    {
      gameNew("extreme");
    }

    private void menuGameReset_Click(object sender, System.EventArgs e)
    {
      gameReset();
    }

    private void menuGameOpen_Click(object sender, System.EventArgs e)
    {
      gameOpen();
    }

    private void menuGameSave_Click(object sender, System.EventArgs e)
    {
      gameSave();
    }

    private void menuGameExport_Click(object sender, System.EventArgs e)
    {
      gameExport();
    }

    private void menuGameExit_Click(object sender, System.EventArgs e)
    {
      gameExit();
    }
    #endregion

    #region menuOptions... click
    private void menuOptionsFont_Click(object sender, System.EventArgs e)
    {
      selectFont();
    }

    private void menuOtionsEditorMode_Click(object sender, System.EventArgs e)
    {
      setEditor();
    }

    private void menuOptionsHardcore_Click(object sender, System.EventArgs e)
    {
      setHardcore();
    }
    #endregion

    #region menuHelp... click
    private void menuHelpAbout_Click(object sender, System.EventArgs e)
    {
      showAbout();
    }

    private void menuHelpTip_Click(object sender, System.EventArgs e)
    {
      setTip();
    }
    #endregion

    #region Game Operations
    private void gameNew(string diff)
    {
      try
      {
        string fn = Application.StartupPath +@"\Maps\"+diff + ".map";

        FileInfo fi = new FileInfo(fn);
        StreamReader sr = new StreamReader(fn);
        System.Random r = new Random(System.DateTime.Now.Millisecond);

        int mapsCount = (int)fi.Length/83;  // 83 is map Length
        int numMap = r.Next(0, mapsCount-1);

        string s = "";

        for(int i=0;i <=numMap; i++)
          s = sr.ReadLine();

        int t=0;

        for(int i=0; i<=8; i++)
          for(int j=0; j<=8; j++)            
          {
            mm[i,j,0] = Convert.ToInt32(s[t++].ToString());
            mm[i,j,1] = 0;
          }

        sr.Close();

        this.checkAll();
        this.Refresh();
        this.Enabled = true;
      }
      catch
      {
        MessageBox.Show("Error opening map");
        return;
      }
    }

    private void gameReset()
    {
      for(int i=0; i<=8; i++)
        for(int j=0; j<=8; j++)
        {
          mm[i,j,1] = 0;
          mmCorr[i,j] = true;
        }

      this.Refresh();
    }

    private void gameOpen()
    {
      openFileDialog.ShowDialog();
      string fn = openFileDialog.FileName;

      if(fn!="")
      {
        try
        {
          StreamReader reader = new StreamReader(fn);
          string s = reader.ReadToEnd();
          reader.Close();

          int t=0;
          for(int k=0; k<=1; k++)
            for(int i=0; i<=8; i++)
              for(int j=0; j<=8; j++)            
                mm[i,j,k] = Convert.ToInt32(s[t++].ToString());
          
          this.checkAll();
          this.Refresh();
          this.Enabled = true;
        }
        catch
        {
          MessageBox.Show("Error opening game");
        }
      }
    }
    private void gameSave()
    {
      saveFileDialog.ShowDialog();
      string fn = saveFileDialog.FileName;

      if(fn!="")
      {
        try
        {
          StreamWriter writer = new StreamWriter(fn);

          for(int k=0; k<=1; k++)
            for(int i=0; i<=8; i++)
              for(int j=0; j<=8; j++)
                writer.Write(this.mm[i,j,k].ToString());
          
          writer.Close();
        }
        catch
        {
          MessageBox.Show("Error saving game");
        }
      }
    }

    private void gameExport()
    {
      saveFileDialogExport.ShowDialog();
      string fn = saveFileDialogExport.FileName;

      if(fn!="")
      {
        try
        {
          StreamReader reader = new StreamReader(Application.StartupPath + @"\exp.tpl");
          string str = reader.ReadToEnd();
          reader.Close();

          string strMap = "";

          for(int i=0; i<=8; i++)
            for(int j=0; j<=8; j++)
              strMap += mm[j,i,0];

          str = str.Replace("000000000000000000000000000000000000000000000000000000000000000000000000000000000", strMap);

          StreamWriter writer = new StreamWriter(fn);
          writer.WriteLine(str);
          writer.Close();

          System.Diagnostics.Process.Start(fn);
        }
        catch
        {
          MessageBox.Show("Error exporting game");
        }
      }
    }

    private void gameExit()
    {
      DialogResult dr = MessageBox.Show("Sure?","",MessageBoxButtons.YesNo);
      if(dr == DialogResult.Yes)
        Application.Exit();
    }
    #endregion

    #region Options operations
    private void selectFont()
    {
      Font tmpFont;
      fontDialog.Font = this.font;
      fontDialog.ShowDialog();

      tmpFont = fontDialog.Font;

      if(tmpFont.Height>=L/9)
        MessageBox.Show("Too large");
      else if(tmpFont.Height<=L/27)
        MessageBox.Show("Too small");
      else
      {
        this.font = tmpFont;
        this.fontTip = new Font(tmpFont.FontFamily, tmpFont.Size/3);
      }

      this.Refresh();
    }

    private void setEditor()
    {
      this.isEditorMode = !this.menuOtionsEditorMode.Checked;
      this.menuOtionsEditorMode.Checked = this.isEditorMode;
      this.gameReset();

      this.Refresh();
    }

    private void setHardcore()
    {
      bool hc = !this.menuOptionsHardcore.Checked;

      if(hc)
        this.WrongColor = this.CorrectColor;
      else
        this.setColors();

      this.menuOptionsHardcore.Checked = hc;
      this.isHardcoreMode = hc;

      this.Refresh();
    }
    #endregion

    #region Help Operations
    private void showAbout()
    {
      MessageBox.Show("Sudoku v.1.0 by CB\nhttp://sudoku.org.ua\n© 2005");
    }

    private void setTip()
    {
      if(!isHardcoreMode)
      {
        this.menuHelpTip.Checked ^= true;
        this.isTip ^= true;
        this.Refresh();
      }
      else
        MessageBox.Show("You cannot use tips in hardcore mode!");
    }
    #endregion
  }
}