namespace BattleShipsServer
{
    partial class frmUserMessage
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
                //components.Dispose();
            }
            this.Hide();
            //base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtConversationBox = new System.Windows.Forms.TextBox();
            this.txtMessageToSend = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtConversationBox
            // 
            this.txtConversationBox.Location = new System.Drawing.Point(12, 25);
            this.txtConversationBox.Multiline = true;
            this.txtConversationBox.Name = "txtConversationBox";
            this.txtConversationBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConversationBox.Size = new System.Drawing.Size(490, 391);
            this.txtConversationBox.TabIndex = 0;
            // 
            // txtMessageToSend
            // 
            this.txtMessageToSend.Location = new System.Drawing.Point(12, 422);
            this.txtMessageToSend.Name = "txtMessageToSend";
            this.txtMessageToSend.Size = new System.Drawing.Size(409, 20);
            this.txtMessageToSend.TabIndex = 1;
            this.txtMessageToSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessageToSend_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Message";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(427, 420);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSendMessage.TabIndex = 3;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // frmUserMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 451);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMessageToSend);
            this.Controls.Add(this.txtConversationBox);
            this.MinimizeBox = false;
            this.Name = "frmUserMessage";
            this.Text = "Private message";
            this.Load += new System.EventHandler(this.frmUserMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConversationBox;
        private System.Windows.Forms.TextBox txtMessageToSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendMessage;
    }
}