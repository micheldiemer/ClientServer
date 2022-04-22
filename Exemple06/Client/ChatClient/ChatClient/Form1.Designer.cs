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
            this.label3 = new System.Windows.Forms.Label();
            this.tb_pseudo = new System.Windows.Forms.TextBox();
            this.bt_connecter = new System.Windows.Forms.Button();
            this.lb_messages = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Destinataire : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Message : ";
            // 
            // tb_ipDestinataire
            // 
            this.tb_ipDestinataire.Location = new System.Drawing.Point(150, 12);
            this.tb_ipDestinataire.Name = "tb_ipDestinataire";
            this.tb_ipDestinataire.Size = new System.Drawing.Size(202, 23);
            this.tb_ipDestinataire.TabIndex = 2;
            // 
            // tb_message
            // 
            this.tb_message.Location = new System.Drawing.Point(41, 84);
            this.tb_message.Name = "tb_message";
            this.tb_message.Size = new System.Drawing.Size(612, 23);
            this.tb_message.TabIndex = 3;
            // 
            // bt_envoyer
            // 
            this.bt_envoyer.Location = new System.Drawing.Point(578, 113);
            this.bt_envoyer.Name = "bt_envoyer";
            this.bt_envoyer.Size = new System.Drawing.Size(75, 23);
            this.bt_envoyer.TabIndex = 4;
            this.bt_envoyer.Text = "Envoyer";
            this.bt_envoyer.UseVisualStyleBackColor = true;
            this.bt_envoyer.Click += new System.EventHandler(this.Bt_envoyer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pseudo :";
            // 
            // tb_pseudo
            // 
            this.tb_pseudo.Location = new System.Drawing.Point(150, 41);
            this.tb_pseudo.Name = "tb_pseudo";
            this.tb_pseudo.Size = new System.Drawing.Size(202, 23);
            this.tb_pseudo.TabIndex = 6;
            // 
            // bt_connecter
            // 
            this.bt_connecter.Location = new System.Drawing.Point(384, 41);
            this.bt_connecter.Name = "bt_connecter";
            this.bt_connecter.Size = new System.Drawing.Size(117, 23);
            this.bt_connecter.TabIndex = 7;
            this.bt_connecter.Text = "Se connecter";
            this.bt_connecter.UseVisualStyleBackColor = true;
            this.bt_connecter.Click += new System.EventHandler(this.Bt_connecter_Click);
            // 
            // lb_messages
            // 
            this.lb_messages.FormattingEnabled = true;
            this.lb_messages.ItemHeight = 15;
            this.lb_messages.Location = new System.Drawing.Point(41, 142);
            this.lb_messages.Name = "lb_messages";
            this.lb_messages.Size = new System.Drawing.Size(612, 274);
            this.lb_messages.TabIndex = 8;
            // 
            // Fm_client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 439);
            this.Controls.Add(this.lb_messages);
            this.Controls.Add(this.bt_connecter);
            this.Controls.Add(this.tb_pseudo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bt_envoyer);
            this.Controls.Add(this.tb_message);
            this.Controls.Add(this.tb_ipDestinataire);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Fm_client";
            this.Text = "Client Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Fm_client_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tb_ipDestinataire;
        private TextBox tb_message;
        private Button bt_envoyer;
        private Label label3;
        private TextBox tb_pseudo;
        private Button bt_connecter;
        private ListBox lb_messages;
    }
}