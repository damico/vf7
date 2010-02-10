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
		this.label1.LabelProp = mode;
		
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
		this.label1.LabelProp = mode;
		
		                           
	}
	
	protected virtual void OnButton2Clicked (object sender, System.EventArgs e)
	{
		string xrandr_cmd = "xrandr --output LVDS --auto --output VGA --off";
		Console.WriteLine("Video off!: "+xrandr_cmd);
		Process proc = new Process();
		proc.StartInfo.FileName = xrandr_cmd;
		proc.Start();
		this.status.LabelProp = "off";
		this.label1.LabelProp = mode;
	}
	
	protected virtual void OnFixed1KeyPressEvent (object o, Gtk.KeyPressEventArgs args)
	{
		uint key = args.Event.KeyValue;
		if(key==65470)
		{
			MessageDialog md = new MessageDialog (null, 
                                   DialogFlags.DestroyWithParent,
			                       MessageType.Info, 
                                   ButtonsType.Close, 	"vF7: version 0.1 - 10/feb/2010\n" +
                                   						"written by Jose Damico" +
                                   						"\nhttp://vf7.googlecode.com");
			md.Modal = false;
			md.Title = "About";
			md.Icon = Gtk.IconTheme.Default.LoadIcon("stock_notebook", 24, 0);
			int result = md.Run ();
			md.Destroy();
		}
	
	}
	
}
