using System;
using static System.Console;
using static System.Math;
using static matrix;
using static Roots;

public class main{
	public static void Main(string[] args){
		WriteLine("===========Part a============");
		Func<vector,vector> f = x => new vector(x[0]*x[0]-2,x[1]*x[1]-4);
		vector guess=new vector(1,1);
		vector root=NMBL(f,guess);
		WriteLine("Finding root in f(x)=x^2-2 from ");
		guess.print("Guess: ");
		root.print("A root is at ");
		f(root).print("And has value ");
	}
}
