namespace FilmMagicProyect
{
    partial class FPremiacion
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
            this.tblClientes = new System.Windows.Forms.DataGridView();
            this.radAnual = new System.Windows.Forms.RadioButton();
            this.radMensual = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.tblClientes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblClientes
            // 
            this.tblClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblClientes.Location = new System.Drawing.Point(319, 26);
            this.tblClientes.Name = "tblClientes";
            this.tblClientes.Size = new System.Drawing.Size(421, 245);
            this.tblClientes.TabIndex = 0;
            // 
            // radAnual
            // 
            this.radAnual.AutoSize = true;
            this.radAnual.Location = new System.Drawing.Point(25, 65);
            this.radAnual.Name = "radAnual";
            this.radAnual.Size = new System.Drawing.Size(81, 17);
            this.radAnual.TabIndex = 1;
            this.radAnual.Text = "Anualmente";
            this.radAnual.UseVisualStyleBackColor = true;
            this.radAnual.CheckedChanged += new System.EventHandler(this.radAnual_CheckedChanged);
            // 
            // radMensual
            // 
            this.radMensual.AutoSize = true;
            this.radMensual.Checked = true;
            this.radMensual.Location = new System.Drawing.Point(25, 31);
            this.radMensual.Name = "radMensual";
            this.radMensual.Size = new System.Drawing.Size(94, 17);
            this.radMensual.TabIndex = 2;
            this.radMensual.TabStop = true;
            this.radMensual.Text = "Mensualmente";
            this.radMensual.UseVisualStyleBackColor = true;
            this.radMensual.CheckedChanged += new System.EventHandler(this.radMensual_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radMensual);
            this.groupBox1.Controls.Add(this.radAnual);
            this.groupBox1.Location = new System.Drawing.Point(1, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 110);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar clientes premiados por:";
            // 
            // FPremiacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 312);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tblClientes);
            this.Name = "FPremiacion";
            this.Text = "FPremiacion";
            ((System.ComponentModel.ISupportInitialize)(this.tblClientes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tblClientes;
        private System.Windows.Forms.RadioButton radAnual;
        private System.Windows.Forms.RadioButton radMensual;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}