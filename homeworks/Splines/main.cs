using System;
using static System.Console;
class main{
	static int Main(string[] args){
		int returnValue=0,i=0;
		double[] x,y;
		(x,y)=ReadXY(args);
		return returnValue;
	}
	public static (double[],double[]) ReadXY(string[] args){
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

		char[] splitDelimeters={' ','\t','\n'};
		var splitOptions=StringSplitOptions.RemoveEmptyEntries;

		int i=0;
		for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
			double[] numbers = line.Split(splitDelimeters,splitOptions);
			x[i]=numbers[0];
			y[i]=numbers[1];
			i++;
		}
		return (x,y);
	}
}
