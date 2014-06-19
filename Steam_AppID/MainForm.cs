/*
 * Created by SharpDevelop.
 * User: Mario
 * Date: 20.06.2014
 * Time: 00:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Steam_AppID
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		string filename = @"\steam_appid.txt";
		string folder =@"";

		
		void MainFormLoad(object sender, EventArgs e)
		{
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
		System.Windows.Forms.FolderBrowserDialog objDialog = new FolderBrowserDialog();
		objDialog.Description = "Description";
		objDialog.SelectedPath=@"C:\";    
		DialogResult objResult = objDialog.ShowDialog(this);
		if (objResult == DialogResult.OK)
 		folder = objDialog.SelectedPath;
		
		else
		;
	
		}
		void Button2Click(object sender, System.EventArgs e)
		{
				
			
			if(File.Exists(folder + filename))
			 {
			        File.Delete(folder + filename);
			        FileStream appid = new FileStream(folder + filename,FileMode.OpenOrCreate, FileAccess.Write);
			        StreamWriter writer = new StreamWriter(appid);
			        writer.Write(textBox1.Text);
			        writer.Close();
			        MessageBox.Show("Successfully patched", "Steam App-ID Changer", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
			        
			 }
			else
			{
MessageBox.Show("Patching unsuccessfull", "Steam App-ID Changer", 
    MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			
		}
	}
}
