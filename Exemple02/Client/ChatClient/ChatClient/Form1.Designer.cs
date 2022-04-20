namespace ChatClient
{
    partial class Fm_client
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_ipDestinataire = new System.Windows.Forms.TextBox();
            this.tb_message = new System.Windows.Forms.TextBox();
            this.bt_envoyer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Destinataire : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Message : ";
            // 
            // tb_ipDestinataire
            // 
            this.tb_ipDestinataire.Location = new System.Drawing.Point(150, 35);
            this.tb_ipDestinataire.Name = "tb_ipDestinataire";
            this.tb_ipDestinataire.Size = new System.Drawing.Size(202, 23);
            this.tb_ipDestinataire.TabIndex = 2;
            // 
            // tb_message
            // 
            this.tb_message.Location = new System.Drawing.Point(150, 65);
            this.tb_message.Name = "tb_message";
            this.tb_message.Size = new System.Drawing.Size(202, 23);
            this.tb_message.TabIndex = 3;
            // 
            // bt_envoyer
            // 
            this.bt_envoyer.Location = new System.Drawing.Point(150, 109);
            this.bt_envoyer.Name = "bt_envoyer";
            this.bt_envoyer.Size = new System.Drawing.Size(75, 23);
            this.bt_envoyer.TabIndex = 4;
            this.bt_envoyer.Text = "Envoyer";
            this.bt_envoyer.UseVisualStyleBackColor = true;
            this.bt_envoyer.Click += new System.EventHandler(this.bt_envoyer_Click);
            // 
            // Fm_client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 159);
            this.Controls.Add(this.bt_envoyer);
            this.Controls.Add(this.tb_message);
            this.Controls.Add(this.tb_ipDestinataire);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Fm_client";
            this.Text = "Client 01";
            this.Load += new System.EventHandler(this.Fm_client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tb_ipDestinataire;
        private TextBox tb_message;
        private Button bt_envoyer;
    }
}