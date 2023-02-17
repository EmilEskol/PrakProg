using System;
using static System.Math;
using static System.Console;

static class strin{
	static int Main(string[] args){
		int returnValue=0;
		string infile=null,outfile=null;
		foreach(var arg in args){
			var words=arg.Split(":");
			if(words[0]=="-input"){infile=words[1];}
			if(words[0]=="-output"){outfile=words[1];}
		}
		if(infile==null){
			Error.WriteLine("Wrong inputfilename");
			returnValue++;
		}
		if(outfile==null){
			Error.WriteLine("Wrong outputfilename");
			returnValue++;
		}
		if(returnValue>0)return returnValue;
		var instream= new System.IO.StreamReader(infile);
		var outstream= new System.IO.StreamWriter(outfile);
		for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
			double x=double.Parse(line);
			outstream.WriteLine($"{x} {Sin(x)} {Cos(x)}");
		}
		instream.Close();
		outstream.Close();
		return returnValue;
	}
}
