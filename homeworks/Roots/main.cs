using System;
using static System.Console;
using static System.Math;
using static matrix;
using static Roots;

public class main{
	public static void Main(string[] args){
		WriteLine("===========Part a============");
		var rnd = new Random();
		vector guess,root;
		Func<vector,vector> f = x => new vector(x[0]*x[0]-1,x[1]*x[1]-4);
		for(int i=0;i<2;i++){
			guess=new vector(rnd.NextDouble()*10-5,rnd.NextDouble()*10-5);
			root=NMBL(f,guess);
			WriteLine("Finding root in f(x)=x^2-2 from ");
			guess.print("Guess: ");
			root.print("A root is at ");
			f(root).print("And has value ");
		}
		WriteLine("Finding extremum of the Rosenbrocks valley function ");
		WriteLine("The derivative is f'(x)=-2*(1-x)-400*x*(y-x^2),200*(y-x^2)");
		for(int i=0;i<5;i++){
			f= x => new vector(-2*(1-x[0])-400*x[0]*(x[1]-x[0]*x[0]),200*(x[1]-x[0]*x[0]));
			guess=new vector(rnd.NextDouble()*0.5+1,rnd.NextDouble()+2);
			if(i==1)
				guess=new vector(-1.34,1.81);
			guess.print($"Guess {i}: ");
			root=NMBL(f,guess,Pow(10,-4));
			root.print("A root is at ");
			f(root).print("And the derivative has the value ");
			WriteLine($"the functions value at this point is {Pow((1-root[0]),2)+100*Pow(root[1]-Pow(root[0],2),2)}"); 
		}
	}
}
