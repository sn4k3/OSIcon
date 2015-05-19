/*
 * OSIcon
 * Author: Tiago Conceição
 * 
 * https://github.com/sn4k3/OSIcon
 * http://www.codeproject.com/Articles/50064/OSIcon
 */
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace OSIcon.Explorer
{
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();
            lbProductName.Text = string.Format("Product Name: {0}", ProductName);
            lbProductVersion.Text = string.Format("Product Version: {0}", ProductVersion);
            tbDescription.Text = AssemblyDescription;
            lbAuthor.Text = string.Format("Author: {0}", OSIcon.About.ProjectAuthor);
            lbLibWWW.Text = OSIcon.About.ProjectUrl;

            lbOSIconLibraryVersion.Text = "Version: " + GetAssemblyVersion(typeof (IconReader));
        }
        private void lbLibWWW_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using(Process proc = new Process())
            {
                proc.StartInfo.FileName = OSIcon.About.ProjectUrl;
                proc.Start();
                proc.Close();
            }
        }
        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Application.ProductVersion;
                //return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        static public Version GetAssemblyVersion(Type type)
        {
            Assembly asm = Assembly.GetAssembly(type);
            if (asm == null) return null;
            AssemblyName asmName = asm.GetName();
            return asmName.Version;
        }
        #endregion
    }
}
