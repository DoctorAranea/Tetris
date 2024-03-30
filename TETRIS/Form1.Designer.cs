
namespace TETRIS
{
    partial class GameForm
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
            this.tetrisGame1 = new TETRIS.TetrisGameProject.TetrisGame();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.nextFigurePB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nextFigurePB)).BeginInit();
            this.SuspendLayout();
            // 
            // tetrisGame1
            // 
            this.tetrisGame1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tetrisGame1.Location = new System.Drawing.Point(12, 12);
            this.tetrisGame1.Name = "tetrisGame1";
            this.tetrisGame1.Size = new System.Drawing.Size(250, 500);
            this.tetrisGame1.TabIndex = 0;
            this.tetrisGame1.Text = "5";
            // 
            // scoreLabel
            // 
            this.scoreLabel.Font = new System.Drawing.Font("MS PGothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(268, 487);
            this.scoreLabel.MinimumSize = new System.Drawing.Size(100, 25);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(106, 25);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "0";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nextFigurePB
            // 
            this.nextFigurePB.Location = new System.Drawing.Point(271, 12);
            this.nextFigurePB.Name = "nextFigurePB";
            this.nextFigurePB.Size = new System.Drawing.Size(100, 100);
            this.nextFigurePB.TabIndex = 2;
            this.nextFigurePB.TabStop = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(23)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(380, 523);
            this.Controls.Add(this.nextFigurePB);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.tetrisGame1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.Text = "Тетрис";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.nextFigurePB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TetrisGameProject.TetrisGame tetrisGame1;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.PictureBox nextFigurePB;
    }
}

