using System;
using System.IO;
using Gtk;

namespace vf7
{


	public class Utils
	{

		public void checkXorg(){
			bool isXorgValid = this.isXorgValid();
			
			if(!isXorgValid){
			
				MessageDialog md = new MessageDialog (null, 
                                   DialogFlags.DestroyWithParent,
			                       MessageType.Error, 
                                   ButtonsType.Close, 	"Invalid xorg.conf!");
				
				md.Title = "Problem";
				md.Icon = Gtk.IconTheme.Default.LoadIcon("stock_notebook", 24, 0);
				
				md.Modal = false;
				int result = md.Run ();
				md.Destroy();
			}
			
		}
		
		
		public bool isXorgValid()
		{
			bool ret = false;
			string fileName = "/etc/X11/xorg.conf";
			int monitors = 0;
			int virtualDisplay = 0;

			try 
			{
            	using (StreamReader sr = new StreamReader(fileName)){ 
            	
                	string line;
                	while ((line = sr.ReadLine()) != null) 
                	{
						if(line.Contains("\"Monitor\"")) monitors++;
						if(line.Contains("Virtual")) virtualDisplay++;
                	}
				}
        	} catch (Exception e) {
            	Console.WriteLine("The file ("+fileName+") could not be read:");
        	}

			if(monitors == 2 && virtualDisplay == 1) ret = true;
			
			return ret;
			
		}	
			
	}
}
