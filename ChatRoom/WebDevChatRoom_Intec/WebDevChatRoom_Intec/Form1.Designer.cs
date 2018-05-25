namespace WebDevChatRoom_Intec
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
            this.components = new System.ComponentModel.Container();
            this.listViewUsers = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.listview_chat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listViewUsers
            // 
            this.listViewUsers.Location = new System.Drawing.Point(372, 61);
            this.listViewUsers.Name = "listViewUsers";
            this.listViewUsers.Size = new System.Drawing.Size(224, 221);
            this.listViewUsers.TabIndex = 1;
            this.listViewUsers.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Usuarios Conectados";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Opciones del Usuario";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(13, 398);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(256, 42);
            this.txtInput.TabIndex = 4;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(276, 398);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(89, 42);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(463, 319);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(100, 20);
            this.txtServer.TabIndex = 6;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(463, 346);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Server";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(422, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Port";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(492, 401);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(71, 23);
            this.btnConnect.TabIndex = 10;
            this.btnConnect.Text = "CONNECT";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(394, 375);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Username";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(463, 372);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 12;
            // 
            // listview_chat
            // 
            this.listview_chat.Location = new System.Drawing.Point(13, 61);
            this.listview_chat.Multiline = true;
            this.listview_chat.Name = "listview_chat";
            this.listview_chat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.listview_chat.Size = new System.Drawing.Size(352, 327);
            this.listview_chat.TabIndex = 13;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(608, 487);
            this.Controls.Add(this.listview_chat);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listViewUsers);
            this.Name = "Form1";
            this.Text = "WebDev Chatroom_INTEC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox listview_chat;
    }
}

