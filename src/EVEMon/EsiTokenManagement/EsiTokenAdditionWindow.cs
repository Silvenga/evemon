using System;
using System.Linq;
using System.Windows.Forms;
using EVEMon.Common;
using EVEMon.Common.Constants;
using EVEMon.Common.Controls;
using EVEMon.Common.Controls.MultiPanel;
using EVEMon.Common.CustomEventArgs;
using EVEMon.Common.Enumerations;
using EVEMon.Common.Enumerations.CCPAPI;
using EVEMon.Common.Models;
using EVEMon.Common.Properties;

namespace EVEMon.EsiTokenManagement
{
    public partial class EsiTokenAdditionWindow : EVEMonForm
    {

        private EsiToken m_esiToken;
        private EsiTokenCreationEventArgs m_creationArgs;

        /// <summary>
        /// Constructor for new Esi Token.
        /// </summary>
        public EsiTokenAdditionWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Update the controls visibility depending on whether we are in update or creation mode.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode)
                return;

            MainMultiPanel.SelectedPage = CredentialsPage;
            MainMultiPanel.SelectionChange += MultiPanel_SelectionChange;
        }

        /// <summary>
        /// When we switch panels, we update the "next", "previous" and "cancel" buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MultiPanel_SelectionChange(object sender, MultiPanelSelectionChangeEventArgs args)
        {
            if (args.NewPage == CredentialsPage)
            {
                ButtonPrevious.Enabled = false;
                ButtonNext.Enabled = true;
                ButtonNext.Text = "&Next >";
            }
            else if (args.NewPage == WaitingPage)
            {
                ButtonPrevious.Enabled = true;
                ButtonNext.Enabled = false;
                ButtonNext.Text = "&Next >";
            }
            else
            {
                ButtonPrevious.Enabled = true;
                ButtonNext.Enabled = ResultsMultiPanel.SelectedPage == CharacterPage;
                ButtonNext.Text = "&Import";
                ButtonNext.Focus();
            }
        }

        /// <summary>
        /// Previous.
        /// When the previous button is clicked, we select the first page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            MainMultiPanel.SelectedPage = CredentialsPage;
        }

        /// <summary>
        /// Cancel.
        /// Closes the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Next / Import / Update.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNext_Click(object sender, EventArgs e)
        {
            // Are at the last page ?
            if (MainMultiPanel.SelectedPage == ResultPage)
            {
                Complete();
                return;
            }

            // We are at the first page
            if (!ValidateChildren())
                return;

            MainMultiPanel.SelectedPage = WaitingPage;
            Throbber.State = ThrobberState.Rotating;

            EsiToken.TryAddOrUpdateAsync(clientIdTextBox.Text, clientSecretTextBox.Text, authCodeTextBox.Text, OnUpdated);
        }

        /// <summary>
        /// Validates the operation and closes the window.
        /// </summary>
        private void Complete()
        {
            if (m_creationArgs == null)
                return;

            //m_apiKey = m_creationArgs.CreateOrUpdate();

            //// Takes care of the ignore list
            //foreach (ListViewItem item in CharactersListView.Items)
            //{
            //    CharacterIdentity id = (CharacterIdentity)item.Tag;
            //    // If it's a newly created API key, character monitoring has been already been set
            //    // We only need to deal with those coming out of the ignore list
            //    if (item.Checked)
            //    {
            //        if (m_apiKey.IdentityIgnoreList.Contains(id))
            //        {
            //            m_apiKey.IdentityIgnoreList.Remove(id);
            //            id.CCPCharacter.Monitored = true;
            //        }
            //        continue;
            //    }

            //    // Add character in ignore list if not already
            //    if (!m_apiKey.IdentityIgnoreList.Contains(id))
            //        m_apiKey.IdentityIgnoreList.Add(id.CCPCharacter);
            //}

            // Closes the window
            Close();
        }

        /// <summary>
        /// When API credentials have been updated.
        /// </summary>
        /// <returns></returns>
        private void OnUpdated(object sender, EsiTokenCreationEventArgs e)
        {
            //m_creationArgs = e;

            //CharactersGroupBox.Text = "Characters exposed by API key";

            //// Updates the picture and label for key type
            //switch (e.Type)
            //{
            //    default:
            //        KeyPicture.Image = Resources.KeyWrong32;
            //        KeyLabel.Text = e.KeyTestError;
            //        CharactersGroupBox.Text = "Error report";
            //        ResultsMultiPanel.SelectedPage = GetErrorPage(e);
            //        break;
            //    case CCPAPIKeyType.Account:
            //        KeyPicture.Image = Resources.AccountWide32;
            //        KeyLabel.Text = "This is an 'Account' wide API key.";
            //        ResultsMultiPanel.SelectedPage = CharacterPage;
            //        break;
            //    case CCPAPIKeyType.Character:
            //        KeyPicture.Image = Resources.DefaultCharacterImage32;
            //        KeyLabel.Text = "This is a 'Character' restricted API key.";
            //        ResultsMultiPanel.SelectedPage = CharacterPage;
            //        break;
            //    case CCPAPIKeyType.Corporation:
            //        KeyPicture.Image = Resources.DefaultCorporationImage32;
            //        KeyLabel.Text = "This is a 'Corporation' API key.";
            //        ResultsMultiPanel.SelectedPage = CharacterPage;
            //        break;
            //}

            //// Updates the characters list
            //CharactersListView.Items.Clear();
            //foreach (ListViewItem item in e.Identities.Select(
            //    id => new ListViewItem(id.CharacterName)
            //              {
            //                  Tag = id,
            //                  Checked = m_apiKey == null || !m_apiKey.IdentityIgnoreList.Contains(id)
            //              }))
            //{
            //    CharactersListView.Items.Add(item);
            //}

            //// Issue a warning if the access of the API key is zero
            //if (e.AccessMask == 0)
            //{
            //    WarningLabel.Text = "Beware! This API key does not provide any data!";
            //    WarningLabel.Visible = true;
            //}
            //    // Issue a warning if the access of API key is less than needed for basic features
            //else if (e.Type != CCPAPIKeyType.Corporation && e.AccessMask < (long)CCPAPIMethodsEnum.BasicCharacterFeatures)
            //{
            //    WarningLabel.Text = "Beware! The data this API key provides does not suffice for basic features!";
            //    WarningLabel.Visible = true;
            //}
            //else
            //{
            //    WarningLabel.Visible = m_updateMode;
            //}

            // Selects the last page
            Throbber.State = ThrobberState.Stopped;
            MainMultiPanel.SelectedPage = ResultPage;
        }

        /// <summary>
        /// Gets the error page.
        /// </summary>
        /// <param name="e">The <see cref="APIKeyCreationEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        private MultiPanelPage GetErrorPage(APIKeyCreationEventArgs e)
        {
            GeneralErrorLabel.Text = String.Format(CultureConstants.DefaultCulture, GeneralErrorLabel.Text, e.KeyTestError);
            return GeneralErrorPage;
        }

        private void esiTokenInstructionsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.OpenURL(new Uri($"{NetworkConstants.EsiTokenBootstrapper}"));
        }
    }
}