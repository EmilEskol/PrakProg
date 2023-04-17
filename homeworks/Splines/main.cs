using System;
using static System.Console;
class main{
	static int Main(string[] args){
		int returnValue=0;
		double[] xs,ys;
		(xs,ys)=ReadXY(args);
		foreach(double x in xs)
			WriteLine($"{x}");
		foreach(double y in ys)
			WriteLine($"{y}"); 
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
			return (null,null);
		}

		var instream= new System.IO.StreamReader(infile);

		char[] splitDelimeters={' ','\t','\n'};
		var splitOptions=StringSplitOptions.RemoveEmptyEntries;

		int i=0;
		double[] x=new double[1];
		double[] y=new double[1];
		for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
			var numbers = line.Split(splitDelimeters,splitOptions);
			Array.Resize(ref x,i+1);
			Array.Resize(ref y,i+1);
			x[i]=double.Parse(numbers[0]);
			//y[i]=double.Parse(numbers[1]);
			i++;
		}
		return (x,y);
	}
}
