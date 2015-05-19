/*
 * OSIcon
 * Author: Tiago Conceição
 * 
 * https://github.com/sn4k3/OSIcon
 * http://www.codeproject.com/Articles/50064/OSIcon
 */
using System;
using System.Windows.Forms;

namespace OSIcon.Explorer
{
    public partial class WindowsThumbnails : UserControl
    {
        #region Properties
        public WindowsThumbnail WindowsThumbnail { get; private set; }
        #endregion

        #region Constructor
        public WindowsThumbnails()
        {
            InitializeComponent();
            WindowsThumbnail = new WindowsThumbnail();
        }
        #endregion

        #region Overrides
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // This is unless in other systems lower than Vista so, disable it:
            if(!Utilities.IsVistaOrAbove())
            {
                lbRequirements.Visible = true;
                return;
            }
            WindowsThumbnail.AddIgnoredHandler(Program.MainFrm.Handle);
            // Retrieve windows list
            GetWindows();
            Resize += (sender, args) => UpdateThumb();
        }

        #endregion

        #region Methods
        /// <summary>
        /// Retrieve all active windows
        /// </summary>
        private void GetWindows()
        {
            WindowsThumbnail.Refresh(true);
            // Populate ComboBox
            cbWindows.Items.Clear();
            foreach (var w in WindowsThumbnail)
                cbWindows.Items.Add(w);
        }

        /// <summary>
        /// Update image
        /// </summary>
        private void UpdateThumb()
        {
            WindowsThumbnail.RenderThumbnail(pbOutput.Bounds, (byte)tbOpacity.Value);
        }
        #endregion

        #region Events
        /// <summary>
        /// Button refresh click
        /// </summary>
        private void ButtonClick(object sender, EventArgs e)
        {
            GetWindows();
        }

        /// <summary>
        /// We change window in list
        /// </summary>
        private void cbWindows_SelectedIndexChanged(object sender, EventArgs e)
        {
            var w = (WindowsThumbnail.Window)cbWindows.SelectedItem;
            var registed = WindowsThumbnail.Register(Program.MainFrm.Handle, w);
            if(registed)
                UpdateThumb();
        }

        /// <summary>
        /// Opacity Scroll value changed
        /// </summary>
        private void tbOpacity_Scroll(object sender, EventArgs e)
        {
            UpdateThumb();
        }
        #endregion
    }
}
