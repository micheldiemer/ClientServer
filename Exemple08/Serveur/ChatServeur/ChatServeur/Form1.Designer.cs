namespace ChatServeur
{
    partial class Fm_serveur
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
            this.tb_ipV4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_messages = new System.Windows.Forms.ListBox();
            this.bl_nbMessage = new System.Windows.Forms.Label();
            this.lbl_nbMessages = new System.Windows.Forms.Label();
            this.lb_nbmessages = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adresse IP :";
            // 
            // tb_ipV4
            // 
            this.tb_ipV4.Location = new System.Drawing.Point(92, 18);
            this.tb_ipV4.Name = "tb_ipV4";
            this.tb_ipV4.ReadOnly = true;
            this.tb_ipV4.Size = new System.Drawing.Size(149, 23);
            this.tb_ipV4.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Message :";
            // 
            // lb_messages
            // 
            this.lb_messages.FormattingEnabled = true;
            this.lb_messages.ItemHeight = 15;
            this.lb_messages.Location = new System.Drawing.Point(41, 86);
            this.lb_messages.Name = "lb_messages";
            this.lb_messages.Size = new System.Drawing.Size(294, 169);
            this.lb_messages.TabIndex = 6;
            this.lb_messages.SelectedIndexChanged += new System.EventHandler(this.lb_messages_SelectedIndexChanged);
            // 
            // bl_nbMessage
            // 
            this.bl_nbMessage.AutoSize = true;
            this.bl_nbMessage.Location = new System.Drawing.Point(41, 258);
            this.bl_nbMessage.Name = "bl_nbMessage";
            this.bl_nbMessage.Size = new System.Drawing.Size(0, 15);
            this.bl_nbMessage.TabIndex = 7;
            // 
            // lbl_nbMessages
            // 
            this.lbl_nbMessages.AutoSize = true;
            this.lbl_nbMessages.Location = new System.Drawing.Point(41, 273);
            this.lbl_nbMessages.Name = "lbl_nbMessages";
            this.lbl_nbMessages.Size = new System.Drawing.Size(0, 15);
            this.lbl_nbMessages.TabIndex = 8;
            // 
            // lb_nbmessages
            // 
            this.lb_nbmessages.AutoSize = true;
            this.lb_nbmessages.Location = new System.Drawing.Point(40, 267);
            this.lb_nbmessages.Name = "lb_nbmessages";
            this.lb_nbmessages.Size = new System.Drawing.Size(0, 15);
            this.lb_nbmessages.TabIndex = 9;
            // 
            // Fm_serveur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 346);
            this.Controls.Add(this.lb_nbmessages);
            this.Controls.Add(this.lbl_nbMessages);
            this.Controls.Add(this.bl_nbMessage);
            this.Controls.Add(this.lb_messages);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_ipV4);
            this.Controls.Add(this.label1);
            this.Name = "Fm_serveur";
            this.Text = "Serveur 01";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private TextBox tb_ipV4;
        private Label label3;
        private ListBox lb_messages;
        private Label bl_nbMessage;
        private Label lbl_nbMessages;
        private Label lb_nbmessages;
    }
}