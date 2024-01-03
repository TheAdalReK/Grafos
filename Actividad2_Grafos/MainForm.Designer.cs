/*
 * Created by SharpDevelop.
 * User: Adalberto
 * Date: 12/10/2023
 * Time: 08:19 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Actividad2_Grafos
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox pictureBoxImage;
		private System.Windows.Forms.Button buttonImagen;
		private System.Windows.Forms.Button buttonAnalizar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TreeView treeViewGrafo;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBoxImage = new System.Windows.Forms.PictureBox();
			this.buttonImagen = new System.Windows.Forms.Button();
			this.buttonAnalizar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.treeViewGrafo = new System.Windows.Forms.TreeView();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxImage
			// 
			this.pictureBoxImage.Location = new System.Drawing.Point(13, 13);
			this.pictureBoxImage.Name = "pictureBoxImage";
			this.pictureBoxImage.Size = new System.Drawing.Size(691, 472);
			this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxImage.TabIndex = 0;
			this.pictureBoxImage.TabStop = false;
			this.pictureBoxImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxImageMouseClick);
			// 
			// buttonImagen
			// 
			this.buttonImagen.Location = new System.Drawing.Point(710, 13);
			this.buttonImagen.Name = "buttonImagen";
			this.buttonImagen.Size = new System.Drawing.Size(227, 85);
			this.buttonImagen.TabIndex = 1;
			this.buttonImagen.Text = "Seleccionar Imagen";
			this.buttonImagen.UseVisualStyleBackColor = true;
			this.buttonImagen.Click += new System.EventHandler(this.ButtonImagenClick);
			// 
			// buttonAnalizar
			// 
			this.buttonAnalizar.Location = new System.Drawing.Point(710, 117);
			this.buttonAnalizar.Name = "buttonAnalizar";
			this.buttonAnalizar.Size = new System.Drawing.Size(227, 78);
			this.buttonAnalizar.TabIndex = 2;
			this.buttonAnalizar.Text = "Analizar";
			this.buttonAnalizar.UseVisualStyleBackColor = true;
			this.buttonAnalizar.Click += new System.EventHandler(this.ButtonAnalizarClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(964, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(257, 384);
			this.label1.TabIndex = 3;
			// 
			// treeViewGrafo
			// 
			this.treeViewGrafo.Location = new System.Drawing.Point(711, 202);
			this.treeViewGrafo.Name = "treeViewGrafo";
			this.treeViewGrafo.Size = new System.Drawing.Size(226, 283);
			this.treeViewGrafo.TabIndex = 4;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1233, 497);
			this.Controls.Add(this.treeViewGrafo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonAnalizar);
			this.Controls.Add(this.buttonImagen);
			this.Controls.Add(this.pictureBoxImage);
			this.Name = "MainForm";
			this.Text = "Actividad2_Grafos";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
