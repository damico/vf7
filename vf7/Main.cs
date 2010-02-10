using System;
using Gtk;

namespace vf7
{
	class MainClass
	{
		
		
		public static void Main (string[] args)
		{

			
			
			string res = "--";
			
			try{
				 res = args[0];
			}catch (Exception e){
				Console.WriteLine("Unhandled exception!");
			}
			
			if(res!=null){
				Console.WriteLine("Using argument: "+res);
			}else{
				Console.WriteLine("No argument given.");
			}
			
			Application.Init ();
			MainWindow win = new MainWindow (res);
			win.Show ();
			
			Utils util = new Utils();
			util.checkXorg();
			Application.Run ();
			
			
			
		}
	}
	
	
}
