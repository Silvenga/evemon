using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using EVEMon.Common;
using EVEMon.Common.Controls;
using EVEMon.Common.SettingsObjects;

namespace EVEMon.NotificationWindow
{
    public partial class IndustryJobsWindow : EVEMonForm
    {
        private readonly bool m_init;

        public IndustryJobsWindow()
        {
            InitializeComponent();
            RememberPositionKey = "IndustryJobsWindow";
            m_init = true;
        }

        /// <summary>
        /// Gets or sets the grouping mode.
        /// </summary>
        [Browsable(false)]
        public Enum Grouping
        {
            get { return jobsList.Grouping; }
            set
            {
                jobsList.Grouping = value;

                if (!m_init)
                    return;

                jobsList.UpdateColumns();
                jobsList.Visibility = !jobsList.Jobs.IsEmpty();
            }
        }

        /// <summary>
        /// Gets or sets the showIssuedFor mode.
        /// </summary>
        [Browsable(false)]
        public IssuedFor ShowIssuedFor
        {
            get { return jobsList.ShowIssuedFor; }
            set
            {
                jobsList.ShowIssuedFor = value;

                if (!m_init)
                    return;

                jobsList.UpdateColumns();
                jobsList.Visible = !jobsList.Jobs.IsEmpty();
            }
        }

        /// <summary>
        /// Gets or sets the enumeration of jobs to display.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public IEnumerable<IndustryJob> Jobs
        {
            get { return jobsList.Jobs; }
            set { jobsList.Jobs = value; }
        }

        /// <summary>
        /// Gets or sets the enumeration of displayed columns.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public IEnumerable<IColumnSettings> Columns
        {
            get { return jobsList.Columns; }
            set
            {
                jobsList.Columns = value;

                if (!m_init)
                    return;

                jobsList.UpdateColumns();
                jobsList.Visibility = !jobsList.Jobs.IsEmpty();
            }
        }
    }
}