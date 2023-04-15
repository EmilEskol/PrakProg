using System;
using static System.Console;
class main{
	static int Main(string[] args){
		int returnValue=0,i=0;
		double[] x,y;
		string infile=null,outfile=null;
		foreach(var arg in args){
			var words=arg.Split(":");
			if(words[0]=="-input")
				infile=words[1];
		}
		if(infile==null){
			Error.WriteLine("Wrong inputfilename");
			returnValue++;
		}
		if(returnValue>0)
			return returnValue;
		var instream= new System.IO.StreamReader(infile);
		
		for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
			(x[i],y[i])=double.Parse(line); //Virker ikke
		}
		return returnValue;
	}
}
