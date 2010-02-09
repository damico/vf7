using System;
using Gtk;
using System.Diagnostics;

public partial class MainWindow : Gtk.Window
{
	
	private string res = null;
	private string mode = null;
	public MainWindow (string res) : base(Gtk.WindowType.Toplevel)
	{
		this.res = res;
		mode = "1024x768";		
		if(res!=null) mode = res;
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected virtual void OnButton1Clicked (object sender, System.EventArgs e)
	{
		
		string xrandr_cmd = "xrandr --output VGA --right-of LVDS --mode "+mode;
		Console.WriteLine("Video on!: "+xrandr_cmd);
		Process proc = new Process();
		proc.StartInfo.FileName = xrandr_cmd;
		proc.Start();
		this.status.LabelProp = "on";                
		                           
	}
	
	protected virtual void OnButton2Clicked (object sender, System.EventArgs e)
	{
		string xrandr_cmd = "xrandr --output LVDS --auto --output VGA --off";
		Console.WriteLine("Video off!: "+xrandr_cmd);
		Process proc = new Process();
		proc.StartInfo.FileName = xrandr_cmd;
		proc.Start();
		this.status.LabelProp = "off";
	}
	
	
	
}
