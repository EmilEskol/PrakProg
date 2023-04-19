using System;
using static System.Console;
using static matrix;

public static class IOputs{
	public static (double[],double[]) ReadXY(string[] args){
		string infile=null;
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
		var splitOptions=StringSplitOptions.RemoveEmptyEntries;

		int i=0;
		double[] x=new double[1];
		double[] y=new double[1];
		for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
			var numbers = line.Split(",",splitOptions);
			Array.Resize(ref x,i+1);
			Array.Resize(ref y,i+1);
			x[i]=double.Parse(numbers[0]);
			y[i]=double.Parse(numbers[1]);
			i++;
		}
		instream.Close();
		return (x,y);
	}
	public static void WriteXY(string[] args,double[] x,double[] y,string FileName){
		string outfile=null;
		foreach(var arg in args){
			var words=arg.Split(":");
			if(words[0]=="-output"&&words[1]==FileName){
				outfile=words[1];
				}
		}
		if(outfile==null){
			Error.WriteLine("Wrong outputfilename");
		}
		
		var outstream= new System.IO.StreamWriter(outfile);
		for(int i=0;i<x.Length;i++)
			outstream.WriteLine($"{x[i]} {y[i]}");
		outstream.Close();
	}
	public static void WriteXY(string[] args,genlist<double> x,genlist<vector> y,string FileName){
		string outfile=null;
		foreach(var arg in args){
			var words=arg.Split(":");
			if(words[0]=="-output"&&words[1]==FileName){
				outfile=words[1];
			}
		}
		if(outfile==null){
			Error.WriteLine("Wrong outputfilename");
		}
		
		var outstream= new System.IO.StreamWriter(outfile);
		for(int i=0;i<x.size;i++){
			outstream.WriteLine($"{x[i]} ");
			for(int j=0;j<y[i].size;j++){
				outstream.Write($"{y[i][j]} ");
			}
		}
		outstream.Close();
	}
}
