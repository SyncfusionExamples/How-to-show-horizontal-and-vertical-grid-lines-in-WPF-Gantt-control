using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Gantt;
using System.Windows;
using Syncfusion.Windows.Shared;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Reflection;
using System.Globalization;
using Syncfusion.Windows.Controls.Gantt.Chart;

namespace Gantt_GettingStarted
{
    public class ViewModel :NotificationObject
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            InitialSetup();
        }

        #endregion

        #region Private Members

        private ObservableCollection<TaskDetails> _taskCollection;
        private ObservableCollection<Resource> _resourceCollection;
        private List<StripLineInfo> _stripCollection;

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the appointment item source.
        /// </summary>
        /// <value>The appointment item source.</value>
        public ObservableCollection<TaskDetails> TaskCollection
        {
            get
            {
                return _taskCollection;
            }
            set
            {
                _taskCollection = value;
            }
        }

        /// <summary>
        /// Gets or sets the gantt resources.
        /// </summary>
        /// <value>The gantt resources.</value>
        public ObservableCollection<Resource> ResourceCollection
        {
            get
            {
                return _resourceCollection;
            }
            set
            {
                _resourceCollection = value;
            }
        }

        /// <summary>
        /// Gets or sets the strip collection.
        /// </summary>
        /// <value>The strip collection.</value>
        public List<StripLineInfo> StripCollection
        {
            get
            {
                return _stripCollection;
            }
            set
            {
                _stripCollection = value;
                RaisePropertyChanged("StripCollection");
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initials the setup.
        /// </summary>
        private void InitialSetup()
        {
            TaskRepository task = new TaskRepository();
            this._taskCollection = task.TaskCollection;
            this.ResourceCollection = task.ResourceCollection;
        }
        #endregion
    }
}