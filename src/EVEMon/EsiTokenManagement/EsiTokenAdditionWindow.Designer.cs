using EVEMon.ApiCredentialsManagement;
using EVEMon.Common.Controls;
using EVEMon.Common.Controls.MultiPanel;
using EVEMon.Common.Enumerations;

namespace EVEMon.EsiTokenManagement
{
    partial class EsiTokenAdditionWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EsiTokenAdditionWindow));
            this.FetchingDataLabel = new System.Windows.Forms.Label();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.ButtonPrevious = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.MainMultiPanel = new EVEMon.Common.Controls.MultiPanel.MultiPanel();
            this.CredentialsPage = new EVEMon.Common.Controls.MultiPanel.MultiPanelPage();
            this.authCodeLabel = new System.Windows.Forms.Label();
            this.clientSecretLabel = new System.Windows.Forms.Label();
            this.clientIdLabel = new System.Windows.Forms.Label();
            this.clientIdTextBox = new System.Windows.Forms.TextBox();
            this.clientSecretTextBox = new System.Windows.Forms.TextBox();
            this.authCodeTextBox = new System.Windows.Forms.TextBox();
            this.WaitingPage = new EVEMon.Common.Controls.MultiPanel.MultiPanelPage();
            this.Throbber = new EVEMon.Common.Controls.Throbber();
            this.ResultPage = new EVEMon.Common.Controls.MultiPanel.MultiPanelPage();
            this.KeyTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.KeyLabel = new System.Windows.Forms.Label();
            this.KeyPicture = new System.Windows.Forms.PictureBox();
            this.CharactersGroupBox = new System.Windows.Forms.GroupBox();
            this.ResultsMultiPanel = new EVEMon.Common.Controls.MultiPanel.MultiPanel();
            this.CharacterPage = new EVEMon.Common.Controls.MultiPanel.MultiPanelPage();
            this.ImportedCharacterLabel = new System.Windows.Forms.Label();
            this.ImportedLabel = new System.Windows.Forms.Label();
            this.GeneralErrorPage = new EVEMon.Common.Controls.MultiPanel.MultiPanelPage();
            this.GeneralErrorLabel = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.esiTokenInstructionsLink = new System.Windows.Forms.LinkLabel();
            this.MainMultiPanel.SuspendLayout();
            this.CredentialsPage.SuspendLayout();
            this.WaitingPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Throbber)).BeginInit();
            this.ResultPage.SuspendLayout();
            this.KeyTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KeyPicture)).BeginInit();
            this.CharactersGroupBox.SuspendLayout();
            this.ResultsMultiPanel.SuspendLayout();
            this.CharacterPage.SuspendLayout();
            this.GeneralErrorPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // FetchingDataLabel
            // 
            this.FetchingDataLabel.Location = new System.Drawing.Point(209, 71);
            this.FetchingDataLabel.Name = "FetchingDataLabel";
            this.FetchingDataLabel.Size = new System.Drawing.Size(153, 24);
            this.FetchingDataLabel.TabIndex = 1;
            this.FetchingDataLabel.Text = "Fetching data from CCP...";
            this.FetchingDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonNext
            // 
            this.ButtonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonNext.Location = new System.Drawing.Point(337, 177);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(75, 23);
            this.ButtonNext.TabIndex = 1;
            this.ButtonNext.Text = "&Next >";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // ButtonPrevious
            // 
            this.ButtonPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonPrevious.Enabled = false;
            this.ButtonPrevious.Location = new System.Drawing.Point(256, 177);
            this.ButtonPrevious.Name = "ButtonPrevious";
            this.ButtonPrevious.Size = new System.Drawing.Size(75, 23);
            this.ButtonPrevious.TabIndex = 0;
            this.ButtonPrevious.Text = "< &Previous";
            this.ButtonPrevious.UseVisualStyleBackColor = true;
            this.ButtonPrevious.Click += new System.EventHandler(this.ButtonPrevious_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.CausesValidation = false;
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(435, 177);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "&Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // MainMultiPanel
            // 
            this.MainMultiPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainMultiPanel.Controls.Add(this.CredentialsPage);
            this.MainMultiPanel.Controls.Add(this.WaitingPage);
            this.MainMultiPanel.Controls.Add(this.ResultPage);
            this.MainMultiPanel.Location = new System.Drawing.Point(0, 0);
            this.MainMultiPanel.Name = "MainMultiPanel";
            this.MainMultiPanel.SelectedPage = this.CredentialsPage;
            this.MainMultiPanel.Size = new System.Drawing.Size(522, 171);
            this.MainMultiPanel.TabIndex = 0;
            // 
            // CredentialsPage
            // 
            this.CredentialsPage.CausesValidation = false;
            this.CredentialsPage.Controls.Add(this.esiTokenInstructionsLink);
            this.CredentialsPage.Controls.Add(this.authCodeLabel);
            this.CredentialsPage.Controls.Add(this.clientSecretLabel);
            this.CredentialsPage.Controls.Add(this.clientIdLabel);
            this.CredentialsPage.Controls.Add(this.clientIdTextBox);
            this.CredentialsPage.Controls.Add(this.clientSecretTextBox);
            this.CredentialsPage.Controls.Add(this.authCodeTextBox);
            this.CredentialsPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CredentialsPage.Location = new System.Drawing.Point(0, 0);
            this.CredentialsPage.Name = "CredentialsPage";
            this.CredentialsPage.Size = new System.Drawing.Size(522, 171);
            this.CredentialsPage.TabIndex = 0;
            this.CredentialsPage.Text = "credentialsPage";
            // 
            // authCodeLabel
            // 
            this.authCodeLabel.AutoSize = true;
            this.authCodeLabel.Location = new System.Drawing.Point(23, 117);
            this.authCodeLabel.Name = "authCodeLabel";
            this.authCodeLabel.Size = new System.Drawing.Size(35, 13);
            this.authCodeLabel.TabIndex = 10;
            this.authCodeLabel.Text = "Code:";
            // 
            // clientSecretLabel
            // 
            this.clientSecretLabel.AutoSize = true;
            this.clientSecretLabel.Location = new System.Drawing.Point(23, 78);
            this.clientSecretLabel.Name = "clientSecretLabel";
            this.clientSecretLabel.Size = new System.Drawing.Size(62, 13);
            this.clientSecretLabel.TabIndex = 9;
            this.clientSecretLabel.Text = "Secret Key:";
            // 
            // clientIdLabel
            // 
            this.clientIdLabel.AutoSize = true;
            this.clientIdLabel.Location = new System.Drawing.Point(23, 39);
            this.clientIdLabel.Name = "clientIdLabel";
            this.clientIdLabel.Size = new System.Drawing.Size(50, 13);
            this.clientIdLabel.TabIndex = 8;
            this.clientIdLabel.Text = "Client ID:";
            // 
            // clientIdTextBox
            // 
            this.clientIdTextBox.Location = new System.Drawing.Point(23, 55);
            this.clientIdTextBox.Name = "clientIdTextBox";
            this.clientIdTextBox.Size = new System.Drawing.Size(264, 20);
            this.clientIdTextBox.TabIndex = 7;
            // 
            // clientSecretTextBox
            // 
            this.clientSecretTextBox.Location = new System.Drawing.Point(23, 94);
            this.clientSecretTextBox.Name = "clientSecretTextBox";
            this.clientSecretTextBox.Size = new System.Drawing.Size(264, 20);
            this.clientSecretTextBox.TabIndex = 6;
            // 
            // authCodeTextBox
            // 
            this.authCodeTextBox.Location = new System.Drawing.Point(23, 133);
            this.authCodeTextBox.Name = "authCodeTextBox";
            this.authCodeTextBox.Size = new System.Drawing.Size(470, 20);
            this.authCodeTextBox.TabIndex = 5;
            // 
            // WaitingPage
            // 
            this.WaitingPage.Controls.Add(this.FetchingDataLabel);
            this.WaitingPage.Controls.Add(this.Throbber);
            this.WaitingPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WaitingPage.Location = new System.Drawing.Point(0, 0);
            this.WaitingPage.Name = "WaitingPage";
            this.WaitingPage.Size = new System.Drawing.Size(522, 171);
            this.WaitingPage.TabIndex = 1;
            this.WaitingPage.Text = "waitingPage";
            // 
            // Throbber
            // 
            this.Throbber.Location = new System.Drawing.Point(179, 71);
            this.Throbber.MaximumSize = new System.Drawing.Size(24, 24);
            this.Throbber.MinimumSize = new System.Drawing.Size(24, 24);
            this.Throbber.Name = "Throbber";
            this.Throbber.Size = new System.Drawing.Size(24, 24);
            this.Throbber.State = EVEMon.Common.Enumerations.ThrobberState.Stopped;
            this.Throbber.TabIndex = 0;
            this.Throbber.TabStop = false;
            // 
            // ResultPage
            // 
            this.ResultPage.Controls.Add(this.KeyTableLayoutPanel);
            this.ResultPage.Controls.Add(this.CharactersGroupBox);
            this.ResultPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultPage.Location = new System.Drawing.Point(0, 0);
            this.ResultPage.Name = "ResultPage";
            this.ResultPage.Size = new System.Drawing.Size(522, 171);
            this.ResultPage.TabIndex = 2;
            this.ResultPage.Text = "resultPage";
            // 
            // KeyTableLayoutPanel
            // 
            this.KeyTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KeyTableLayoutPanel.AutoSize = true;
            this.KeyTableLayoutPanel.ColumnCount = 2;
            this.KeyTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.141962F));
            this.KeyTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.85804F));
            this.KeyTableLayoutPanel.Controls.Add(this.KeyLabel, 1, 0);
            this.KeyTableLayoutPanel.Controls.Add(this.KeyPicture, 0, 0);
            this.KeyTableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.KeyTableLayoutPanel.Name = "KeyTableLayoutPanel";
            this.KeyTableLayoutPanel.RowCount = 1;
            this.KeyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.KeyTableLayoutPanel.Size = new System.Drawing.Size(498, 38);
            this.KeyTableLayoutPanel.TabIndex = 0;
            // 
            // KeyLabel
            // 
            this.KeyLabel.AutoSize = true;
            this.KeyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeyLabel.Location = new System.Drawing.Point(43, 0);
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(452, 38);
            this.KeyLabel.TabIndex = 1;
            this.KeyLabel.Text = "Short description on info retrieval procedure.";
            this.KeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KeyPicture
            // 
            this.KeyPicture.Image = ((System.Drawing.Image)(resources.GetObject("KeyPicture.Image")));
            this.KeyPicture.Location = new System.Drawing.Point(3, 3);
            this.KeyPicture.Name = "KeyPicture";
            this.KeyPicture.Size = new System.Drawing.Size(32, 32);
            this.KeyPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.KeyPicture.TabIndex = 0;
            this.KeyPicture.TabStop = false;
            // 
            // CharactersGroupBox
            // 
            this.CharactersGroupBox.Controls.Add(this.ResultsMultiPanel);
            this.CharactersGroupBox.Location = new System.Drawing.Point(12, 50);
            this.CharactersGroupBox.Name = "CharactersGroupBox";
            this.CharactersGroupBox.Size = new System.Drawing.Size(479, 118);
            this.CharactersGroupBox.TabIndex = 3;
            this.CharactersGroupBox.TabStop = false;
            this.CharactersGroupBox.Text = "Character";
            // 
            // ResultsMultiPanel
            // 
            this.ResultsMultiPanel.Controls.Add(this.CharacterPage);
            this.ResultsMultiPanel.Controls.Add(this.GeneralErrorPage);
            this.ResultsMultiPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultsMultiPanel.Location = new System.Drawing.Point(3, 16);
            this.ResultsMultiPanel.Name = "ResultsMultiPanel";
            this.ResultsMultiPanel.SelectedPage = this.CharacterPage;
            this.ResultsMultiPanel.Size = new System.Drawing.Size(473, 99);
            this.ResultsMultiPanel.TabIndex = 5;
            // 
            // CharacterPage
            // 
            this.CharacterPage.Controls.Add(this.ImportedCharacterLabel);
            this.CharacterPage.Controls.Add(this.ImportedLabel);
            this.CharacterPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CharacterPage.Location = new System.Drawing.Point(0, 0);
            this.CharacterPage.Name = "CharacterPage";
            this.CharacterPage.Size = new System.Drawing.Size(473, 99);
            this.CharacterPage.TabIndex = 0;
            this.CharacterPage.Text = "characterPage";
            // 
            // ImportedCharacterLabel
            // 
            this.ImportedCharacterLabel.AutoSize = true;
            this.ImportedCharacterLabel.Location = new System.Drawing.Point(187, 43);
            this.ImportedCharacterLabel.Name = "ImportedCharacterLabel";
            this.ImportedCharacterLabel.Size = new System.Drawing.Size(53, 13);
            this.ImportedCharacterLabel.TabIndex = 1;
            this.ImportedCharacterLabel.Text = "John Doe";
            // 
            // ImportedLabel
            // 
            this.ImportedLabel.AutoSize = true;
            this.ImportedLabel.Location = new System.Drawing.Point(102, 43);
            this.ImportedLabel.Name = "ImportedLabel";
            this.ImportedLabel.Size = new System.Drawing.Size(79, 13);
            this.ImportedLabel.TabIndex = 0;
            this.ImportedLabel.Text = "ESI Token for: ";
            // 
            // GeneralErrorPage
            // 
            this.GeneralErrorPage.Controls.Add(this.GeneralErrorLabel);
            this.GeneralErrorPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeneralErrorPage.Location = new System.Drawing.Point(0, 0);
            this.GeneralErrorPage.Name = "GeneralErrorPage";
            this.GeneralErrorPage.Size = new System.Drawing.Size(473, 99);
            this.GeneralErrorPage.TabIndex = 3;
            this.GeneralErrorPage.Text = "generalErrorPage";
            // 
            // GeneralErrorLabel
            // 
            this.GeneralErrorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeneralErrorLabel.Location = new System.Drawing.Point(0, 0);
            this.GeneralErrorLabel.Name = "GeneralErrorLabel";
            this.GeneralErrorLabel.Padding = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.GeneralErrorLabel.Size = new System.Drawing.Size(473, 99);
            this.GeneralErrorLabel.TabIndex = 0;
            this.GeneralErrorLabel.Text = "An error occurred while retrieving the information.\r\n\r\nThe error message was: {0}" +
    "";
            this.GeneralErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // esiTokenInstructionsLink
            // 
            this.esiTokenInstructionsLink.AutoSize = true;
            this.esiTokenInstructionsLink.LinkArea = new System.Windows.Forms.LinkArea(24, 72);
            this.esiTokenInstructionsLink.Location = new System.Drawing.Point(23, 17);
            this.esiTokenInstructionsLink.Name = "esiTokenInstructionsLink";
            this.esiTokenInstructionsLink.Size = new System.Drawing.Size(369, 17);
            this.esiTokenInstructionsLink.TabIndex = 11;
            this.esiTokenInstructionsLink.TabStop = true;
            this.esiTokenInstructionsLink.Text = "For instructions visit: https://evemondevteam.github.io/evemon/esitokens";
            this.esiTokenInstructionsLink.UseCompatibleTextRendering = true;
            this.esiTokenInstructionsLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.esiTokenInstructionsLink_LinkClicked);
            // 
            // EsiTokenAdditionWindow
            // 
            this.AcceptButton = this.ButtonNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(522, 212);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonPrevious);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.MainMultiPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EsiTokenAdditionWindow";
            this.Text = "ESI Token Importation";
            this.MainMultiPanel.ResumeLayout(false);
            this.CredentialsPage.ResumeLayout(false);
            this.CredentialsPage.PerformLayout();
            this.WaitingPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Throbber)).EndInit();
            this.ResultPage.ResumeLayout(false);
            this.ResultPage.PerformLayout();
            this.KeyTableLayoutPanel.ResumeLayout(false);
            this.KeyTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KeyPicture)).EndInit();
            this.CharactersGroupBox.ResumeLayout(false);
            this.ResultsMultiPanel.ResumeLayout(false);
            this.CharacterPage.ResumeLayout(false);
            this.CharacterPage.PerformLayout();
            this.GeneralErrorPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MultiPanel MainMultiPanel;
        private MultiPanelPage CredentialsPage;
        private System.Windows.Forms.Button ButtonNext;
        private System.Windows.Forms.Button ButtonPrevious;
        private System.Windows.Forms.Button ButtonCancel;
        private MultiPanelPage WaitingPage;
        private Throbber Throbber;
        private MultiPanelPage ResultPage;
        private System.Windows.Forms.PictureBox KeyPicture;
        private System.Windows.Forms.GroupBox CharactersGroupBox;
        private System.Windows.Forms.TableLayoutPanel KeyTableLayoutPanel;
        private System.Windows.Forms.Label KeyLabel;
        private MultiPanel ResultsMultiPanel;
        private MultiPanelPage CharacterPage;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private MultiPanelPage GeneralErrorPage;
        private System.Windows.Forms.Label GeneralErrorLabel;
        private System.Windows.Forms.Label FetchingDataLabel;
        private System.Windows.Forms.TextBox authCodeTextBox;
        private System.Windows.Forms.Label clientIdLabel;
        private System.Windows.Forms.TextBox clientIdTextBox;
        private System.Windows.Forms.TextBox clientSecretTextBox;
        private System.Windows.Forms.Label authCodeLabel;
        private System.Windows.Forms.Label clientSecretLabel;
        private System.Windows.Forms.Label ImportedCharacterLabel;
        private System.Windows.Forms.Label ImportedLabel;
        private System.Windows.Forms.LinkLabel esiTokenInstructionsLink;
    }
}