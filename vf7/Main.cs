using System;
using Gtk;

namespace vf7
{
	class MainClass
	{
		
		
		public static void Main (string[] args)
		{

			string res = null;
			
			try{
				 res = args[0];
			}catch (Exception e){
				
			}
			
			if(res!=null){
				Console.WriteLine("Using argument: "+res);
			}else{
				Console.WriteLine("No argument given.");
			}
			
			Application.Init ();
			MainWindow win = new MainWindow (res);
			win.Show ();
			Application.Run ();
		}
	}
}
