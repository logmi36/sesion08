
namespace s07_02
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lienzo = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Custom-shape-tool_34547.png");
            this.imageList1.Images.SetKeyName(1, "Triangle_34546.png");
            this.imageList1.Images.SetKeyName(2, "Pentagon_34543 (1).png");
            // 
            // lienzo
            // 
            this.lienzo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lienzo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lienzo.Location = new System.Drawing.Point(0, 0);
            this.lienzo.Name = "lienzo";
            this.lienzo.Size = new System.Drawing.Size(734, 611);
            this.lienzo.TabIndex = 0;
            this.lienzo.Paint += new System.Windows.Forms.PaintEventHandler(this.lienzo_Paint);
            this.lienzo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lienzo_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 611);
            this.Controls.Add(this.lienzo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Semana 08";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel lienzo;
        private System.Windows.Forms.Timer timer1;
    }
}

