using System;
using Gtk;
using System.Diagnostics;

public partial class MainWindow : Gtk.Window
{
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected virtual void OnButton1Clicked (object sender, System.EventArgs e)
	{
		Console.WriteLine("Video on!");
		Process proc = new Process();
		proc.StartInfo.FileName = "xrandr --output VGA --right-of LVDS 1024x768";
		proc.Start();
		this.status.LabelProp = "on";                
		                           
	}
	
	protected virtual void OnButton2Clicked (object sender, System.EventArgs e)
	{
		Console.WriteLine("Video off!");
		Process proc = new Process();
		proc.StartInfo.FileName = "xrandr --output LVDS --auto --output VGA --off";
		proc.Start();
		this.status.LabelProp = "off";
	}
	
	
	
}
