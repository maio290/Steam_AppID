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
using System.Diagnostics;
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
		
		
		string config_file = @"\appid_changer.cfg";
		string filename = @"\steam_appid.txt";
		string folder =@"";
		string start_file =@"";
		string rundir = Application.StartupPath;
		string checkbox_state =@"";
		

		
		void MainFormLoad(object sender, EventArgs e)
		{
					textBox2.Text = @"Select Folder (must contain a steam_appid.txt)";
					if(File.Exists(rundir + config_file))
					{
						using (var reader = new StreamReader(rundir + config_file))
						{
   						 folder = reader.ReadLine();
    					 start_file = reader.ReadLine();
    					 checkbox_state = reader.ReadLine();
   					 	 textBox1.Text = reader.ReadLine();
						}
					     textBox2.Text = folder;
					     textBox3.Text = Path.GetFileName(start_file);

					     if(checkbox_state == "True")
					        {
					     		checkBox1.Checked = true;
					        }

					}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
		System.Windows.Forms.FolderBrowserDialog objDialog = new FolderBrowserDialog();
		objDialog.Description = "Description";
		objDialog.SelectedPath=@"C:\";    
		DialogResult objResult = objDialog.ShowDialog(this);
		if (objResult == DialogResult.OK)
		{
 		folder = objDialog.SelectedPath;
		textBox2.Text = folder;
		}
		
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
			        File.Delete(rundir + config_file);
			        FileStream config = new FileStream(rundir + config_file, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			        StreamWriter cfg = new StreamWriter(config);
			        cfg.WriteLine(folder);
			        cfg.WriteLine(start_file);
			        cfg.WriteLine(checkBox1.Checked);
			        cfg.WriteLine(textBox1.Text);
			        cfg.Close();
			        MessageBox.Show("Successfully patched", "Steam App-ID Changer", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
			        	 if(checkBox1.Checked)
						{
					 	System.Diagnostics.Process.Start(start_file);
						}
			        
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
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			
		}
		
		void Label3Click(object sender, EventArgs e)
		{
			
		}
		
		void Label2Click(object sender, EventArgs e)
		{
			
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			folder = textBox2.Text;
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			textBox2.Text = "";
		}
		
		
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
		
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{

		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			

				
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.InitialDirectory = folder ;
			openFileDialog1.Filter = "exe files(*.exe)|*.exe";
			 if(openFileDialog1.ShowDialog() == DialogResult.OK)
			 {
			 	 start_file = openFileDialog1.FileName;
			 	textBox3.Text = Path.GetFileName(openFileDialog1.FileName);
			 }
		

			
		}
		
			void Button6Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://steamdb.info/");
		}
		
		
		void OpenFileDialog1FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		}
		
		void DataGridView1CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}
		
		void DataGrid1Navigate(object sender, NavigateEventArgs ne)
		{
			
		}
	}
}
