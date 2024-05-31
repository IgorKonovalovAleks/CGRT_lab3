
namespace CGRT_lab3
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.glControl1 = new OpenTK.GLControl();
      this.trackBar1 = new System.Windows.Forms.TrackBar();
      this.trackBar2 = new System.Windows.Forms.TrackBar();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
      this.SuspendLayout();
      // 
      // glControl1
      // 
      this.glControl1.BackColor = System.Drawing.Color.Black;
      this.glControl1.Location = new System.Drawing.Point(12, 12);
      this.glControl1.Name = "glControl1";
      this.glControl1.Size = new System.Drawing.Size(591, 420);
      this.glControl1.TabIndex = 0;
      this.glControl1.VSync = false;
      this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
      this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
      // 
      // trackBar1
      // 
      this.trackBar1.Location = new System.Drawing.Point(211, 438);
      this.trackBar1.Maximum = 5;
      this.trackBar1.Name = "trackBar1";
      this.trackBar1.Size = new System.Drawing.Size(161, 45);
      this.trackBar1.TabIndex = 1;
      this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
      // 
      // trackBar2
      // 
      this.trackBar2.Location = new System.Drawing.Point(12, 438);
      this.trackBar2.Maximum = 5;
      this.trackBar2.Name = "trackBar2";
      this.trackBar2.Size = new System.Drawing.Size(161, 45);
      this.trackBar2.TabIndex = 2;
      this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(615, 495);
      this.Controls.Add(this.trackBar2);
      this.Controls.Add(this.trackBar1);
      this.Controls.Add(this.glControl1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "RayTracing";
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private OpenTK.GLControl glControl1;
    public System.Windows.Forms.TrackBar trackBar1;
    public System.Windows.Forms.TrackBar trackBar2;
  }
}

