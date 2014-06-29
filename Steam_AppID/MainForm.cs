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

		
		}
		
		
		string config_file = @"\appid_changer.cfg";
		string filename = @"\steam_appid.txt";
		string folder =@"";
		string start_file =@"";
		string rundir = Application.StartupPath;
		string checkbox_state =@"";
		

		
		void MainFormLoad(object sender, EventArgs e)
		{
					
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
					else
					{
						textBox2.Text = @"Select Folder (must contain a steam_appid.txt)";
					}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
		System.Windows.Forms.FolderBrowserDialog objDialog = new FolderBrowserDialog();
		objDialog.Description = "Select a Folder with a steam_appid.txt from /steamapps/common/";
		objDialog.SelectedPath=@"C:\";    
		DialogResult objResult = objDialog.ShowDialog(this);
		if (objResult == DialogResult.OK)
		{
 		folder = objDialog.SelectedPath;
		textBox2.Text = folder;
		}
		
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
					 		Process.Start(start_file);
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
			folder = textBox2.Text;
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
			folder = "";
		}
		
		

		
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{

		}
		

		
		void Button5Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.InitialDirectory = folder ;
			openFileDialog1.Filter = "Executable File (*.exe)|*.exe";
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
		

	}
}
